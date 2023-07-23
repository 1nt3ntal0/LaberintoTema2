using UnityEngine;

public class Atraparte : MonoBehaviour
{
    public AudioClip nuevoSonido; // Nuevo sonido que se reproducirá cuando el Player esté dentro del área
    private AudioSource audioSource;
    private AudioClip originalClip;

    private bool isInArea;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalClip = audioSource.clip;
        isInArea = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cambio"))
        {
            isInArea = true;
            // Cambiar el clip del AudioSource y reproducir el nuevo sonido
            audioSource.clip = nuevoSonido;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cambio"))
        {
            isInArea = false;
            // Restaurar el clip original del AudioSource y reproducirlo
            audioSource.clip = originalClip;
            audioSource.Play();
        }
    }
}
