using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip droppingCoal, pickingUpCoal, runningAround, fadingSteam, 
                    increasingSteam, goingUp, hammerHit, turningValve;

    public static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        droppingCoal = Resources.Load<AudioClip> ("droping coal");
        pickingUpCoal = Resources.Load<AudioClip> ("shovel coal pickup");
        runningAround = Resources.Load<AudioClip> ("running boat");
        fadingSteam = Resources.Load<AudioClip> ("steam going away");
        increasingSteam = Resources.Load<AudioClip> ("steam pipe");
        goingUp = Resources.Load<AudioClip> ("subir escada1");
        hammerHit = Resources.Load<AudioClip> ("hammer pipe");
        turningValve = Resources.Load<AudioClip> ("virando manivela");

        audioSrc = GetComponent<AudioSource> ();
    }

    public static void playSound(string clip){
        switch(clip){
            case "droping coal":
                audioSrc.PlayOneShot(droppingCoal);
                break;
            case "shovel coal pickup":
                audioSrc.PlayOneShot(pickingUpCoal);
                break;
            case "running boat":
                audioSrc.PlayOneShot(runningAround);
                break;
            case "steam going away":
                audioSrc.PlayOneShot(fadingSteam);
                break;
            case "steam pipe":
                audioSrc.PlayOneShot(increasingSteam);
                break;
            case "subir escada1":
                audioSrc.PlayOneShot(goingUp);
                break;
            case "hammer pipe":
                audioSrc.PlayOneShot(hammerHit);
                break;
            case "virando manivela":
                audioSrc.PlayOneShot(turningValve);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
