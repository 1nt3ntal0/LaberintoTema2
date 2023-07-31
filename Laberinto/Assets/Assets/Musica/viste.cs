using UnityEngine;

public class viste : MonoBehaviour
{
    public AudioClip nuevoSonido;
    private bool isInArea;
    private bool hasPlayedNewSound;
    int Contador=0;

    private void OnTriggerEnter(Collider other)
    {
        if (Contador == 0)
        {
        if (other.CompareTag("Player") && !hasPlayedNewSound)
        {
            isInArea = true;
            AudioSource playerAudioSource = other.GetComponent<AudioSource>();
            if (playerAudioSource != null)
            {
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
            AudioSource playerAudioSource = other.GetComponent<AudioSource>();
            if (playerAudioSource != null)
            {
                playerAudioSource.clip = null; 
                playerAudioSource.Play();
            }
            hasPlayedNewSound = false;
        }
    }
}
