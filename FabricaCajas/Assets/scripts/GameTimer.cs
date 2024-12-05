using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float totalTime = 60f; // Tiempo total del juego en segundos
    public TMP_Text timerText; // Referencia al texto del temporizador
    public GameManager gameManager; // Referencia al GameManager

    void Update()
    {
        // Reducir el tiempo restante
        totalTime -= Time.deltaTime;

        // Mostrar el tiempo en formato MM:SS
        int minutes = Mathf.FloorToInt(totalTime / 60f);
        int seconds = Mathf.FloorToInt(totalTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";

        // Si el tiempo llega a 0, cambiar de escena
        if (totalTime <= 0f)
        {
            totalTime = 0f; // Evitar números negativos
            EndGame(); // Llamar al final del juego
        }
    }

    void EndGame()
    {
        // Guardar la puntuación en PlayerPrefs para mostrarla en la escena de fin
        PlayerPrefs.SetInt("FinalScore", gameManager.score);

        // Cambiar a la escena de fin del juego
        SceneManager.LoadScene("GameOverScene");
    }
}
