using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSoundEffectScript : MonoBehaviour
{
    public static AudioClip popSound,hurtSound,powerUpSound,jumpSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        popSound = Resources.Load<AudioClip>("Pop");
        hurtSound = Resources.Load<AudioClip>("Hurt");
        powerUpSound = Resources.Load<AudioClip>("PowerUp");
        jumpSound = Resources.Load<AudioClip>("Jump");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip){
        switch (clip)
        {
            case"pop":
                audioSrc.PlayOneShot(popSound);
                break;
            case "hurt":
                audioSrc.PlayOneShot(hurtSound);
                break;
            case "powerup":
                audioSrc.PlayOneShot(powerUpSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
        }
    }
}
