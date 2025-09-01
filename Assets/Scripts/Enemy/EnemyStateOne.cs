using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateOne : MonoBehaviour
{
    public GameObject laser;
    public Transform shootPoint;
    public EnemySkill04 skill04;

    bool isSkill01 = true;
    float cd = 3f;

    private void Update()
    {
        cd -= Time.deltaTime;
        if (cd <= 0f)
        {
            if (isSkill01)
            {
                ShootFourDir();
                isSkill01 = false;
            }
            else
            {
                skill04.Skill04();
                isSkill01 = true;
            }
            cd = 3f;
        }
    }

    public void ShootFourDir()
    {
        // Shoot laser in four directions: up, down, left, right
        for (int i = 0; i < 4; i++)
        {
            Vector3 direction = Vector3.zero;

            switch (i)
            {
                case 0: // Up
                    direction = Vector3.forward;
                    break;
                case 1: // Down
                    direction = Vector3.back;
                    break;
                case 2: // Left
                    direction = Vector3.left;
                    break;
                case 3: // Right
                    direction = Vector3.right;
                    break;
            }

            GameObject laserObj = Instantiate(laser, shootPoint.position, Quaternion.identity);
            laserObj.GetComponent<Laser>().ShootLaser(direction);
            
        }
        
    }

    
}
