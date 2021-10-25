using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public static float volumen = 0.3f;

    public List<AudioClip> canciones = new List<AudioClip>();


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void IniciarCancion(int index)
    {
        audioSource.clip = canciones[index];
        audioSource.volume = volumen;
        audioSource.Play();
    }
}
