using UnityEngine;

public class viste : MonoBehaviour
{
    public AudioClip nuevoSonido;
    private bool isInArea;
    private bool hasPlayedNewSound;

    private void OnTriggerEnter(Collider other)
    {
        int Contador=0;
        if (Contador == 0)
        {
        if (other.CompareTag("Player") && !hasPlayedNewSound)
        {
            isInArea = true;
            // Obtener el componente AudioSource del objeto "Player"
            AudioSource playerAudioSource = other.GetComponent<AudioSource>();
            if (playerAudioSource != null)
            {
                // Cambiar el clip del AudioSource del "Player" y reproducir el nuevo sonido
                playerAudioSource.clip = nuevoSonido;
                playerAudioSource.Play();
                hasPlayedNewSound = true;
            }
        }
        Contador ++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInArea)
        {
            isInArea = false;
            // Obtener el componente AudioSource del objeto "Player"
            AudioSource playerAudioSource = other.GetComponent<AudioSource>();
            if (playerAudioSource != null)
            {
                // Restaurar el clip original del AudioSource del "Player" y reproducirlo
                playerAudioSource.clip = null; // Opcionalmente, podr�as volver a asignar el clip original si lo tienes almacenado.
                playerAudioSource.Play();
            }
            hasPlayedNewSound = false;
        }
    }
}
