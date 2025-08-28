using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRef : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            Rigidbody laserRigidbody = other.GetComponent<Rigidbody>();
            if (laserRigidbody != null)
            {
                // 获取入射方向
                Vector3 incomingDirection = laserRigidbody.velocity.normalized;

                // 获取法向量（假设物体的法向量是其表面的法线）
                Vector3 normal = -transform.right; 

                // 计算反射方向
                Vector3 reflectedDirection = Vector3.Reflect(incomingDirection, normal);

                // 更新激光的速度
                laserRigidbody.velocity = reflectedDirection * laserRigidbody.velocity.magnitude;
            }
        }
    }
}