using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState3 : MonoBehaviour
{
    public GameObject missilePrefab; // 导弹预制体
    public Transform firePoint; // 发射点
    public float missileSpeed = 8f; // 导弹速度
    public KeyCode fireKey = KeyCode.T; // 发射按键

    private Transform player; // 玩家引用

    void Start()
    {
        // 查找玩家对象
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("未找到带有'Player'标签的对象!");
        }
    }

    void Update()
    {
        // 检查是否按下发射键
        if (Input.GetKeyDown(fireKey))
        {
            FireMissile();
        }
    }

    void FireMissile()
    {
        if (missilePrefab == null)
        {
            Debug.LogWarning("未分配导弹预制体!");
            return;
        }
        
        if (player == null)
        {
            Debug.LogWarning("未找到玩家对象!");
            return;
        }

        // 创建导弹实例
        GameObject missile = Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
        
        // 获取导弹脚本并设置属性
        TrackingMissile trackingMissile = missile.GetComponent<TrackingMissile>();
        if (trackingMissile != null)
        {
            trackingMissile.target = player;
            trackingMissile.speed = missileSpeed;
        }
        else
        {
            Debug.LogWarning("导弹预制体上没有HomingMissile组件!");
        }
    }
}
