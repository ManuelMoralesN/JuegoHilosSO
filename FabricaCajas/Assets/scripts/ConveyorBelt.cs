using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 2f; // Velocidad de la cinta
    public Transform endPoint; // Punto final donde los objetos desaparecen
    public string acceptedTag; // Tag del objeto aceptado por esta cinta
    public GameManager gameManager; // Referencia al GameManager para sumar puntos

    private List<GameObject> processesOnBelt = new List<GameObject>(); // Lista de procesos en la cinta

    private void OnTriggerStay2D(Collider2D other)
    {
        // Comprobar si el objeto tiene la etiqueta correcta
        if (other.CompareTag(acceptedTag))
        {
            // Mover el objeto en la dirección de la cinta
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (endPoint.position - other.transform.position).normalized;
                rb.velocity = direction * speed;
            }

            // Agregar el objeto a la lista si no está
            if (!processesOnBelt.Contains(other.gameObject))
            {
                processesOnBelt.Add(other.gameObject);
            }
        }
        else
        {
            // Rechazar el objeto incorrecto
            RejectObject(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(acceptedTag))
        {
            processesOnBelt.Remove(other.gameObject);

            // Verificar si el juego está en estado de reinicio
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

        processesOnBelt.Clear(); // Limpia la lista después de reiniciar
    }

    private void RejectObject(Collider2D other)
    {
        // Mover el objeto incorrecto ligeramente hacia atrás para rechazarlo
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 rejectDirection = (other.transform.position - transform.position).normalized;
            rb.velocity = rejectDirection * speed;
        }
    }
}
