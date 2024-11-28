using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    // Referencia al ScoreManager para actualizar el texto en el Canvas
    public ScoreManager scoreManager;

    public void AddPoint()
    {
        if (scoreManager != null)
        {
            score++;
            scoreManager.AddPoint();
            Debug.Log("Puntos: " + score);
        }
        else
        {
            Debug.LogError("ScoreManager no asignado en GameManager.");
        }
    }
}
