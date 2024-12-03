using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int Points = 0;
    public TopTrigger triggerTop;
    public AudioSource Score;

    private void OnTriggerExit(Collider other)
    {
        if(triggerTop.BallEnter == true)
        {
            Points++;
            Score.Play();
            triggerTop.BallEnter = false;
        }
    }
}
