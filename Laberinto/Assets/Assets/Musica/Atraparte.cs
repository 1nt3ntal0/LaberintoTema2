using UnityEngine;

public class Atraparte : MonoBehaviour
{
    public AudioClip nuevoSonido; 
    private AudioSource audioSource;
    private AudioClip originalClip;

    private bool Tocando;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalClip = audioSource.clip;
        Tocando = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cambio"))
        {
            Tocando = true;
            audioSource.clip = nuevoSonido;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cambio"))
        {
            Tocando = false;
            audioSource.clip = originalClip;
            audioSource.Play();
        }
    }
}
