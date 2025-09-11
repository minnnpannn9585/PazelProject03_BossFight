using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateOne : MonoBehaviour
{
    public GameObject laser;
    public Transform shootPoint;
    public EnemySkill04 skill04;
    public Transform[] laserPoints;
    public EnemySkill01Rotation rota;

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

            GameObject laserObj = Instantiate(laser, laserPoints[i]);
            //laserObj.GetComponent<Laser>().ShootLaser(direction);
            StartCoroutine(PauseOneSec());

            Destroy(laserObj, 4f);
        }
        
    }

    IEnumerator PauseOneSec()
    {
        rota.isRotate = false;
        yield return new WaitForSeconds(1f);

        rota.isRotate = true;
        yield return new WaitForSeconds(2f);

        rota.isRotate = false;
        yield return new WaitForSeconds(1f);
        
    }

    
}
