﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePlatform : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 50f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        rb.velocity = Vector3.back * speed * Time.deltaTime;

    }
}
