using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public int siguienteEscenaIndex = 2; // Índice de la siguiente escena a cargar (en este caso, escena 2)

    // Esta función se llama cuando se produce una colisión
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cargar la siguiente escena por su índice
            SceneManager.LoadScene(siguienteEscenaIndex);
        }
    }
}
