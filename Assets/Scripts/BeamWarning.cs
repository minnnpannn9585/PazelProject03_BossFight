using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWarning : MonoBehaviour
{
    public float warningDelay = 0.5f;
    public GameObject beamPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBeam(transform.position));
    }

    IEnumerator SpawnBeam(Vector3 position)
    {
        // 等待预警时间
        yield return new WaitForSeconds(warningDelay);
        // 播放光束音效
        //if (beamImpactSound != null)
        //{
        //    audioSource.PlayOneShot(beamImpactSound);
        //}
        // 生成光束
        GameObject beam = Instantiate(beamPrefab, position + Vector3.up * 10f, Quaternion.identity);
        // 检测并伤害范围内的敌人
        DamageEnemiesInArea(position, 1.5f);
    }

    /// <summary>
    /// 对指定区域内的敌人造成伤害
    /// </summary>
    private void DamageEnemiesInArea(Vector3 center, float areaRadius)
    {
        // 检测范围内的所有敌人
        Collider[] colliders = Physics.OverlapSphere(center, areaRadius, LayerMask.GetMask("Enemies"));

        foreach (Collider col in colliders)
        {
            //EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
            //if (enemyHealth != null)
            //{
            //    enemyHealth.TakeDamage(damage);
            //}
        }
    }
}
