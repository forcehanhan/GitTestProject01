//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2015-11-02 20:22:50
//备    注：
//===================================================
using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class RoleCtrl : MonoBehaviour 
{
    /// <summary>
    /// 移动的目标点
    /// </summary>
    private Vector3 m_TargetPos = Vector3.zero;

    /// <summary>
    /// 控制器
    /// </summary>
    private CharacterController m_CharacterController;

    /// <summary>
    /// 移动速度
    /// </summary>
    [SerializeField]
    private float m_Speed = 10f;

    /// <summary>
    /// 转身速度
    /// </summary>
    private float m_RotationSpeed = 0.2f;

    /// <summary>
    /// 转身的目标方向
    /// </summary>
    private Quaternion m_TargetQuaternion;

    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();

        if (CameraCtrl.Instance != null)
        {
            CameraCtrl.Instance.Init();
        }

        FingerEvent.Instance.OnFingerDrag += OnFingerDrag;
        FingerEvent.Instance.OnZoom += OnZoom;
        FingerEvent.Instance.OnPlayerClickGround += OnPlayerClickGround;
    }

    private void OnZoom(FingerEvent.ZoomType obj)
    {
        switch (obj)
        { 
            case FingerEvent.ZoomType.In:
                CameraCtrl.Instance.SetCameraZoom(0);
                break;
            case FingerEvent.ZoomType.Out:
                CameraCtrl.Instance.SetCameraZoom(1);
                break;
        }
    }

    private void OnPlayerClickGround()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.name.Equals("Ground", System.StringComparison.CurrentCultureIgnoreCase))
            {
                m_TargetPos = hitInfo.point;
                m_RotationSpeed = 0;
            }
        }
    }

    private void OnFingerDrag(FingerEvent.FingerDir obj)
    {
        switch (obj)
        { 
            case FingerEvent.FingerDir.Left:
                CameraCtrl.Instance.SetCameraRotate(0);
                break;
            case FingerEvent.FingerDir.Right:
                CameraCtrl.Instance.SetCameraRotate(1);
                break;
            case FingerEvent.FingerDir.Up:
                CameraCtrl.Instance.SetCameraUpAndDown(1);
                break;
            case FingerEvent.FingerDir.Down:
                CameraCtrl.Instance.SetCameraUpAndDown(0);
                break;
        }
    }

    void OnDestroy()
    {
        if (FingerEvent.Instance != null)
        {
            FingerEvent.Instance.OnFingerDrag -= OnFingerDrag;
            FingerEvent.Instance.OnZoom -= OnZoom;
            FingerEvent.Instance.OnPlayerClickGround -= OnPlayerClickGround;
        }
    }

    void Update()
    {
        if (m_CharacterController == null) return;

        //让角色贴着地面
        if (!m_CharacterController.isGrounded)
        {
            m_CharacterController.Move((transform.position + new Vector3(0, -1000, 0)) - transform.position);
        }

        //if (Input.GetMouseButtonUp(1))
        //{
        //    Collider[] colliderArr = Physics.OverlapSphere(transform.position, 3, 1 << LayerMask.NameToLayer("Item"));
        //    if (colliderArr.Length > 0)
        //    {
        //        for (int i = 0; i < colliderArr.Length; i++)
        //        {
        //            Debug.Log("找到了附近的箱子" + colliderArr[i].gameObject.name);
        //        }
        //    }
        //}

        if (Input.GetMouseButtonUp(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit[] hitArr = Physics.RaycastAll(ray, Mathf.Infinity, 1 << LayerMask.NameToLayer("Item"));

            //if (hitArr.Length > 0)
            //{
            //    for (int i = 0; i < hitArr.Length; i++)
            //    {
            //        Debug.Log("找到了" + hitArr[i].collider.gameObject.name);
            //    }
            //}

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Item")))
            {
                BoxCtrl boxCtrl = hit.collider.GetComponent<BoxCtrl>();
                if (boxCtrl != null)
                {
                    boxCtrl.Hit();
                }
            }
        }

        //让角色贴着地面
        if (!m_CharacterController.isGrounded)
        {
            m_CharacterController.Move((transform.position + new Vector3(0, -1000, 0)) - transform.position);
        }

        //如果目标点不是原点 进行移动
        if (m_TargetPos != Vector3.zero)
        {
            if (Vector3.Distance(m_TargetPos, transform.position) > 0.1f)
            {
                Vector3 direction = m_TargetPos - transform.position;
                direction = direction.normalized; //归一化
                direction = direction * Time.deltaTime * m_Speed;
                direction.y = 0;
                //transform.LookAt(new Vector3(m_TargetPos.x, transform.position.y, m_TargetPos.z));

                //让角色缓慢转身
                if (m_RotationSpeed <= 1)
                {
                    m_RotationSpeed += 5f * Time.deltaTime;
                    m_TargetQuaternion = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Lerp(transform.rotation, m_TargetQuaternion, m_RotationSpeed);
                }

                m_CharacterController.Move(direction);
            }
        }

        CameraAutoFollow();
    }

    /// <summary>
    /// 摄像机自动跟随
    /// </summary>
    private void CameraAutoFollow()
    {
        if (CameraCtrl.Instance == null) return;

        CameraCtrl.Instance.transform.position = gameObject.transform.position;
        CameraCtrl.Instance.AutoLookAt(gameObject.transform.position);

        //if (Input.GetKey(KeyCode.A))
        //{
        //    CameraCtrl.Instance.SetCameraRotate(0);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    CameraCtrl.Instance.SetCameraRotate(1);
        //}
        //else if (Input.GetKey(KeyCode.W))
        //{
        //    CameraCtrl.Instance.SetCameraUpAndDown(0);
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    CameraCtrl.Instance.SetCameraUpAndDown(1);
        //}
        //else if (Input.GetKey(KeyCode.I))
        //{
        //    CameraCtrl.Instance.SetCameraZoom(0);
        //}
        //else if (Input.GetKey(KeyCode.L))
        //{
        //    CameraCtrl.Instance.SetCameraZoom(1);
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("触发了" + other.gameObject.name);
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("触发中" + other.gameObject.name);
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("触发结束" + other.gameObject.name);
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, 3);
    //}
}