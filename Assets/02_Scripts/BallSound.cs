using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    public PracticeSounds PS;
    private void OnCollisionEnter(Collision collision)
    {
        PS.PlayBounce();
    }
}
