using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    // Referencia al ScoreManager para actualizar el texto en el Canvas
    public ScoreManager scoreManager;

<<<<<<< HEAD
    // Referencia a todas las cintas transportadoras
    public ConveyorBelt[] conveyorBelts;

    public bool isResetting = false; // Variable para indicar si se está reiniciando

=======
>>>>>>> Scene&Box
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
<<<<<<< HEAD

    public void ResetAllProcesses()
    {
        if (conveyorBelts != null && conveyorBelts.Length > 0)
        {
            isResetting = true; // Indicar que se está reiniciando

            Debug.Log("Reiniciando procesos en todas las cintas...");
            foreach (var conveyor in conveyorBelts)
            {
                if (conveyor != null)
                {
                    conveyor.ResetBeltProcesses();
                }
            }

            isResetting = false; // Reinicio completado
        }
        else
        {
            Debug.LogError("No se asignaron cintas transportadoras en GameManager.");
        }
    }
=======
>>>>>>> Scene&Box
}
