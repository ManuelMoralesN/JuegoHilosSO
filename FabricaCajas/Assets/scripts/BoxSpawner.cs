using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("Spawn Configuration")]
    public GameObject[] boxPrefabs; // Array de prefabs para spawn
    public Transform spawnPoint;   // Punto donde aparecerán los objetos
    public float spawnInterval = 2f; // Tiempo entre cada spawn

    void Start()
    {
        // Iniciar la corrutina de spawn
        StartCoroutine(SpawnBoxes());
    }

    IEnumerator SpawnBoxes()
    {
        while (true)
        {
            SpawnBox(); // Generar una nueva caja
            yield return new WaitForSeconds(spawnInterval); // Esperar el tiempo definido
        }
    }

    void SpawnBox()
    {
        // Elegir un prefab aleatorio
        int randomIndex = Random.Range(0, boxPrefabs.Length);
        GameObject selectedPrefab = boxPrefabs[randomIndex];

        // Instanciar la caja en el punto de spawn
        Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);
    }
}