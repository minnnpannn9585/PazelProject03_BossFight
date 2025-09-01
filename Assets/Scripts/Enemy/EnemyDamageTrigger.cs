using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageTrigger : MonoBehaviour
{
    [HideInInspector]
    public EnemyHealth eh;

    public GameObject bulletHitVFX;

    private void Start()
    {
        eh = transform.parent.GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(bulletHitVFX, other.transform.position, Quaternion.identity);
            eh.TakeDamage(10);
        }
    }
}
