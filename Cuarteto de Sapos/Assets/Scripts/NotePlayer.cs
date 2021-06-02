using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NotePlayer : MonoBehaviour
{
    [SerializeField]
    string note;

    AudioSource audioSource;
    AudioClip audioClip;
    string ubicacionAudio = "Audio/";
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        switch (note)
        {
            case "C":
                audioClip = Resources.Load<AudioClip>(ubicacionAudio + "C3");
                break;
            case "D":
                audioClip = Resources.Load<AudioClip>(ubicacionAudio + "D3");
                break;
            case "E":
                audioClip = Resources.Load<AudioClip>(ubicacionAudio + "E3");
                break;
            case "F":
                audioClip = Resources.Load<AudioClip>(ubicacionAudio + "F3");
                break;
            case "G":
                audioClip = Resources.Load<AudioClip>(ubicacionAudio + "G3");
                break;
            case "A":
                audioClip = Resources.Load<AudioClip>(ubicacionAudio + "A3");
                break;
            case "B":
                audioClip = Resources.Load<AudioClip>(ubicacionAudio + "B3");
                break;
            case "KB":
                audioClip = Resources.Load<AudioClip>(ubicacionAudio + "KB");
                break;
            case "KC":
                audioClip = Resources.Load<AudioClip>(ubicacionAudio + "KC");
                break;
            case "KE":
                audioClip = Resources.Load<AudioClip>(ubicacionAudio + "KE");
                break;
            case "KF":
                audioClip = Resources.Load<AudioClip>(ubicacionAudio + "KF");
                break;
            case "KG":
                audioClip = Resources.Load<AudioClip>(ubicacionAudio + "KG");
                break;
        }
        audioSource.clip = audioClip;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!audioSource.isPlaying)
        {

            audioSource.Play();
        }
    }



}
