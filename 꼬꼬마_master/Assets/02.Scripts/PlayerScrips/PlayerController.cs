using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 서브 카메라 전환시 플레이어 이동 금지 구현

    public  static bool Player_Convert = false;


    // 스피드 조정 변수


    public float walkSpeed = 8; //이동속도 설정 
    public float runSpeed = 15;
    public float applySpeed;
    private float gravity = 20; //캐릭터 컨트롤러에서는 중력을 임의로 만들어야됨
   
    
    // 스테미너 
    [SerializeField]
    private float health = 100 , maxhealth = 100;

    Rect healthRect;
    Texture2D healthTexture;



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

        healthRect = new Rect(Screen.width / 10, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 50);
        healthTexture = new Texture2D(1, 1);
        healthTexture.SetPixel(0, 0, Color.white);
        healthTexture.Apply();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) || (Input.GetKeyDown(KeyCode.P)))
        {
           //처음 C를 누른 경우
           if(Player_Convert == false)
            {
                Player_Convert = true;

            }
           //두번째로 C를 누른 경우
            else
            {
                Player_Convert = false;
            }

        }
        //Camera_Speed();<-이함수 먼저 지워놈

        TryRun(); // 반드시 Move위에 있어야함

        if (!Player_Convert)
        {
            CameraRotation();
            CharacterRotation();
            Move();
        }
        
        

    }


    /*private void Camera_Speed()
    {
        if(Player_Convert == true)
        {
            walkSpeed = 0;
            runSpeed = 0;

        }
        else
        {
            walkSpeed = 8;
            runSpeed = 15;
        }

    }*/

    private void TryRun()
    {

        //스테미나 구현 수정본. 생각보다 까다로운거여서 else말고 안에 else를 한개 더 만들어야됨
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(health > 0)
                Running();
            else
            {
                isRun = false;
                applySpeed = walkSpeed;
            }
        }
        else
            RunningCancel();

    }

    private void Running()
    {
        isRun = true;
        if (health > 0)
        {
            health -= 0.2f;
        }
        applySpeed = runSpeed;

    }
    private void RunningCancel()
    {
        isRun = false;
        if (health < 100) {
            health += 0.2f;
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


    void OnGUI()
    {

        float ratio = health / maxhealth;
        float rectWidth = ratio * Screen.width / 3;
        healthRect.width = rectWidth;
        GUI.DrawTexture(healthRect, healthTexture);

    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "ghost")
        {
            GameOverCheckScene.GameOverCheck = 1;
        }
        else if (coll.tag == "ClearSpot")
        {
            GameOverCheckScene.GameOverCheck = 2;
        }
    }

}
