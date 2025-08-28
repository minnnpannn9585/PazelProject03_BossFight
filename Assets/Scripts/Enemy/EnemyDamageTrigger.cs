using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageTrigger : MonoBehaviour
{
    public EnemyHealth eh;

    private void Start()
    {
        eh = transform.parent.GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            eh.TakeDamage(10);
        }
    }
}
