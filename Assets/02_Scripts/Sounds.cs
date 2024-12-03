using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource Begin;
    public AudioSource Start_Whistle;

    public void playBegin()
    {
        Begin.Play();
    }

    public void playWhistle()
    {
        Start_Whistle.Play();
    }
}
