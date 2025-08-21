using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateOne : MonoBehaviour
{
    public GameObject laser;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootFourDir();
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

            GameObject laserObj = Instantiate(laser, transform.position, Quaternion.identity);
            laserObj.GetComponent<Laser>().ShootLaser(direction);
            
        }
        
    }

    
}
