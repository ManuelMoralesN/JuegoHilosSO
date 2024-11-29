using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Para usar TextMeshPro

public class CPUBarController : MonoBehaviour
{
    public Slider cpuSlider;
    public TMP_Text timeRemainingText; // Cambiado a TextMeshPro
    public float maxCPUTime = 15f;
    public GameManager gameManager; // Referencia al GameManager
    public Color startColor = Color.green;
    public Color midColor = Color.yellow;
    public Color endColor = Color.red;
    public Color cooldownColor = Color.blue;

    private float currentCPUTime;
    private bool isCoolingDown = false;

    private void Start()
    {
        if (cpuSlider == null)
        {
            Debug.LogError("No se asignó un Slider para CPUBarController.");
            return;
        }

        currentCPUTime = maxCPUTime;
        cpuSlider.maxValue = maxCPUTime;
        cpuSlider.value = maxCPUTime;
        UpdateCPUBarColor();
    }

    private void Update()
    {
        if (!isCoolingDown)
        {
            currentCPUTime -= Time.deltaTime;
            if (currentCPUTime <= 0)
            {
                CPUOverloaded();
            }
            else
            {
                UpdateCPUBar();
            }
        }
    }

    private void UpdateCPUBar()
    {
        cpuSlider.value = currentCPUTime;

        float percentage = currentCPUTime / maxCPUTime;
        if (timeRemainingText != null)
        {
            timeRemainingText.text = $"Tiempo restante: {Mathf.Ceil(currentCPUTime)}s";
        }

        UpdateCPUBarColor();
    }

    private void UpdateCPUBarColor()
    {
        float percentage = currentCPUTime / maxCPUTime;
        if (percentage > 0.5f)
        {
            cpuSlider.fillRect.GetComponent<Image>().color = Color.Lerp(midColor, startColor, (percentage - 0.5f) * 2f);
        }
        else
        {
            cpuSlider.fillRect.GetComponent<Image>().color = Color.Lerp(endColor, midColor, percentage * 2f);
        }
    }

    private void CPUOverloaded()
    {
        Debug.Log("CPU sobrecargada, reiniciando procesos...");
        
        if (gameManager != null)
        {
            gameManager.ResetAllProcesses(); // Llama a la función del GameManager
        }
        else
        {
            Debug.LogError("GameManager no asignado en CPUBarController.");
        }

        StartCoroutine(CooldownCPU()); // Inicia el enfriamiento
    }

    private IEnumerator CooldownCPU()
    {
        isCoolingDown = true;
        float cooldownTime = 3f; // Duración del enfriamiento
        float elapsed = 0f;

        while (elapsed < cooldownTime)
        {
            cpuSlider.fillRect.GetComponent<Image>().color = cooldownColor;
            cpuSlider.value = Mathf.Lerp(0, maxCPUTime, elapsed / cooldownTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        currentCPUTime = maxCPUTime;
        cpuSlider.value = maxCPUTime;
        isCoolingDown = false;

        Debug.Log("CPU enfriada y reiniciada.");
    }
}
