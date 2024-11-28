using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 2f; // Velocidad de la cinta
    public Transform endPoint; // Punto final donde los objetos desaparecen
    public string acceptedTag; // Tag del objeto aceptado por esta cinta
    public GameManager gameManager; // Referencia al GameManager para sumar puntos

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
        }
        else
        {
            // Rechazar el objeto incorrecto moviéndolo fuera de la cinta
            RejectObject(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(acceptedTag))
        {
            Destroy(other.gameObject);
            gameManager.AddPoint(); // Asumiendo que gameManager es una instancia de ScoreManager
        }
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
