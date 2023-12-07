using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript instance;
    public AudioSource[] soundEffects;
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
    }
}
