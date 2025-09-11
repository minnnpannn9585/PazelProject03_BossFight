using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill01Rotation : MonoBehaviour
{
    public bool isRotate = false;
    public float rotateSpeed = 30f;
    void Update()
    {
        if (isRotate)
        {
            transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
        }
        
    }
}
