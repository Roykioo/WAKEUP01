using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class Audio_Manager : PersistentSingleton<Audio_Manager>
{
    public AudioClip[] audios;
    public AudioSource AS;
    private void Awake()
    {
        AS = GetComponent<AudioSource>();
        AS.clip = audios[0];
        AS.Play();
    }
    public void Update()
    {
        if (!AS.isPlaying)
        {
            AS.clip = audios[1];
            AS.loop = true;
            AS.Play();
        }
    }

}