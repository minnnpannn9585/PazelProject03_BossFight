using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBossMovement : MonoBehaviour
{
    public float moveRadius = 10f;
    public float moveSpeed = 3f;
    public float minWaitTime = 1f;
    public float maxWaitTime = 3f;

    private Vector3 centerPoint;
    private Vector3 targetPosition;
    private bool isWaiting = false;
    private float waitTimer = 0f;

    void Start()
    {
        centerPoint = transform.position;
        GenerateNewTargetPosition();
    }

    void Update()
    {
        if (isWaiting)
        {
            // 等待计时
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                isWaiting = false;
                GenerateNewTargetPosition();
            }
        }
        else
        {
            // 向目标位置移动
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        // 计算移动方向
        Vector3 direction = (targetPosition - transform.position).normalized;
        
        // 移动
        transform.position += direction * moveSpeed * Time.deltaTime;
        
        // 检查是否到达目标位置
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        if (distanceToTarget < 0.1f)
        {
            // 到达目标，开始等待
            isWaiting = true;
            waitTimer = Random.Range(minWaitTime, maxWaitTime);
        }
    }

    void GenerateNewTargetPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized * moveRadius;
        targetPosition = centerPoint + new Vector3(randomCircle.x, 0, randomCircle.y);
    }

    void OnDrawGizmosSelected()
    {
        // 绘制圆形场地范围
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(centerPoint, moveRadius);
        
        // 绘制当前目标位置
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(targetPosition, 0.3f);
        }
    }
}
