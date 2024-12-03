using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTrigger : MonoBehaviour
{
    public bool BallEnter = false;

    private void OnTriggerEnter(Collider other)
    {
        BallEnter = true;
    }
}
