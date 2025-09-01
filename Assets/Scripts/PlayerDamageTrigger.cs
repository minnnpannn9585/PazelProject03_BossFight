using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageTrigger : MonoBehaviour
{
    [HideInInspector]
    public PlayerHealth ph;

    public GameObject bulletHitVFX;

    private void Start()
    {
        ph = transform.parent.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(bulletHitVFX, other.transform.position, Quaternion.identity);
            ph.TakeDamage(10);
        }
    }
}
