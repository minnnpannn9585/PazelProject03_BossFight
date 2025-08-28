using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill04 : MonoBehaviour
{
    public GameObject laser;
    Transform shootPoint;
    Transform player;

    private void Start()
    {
        shootPoint = transform.GetChild(3);
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject laserObj = Instantiate(laser, shootPoint.position, Quaternion.identity);
            Vector3 dir = (player.position - shootPoint.position).normalized;
            laserObj.GetComponent<Laser>().ShootLaser(dir);
        }
    }
}
