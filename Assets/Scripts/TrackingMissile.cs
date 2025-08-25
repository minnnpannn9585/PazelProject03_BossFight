using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingMissile: MonoBehaviour
{
    public Transform target; // 跟踪目标（玩家）
    public float speed = 5f; // 导弹速度
    public float rotationSpeed = 200f; // 旋转速度
    public float lifeTime = 5f; // 导弹生命周期（秒）

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // 设置导弹自动销毁时间
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            // 如果目标不存在，直线飞行
            rb.velocity = transform.forward * speed;
            return;
        }

        // 计算指向目标的方向
        Vector3 direction = target.position - rb.position;
        direction.Normalize();

        // 计算旋转量
        Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);
        rb.angularVelocity = rotationAmount * rotationSpeed;
        
        // 设置导弹速度
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        // 检查是否击中玩家
        if (other.CompareTag("Player"))
        {
            // 这里可以添加击中玩家的逻辑
            Debug.Log("导弹击中玩家!");
            
            // 销毁导弹
            Destroy(gameObject);
        }
    }
}