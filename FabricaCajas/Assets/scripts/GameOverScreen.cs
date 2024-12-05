using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text finalScoreText; // Referencia al texto de la puntuación

    void Start()
    {
        // Obtener la puntuación final desde PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = "Puntuación Final: " + finalScore;
    }
}
