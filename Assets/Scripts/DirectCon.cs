using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectCon : MonoBehaviour
{
    public float rotationSpeed = 5f;          // 旋转速度
    //public float interactionDistance = 3f;    // 交互距离
    //public KeyCode interactionKey = KeyCode.E; // 交互按键


    //public LayerMask mirrorLayer;            // 镜子层级

    //private Transform currentMirror;         // 当前控制的镜子
    //private bool isControlling = false;      // 是否正在控制

    public Transform[] mirrors; // 所有镜子
    float minimumDis = 3f; // 最小距离
    Transform closestMirror; // 最近的镜子

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q)) // 按下E键开始控制镜子
        {
            foreach(Transform mirror in mirrors)
            {
                float distance = Vector3.Distance(mirror.position, transform.position);
                
                if (distance <= 3)
                {
                    if(distance <= minimumDis)
                    {
                        minimumDis = distance;
                        closestMirror = mirror;
                    }
                }
            }
        }

        if(Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.Q)) // 松开E键停止控制镜子
        {
            minimumDis = 3f; // 重置最小距离
            closestMirror = null;
        }

        if (Input.GetKey(KeyCode.E) && closestMirror != null) // 按住E键控制最近的镜子
        {
            closestMirror.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.Q) && closestMirror != null) // 按住Q键控制最近的镜子
        {
            closestMirror.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);
        }
    }



    // 可视化交互距离（编辑器调试用）
    private void OnDrawGizmosSelected()
    {
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * minimumDis);
        }
    }
}
