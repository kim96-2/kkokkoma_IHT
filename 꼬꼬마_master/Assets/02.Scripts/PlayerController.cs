using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 스테미너 
    [SerializeField]
    private float health;

    // 스피드 조정 변수

    [SerializeField] // private의 보안수준을 유지하면서 수정가능
    private float walkSpeed; //이동속도 설정
    [SerializeField]
    private float runSpeed;
    private float applySpeed;
    private float gravity = 20; //캐릭터 컨트롤러에서는 중력을 임의로 만들어야됨

    // 이동 뱡향을 위한 벡터

    private Vector3 MoveDir;
    
    
    // 상태 변수

    private bool isRun = false;



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


    //private Rigidbody myRigid; // player 몸 설정 (rigidbody 설정하지 않을 경우 충돌판정 x)
    private CharacterController PlayerCon;



    void Start()
    {

        //myRigid = GetComponent<Rigidbody>();   //Rigidbody 변수에 삼입     
        PlayerCon = GetComponent<CharacterController>();//캐릭터 컨트롤러 가져옴
        applySpeed = walkSpeed;
    }


    void Update()
    {
        CameraRotation();
        CharacterRotation();
        TryRun(); // 반드시 Move위에 있어야함
        Move();
        

    }
    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift) && health > 0)
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
        if (health > 0)
        {
            health -= 0.01f;
        }
        applySpeed = runSpeed;

    }
    private void RunningCancel()
    {
        isRun = false;
        if (health < 100) {
            health += 0.01f;
        }
        applySpeed = walkSpeed;

    }

    private void Move()
    {
        if (PlayerCon.isGrounded)//플레이어가 땅위에 있을때 (캐릭터 컨트롤러 때문)
        {
            float _moveDirX = Input.GetAxisRaw("Horizontal"); // 방향설정 좌 우
            float _moveDirZ = Input.GetAxisRaw("Vertical"); // 정면 뒤

            Vector3 _moveHorizontal = transform.right * _moveDirX;
            Vector3 _moveVertical = transform.forward * _moveDirZ;

            MoveDir = (_moveHorizontal + _moveVertical).normalized * applySpeed;

        }

        MoveDir.y -= gravity;//중력 구현 대신 가속도 없음

        PlayerCon.Move(MoveDir * Time.deltaTime);//캐릭터 컨트롤러를 사용한 움직임
    }

    private void CharacterRotation()
    {
        //좌우 캐릭터 회전
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;

        transform.Rotate(_characterRotationY);
        //myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));

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

}
