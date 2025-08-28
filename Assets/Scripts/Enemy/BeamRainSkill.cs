using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamRainSkill : MonoBehaviour
{
    public int beamCount = 8;
    public float radius = 10f;
    public int damage = 50;
    

    public GameObject warningIndicatorPrefab;
    

    //[Header("音效设置")]
    //public AudioClip warningSound;
    //public AudioClip beamImpactSound;
    //private AudioSource audioSource;

    //private void Awake()
    //{
    //    // 获取或添加音频源组件
    //    audioSource = GetComponent<AudioSource>();
    //    if (audioSource == null)
    //    {
    //        audioSource = gameObject.AddComponent<AudioSource>();
    //    }
    //}

    private void Update()
    {
        // 检测玩家输入来触发技能
        if (Input.GetKeyDown(KeyCode.R)) // 假设按下R键触发光束雨技能
        {
            ActivateBeamRain();
            print(1);
        }
    }

    /// <summary>
    /// 启动光束雨技能
    /// </summary>
    public void ActivateBeamRain()
    {
        StartCoroutine(SpawnBeamRain());

    }

    /// <summary>
    /// 生成光束雨的协程
    /// </summary>
    private IEnumerator SpawnBeamRain()
    {
        for (int i = 0; i < beamCount; i++)
        {
            print(2);
            // 生成随机位置
            Vector3 randomPosition = GetRandomPositionInRadius();

            // 生成预警指示器
            GameObject warning = Instantiate(warningIndicatorPrefab, randomPosition, Quaternion.identity);

            // 播放预警音效
            //if (warningSound != null)
            //{
            //    audioSource.PlayOneShot(warningSound);
            //}

            

            // 每个光束之间稍微错开一点时间
            yield return new WaitForSeconds(0.01f);
        }
    }

    

    /// <summary>
    /// 在指定半径内获取随机位置
    /// </summary>
    private Vector3 GetRandomPositionInRadius()
    {
        // 在角色周围随机生成一个点
        Vector2 randomCircle = Random.insideUnitCircle * radius;
        Vector3 randomPos = new Vector3(transform.position.x + randomCircle.x, 1f, transform.position.z + randomCircle.y);

        // 射线检测地面，确保红圈在地面上
        RaycastHit hit;
        if (Physics.Raycast(randomPos + Vector3.up * 50f, Vector3.down, out hit, 100f, LayerMask.GetMask("Ground")))
        {
            randomPos = hit.point;
        }

        return randomPos;
    }



    // 绘制Gizmos辅助调试
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
