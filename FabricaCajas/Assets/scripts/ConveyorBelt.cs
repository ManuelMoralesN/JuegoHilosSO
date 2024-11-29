using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 2f; // Velocidad de la cinta
    public Transform endPoint; // Punto final donde los objetos desaparecen
    public string acceptedTag; // Tag del objeto aceptado por esta cinta
    public GameManager gameManager; // Referencia al GameManager para sumar puntos

<<<<<<< HEAD
    private List<GameObject> processesOnBelt = new List<GameObject>(); // Lista de procesos en la cinta

=======
>>>>>>> Scene&Box
    private void OnTriggerStay2D(Collider2D other)
    {
        // Comprobar si el objeto tiene la etiqueta correcta
        if (other.CompareTag(acceptedTag))
        {
<<<<<<< HEAD
            // Mover el objeto en la direcciÃ³n de la cinta
=======
            // Mover el objeto en la dirección de la cinta
>>>>>>> Scene&Box
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (endPoint.position - other.transform.position).normalized;
                rb.velocity = direction * speed;
            }
<<<<<<< HEAD

            // Agregar el objeto a la lista si no estÃ¡
            if (!processesOnBelt.Contains(other.gameObject))
            {
                processesOnBelt.Add(other.gameObject);
            }
        }
        else
        {
            // Rechazar el objeto incorrecto
=======
        }
        else
        {
            // Rechazar el objeto incorrecto moviéndolo fuera de la cinta
>>>>>>> Scene&Box
            RejectObject(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(acceptedTag))
        {
<<<<<<< HEAD
            processesOnBelt.Remove(other.gameObject);

            // Verificar si el juego estÃ¡ en estado de reinicio
            if (gameManager != null && gameManager.isResetting)
            {
                Debug.Log("Proceso reiniciado, no se agrega punto.");
                Destroy(other.gameObject);
                return; // No sumar puntos durante el reinicio
            }

            Destroy(other.gameObject);
            gameManager.AddPoint();
        }
    }

    public void ResetBeltProcesses()
    {
        Debug.Log($"Reiniciando procesos en la cinta {gameObject.name}.");

        // Hacer una copia de la lista para evitar modificarla mientras la iteramos
        List<GameObject> processesToRemove = new List<GameObject>(processesOnBelt);

        foreach (GameObject process in processesToRemove)
        {
            if (process != null)
            {
                Destroy(process);
            }
        }

        processesOnBelt.Clear(); // Limpia la lista despuÃ©s de reiniciar
    }

    private void RejectObject(Collider2D other)
    {
        // Mover el objeto incorrecto ligeramente hacia atrÃ¡s para rechazarlo
=======
            Destroy(other.gameObject);
            gameManager.AddPoint(); // Asumiendo que gameManager es una instancia de ScoreManager
        }
    }


    private void RejectObject(Collider2D other)
    {
        // Mover el objeto incorrecto ligeramente hacia atrás para rechazarlo
>>>>>>> Scene&Box
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 rejectDirection = (other.transform.position - transform.position).normalized;
            rb.velocity = rejectDirection * speed;
        }
    }
}
