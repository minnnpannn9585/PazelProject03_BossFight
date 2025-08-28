using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            // calculate
            print("get hurt");
        }
    }
}
