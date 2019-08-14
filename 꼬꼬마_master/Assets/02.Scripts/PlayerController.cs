using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    // 스피드 조정 변수

    [SerializeField] // private의 보안수준을 유지하면서 수정가능
    private float walkSpeed; //이동속도 설정
    [SerializeField]
    private float runSpeed;
    private float applySpeed;

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


    private Rigidbody myRigid; // player 몸 설정 (rigidbody 설정하지 않을 경우 충돌판정 x)


    void Start()
    {

        myRigid = GetComponent<Rigidbody>();   //Rigidbody 변수에 삼입     
        applySpeed = walkSpeed;
    }


    void Update()
    {
        TryRun(); // 반드시 Move위에 있어야함
        Move();
        CameraRotation();
        CharacterRotation();


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

}
