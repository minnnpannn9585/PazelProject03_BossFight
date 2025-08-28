using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rb;
    Collider col;
    private float timer = 0.3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        col.enabled = false;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            col.enabled = true;
        }
    }

    public void ShootLaser(Vector3 dir)
    {
        rb.velocity = dir.normalized * speed;


    }
}
