using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text finalScoreText; // Referencia al texto de la puntuaci�n

    void Start()
    {
        // Obtener la puntuaci�n final desde PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = "Puntuaci�n Final: " + finalScore;
    }
}
