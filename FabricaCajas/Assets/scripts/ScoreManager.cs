using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

   public TMP_Text scoreText;

    private int score = 0;

    void Start()
    {
        // Inicializa el puntaje al principio
        UpdateScoreText();
    }

    public void AddPoint()
    {
        score++; // Incrementa los puntos
        UpdateScoreText(); // Actualiza el texto
    }

    void UpdateScoreText()
    {
        scoreText.text = "0" + score.ToString();
    }
}

