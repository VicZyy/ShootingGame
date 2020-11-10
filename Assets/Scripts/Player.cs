using UnityEngine;
using System.Collections;

/// <summary>
/// 主角控制脚本
/// </summary>
public class Player : MonoBehaviour
{
    // 角色控制器组件
    CharacterController m_ch;
    // 角色移动速度
    public float m_movSpeed = 3.0f;
    // 重力
    public float m_gravity = 2.0f;
    // 生命值
    public int m_life = 5;


    // Use this for initialization
    void Start()
    {
        m_ch = GetComponent<CharacterController>();
        //锁定鼠标
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_life <= 0)
            return;
        Control();
    }

    void Control()
    {
        //鼠标控制视角
        float rh = Input.GetAxis("Mouse X");
        float rv = Input.GetAxis("Mouse Y");
        Camera.main.transform.eulerAngles += new Vector3(-rv,0, 0);
        transform.eulerAngles += new Vector3(0,rh, 0);
        //前后左右
        Vector3 motion = Vector3.zero;
        motion.x = Input.GetAxis("Horizontal") * m_movSpeed * Time.deltaTime;
        motion.z = Input.GetAxis("Vertical") * m_movSpeed * Time.deltaTime;
        motion.y -= m_gravity * Time.deltaTime;
        // 使用角色控制器提供的Move函数进行移动 它会自动检测碰撞
        m_ch.Move(transform.TransformDirection(motion));
    }

    // 在编辑器中为主角显示一个图标
    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "Spawn.tif");
    }
}
