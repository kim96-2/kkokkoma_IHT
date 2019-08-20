using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GunController))]
public class Player : MonoBehaviour
{

    GunController PlayerGunCtrl;

    // 스피드 조정 변수

    [SerializeField] // private의 보안수준을 유지하면서 수정가능
    private float walkSpeed = 10f; //이동속도 설정
    [SerializeField]
    private float runSpeed = 15f;
    private float applySpeed;

    [SerializeField]
    private float jumpForce = 5f;

    // 상태 변수

    private bool isRun = false;
    private bool isGround = true;

    // 땅 착지 여부
    private CapsuleCollider capsuleCollider;

    //플레이어 체력
    public int PlayerHP = 50;
    private float PlayerInvin;
    private MeshRenderer mesh;

    public GameObject UIObj;



    // 민감도
    [SerializeField]
    private float lookSensitivity;

    // 카메라 한계
    [SerializeField]
    private float cameraRotationLimit; //마우스 위로 돌면 고개 360도 회전하는 기이한 현상 방지
    private float currentCameraRotationX = 0f; // 정면을 바라보도록 설정

    //필요한 컴포넌트
    [SerializeField]
    private Camera theCamera;


    private Rigidbody myRigid; // player 몸 설정 (rigidbody 설정하지 않을 경우 충돌판정 x)


    void Start()
    {

        UIObj = GameObject.Find("SPAWNPOINT");

        capsuleCollider = GetComponent<CapsuleCollider>();
        myRigid = GetComponent<Rigidbody>();   //Rigidbody 변수에 삼입     
        applySpeed = walkSpeed;
        PlayerGunCtrl = GetComponent<GunController>();

        PlayerInvin = Time.time;
    }


    void Update()
    {
        IsGround();
        TryJump();
        TryRun(); // 반드시 Move위에 있어야함
        Move();
        CameraRotation();
        CharacterRotation();


        // 총 발사 입력
        if (Input.GetMouseButton(0))
        {
            PlayerGunCtrl.Shoot();
        }
        // 총 재장전 입력
        if (Input.GetKey(KeyCode.R)
         && PlayerGunCtrl.newGun.BulletNow != PlayerGunCtrl.newGun.BulletMax)
        {
            PlayerGunCtrl.Reload();
        }

        if (PlayerHP == 0)
        {
            this.gameObject.SetActive(false);
        }

    }



    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }

    }

    private void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);

    }

    private void Jump()
    {
        myRigid.velocity = transform.up * jumpForce;

    }


    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancel();
        }

    }

    private void Running()
    {
        isRun = true;
        applySpeed = runSpeed;

    }
    private void RunningCancel()
    {
        isRun = false;
        applySpeed = walkSpeed;

    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal"); // 방향설정 좌 우
        float _moveDirZ = Input.GetAxisRaw("Vertical"); // 정면 뒤

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);

    }

    private void CharacterRotation()
    {
        //좌우 캐릭터 회전
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));

    }

    private void CameraRotation()
    {
        // 상하 카메라 회전
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit); // 회전 제한


        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }


    public void TakeDamage()
    {
        if (Time.time > PlayerInvin)
        {
            PlayerHP -= 10;
            PlayerInvin = Time.time + 1.0f;

            Debug.Log("Player is Damaged! PlayerHP : " + PlayerHP);


            StartCoroutine(PlayerInvinVisible(PlayerInvin));
        }
    }
    IEnumerator PlayerInvinVisible(float P_InvinTime)
    {
        while (Time.time <= P_InvinTime)
        {
            this.mesh.material.color = new Color(1f, 1f, 1f, 1f);

            yield return new WaitForSeconds(0.1f);

            this.mesh.material.color = new Color(1f, 0f, 0f, 1f);

            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }
}

