using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    public Camera player;
    public Camera camera_1F_1;
    public Camera camera_1F_2;
    public Camera camera_1F_3;
    public Camera camera_2F_1;
    public Camera camera_2F_2;
    public Camera camera_2F_3;

    public Text CameraText;
    protected Camera[] cameras;

    private int First=0;

    public int CurrentCamera;
    public int Current;

    private void Awake()
    {
        cameras = new Camera[6];

        cameras[0] = camera_1F_1;
        cameras[1] = camera_1F_2;
        cameras[2] = camera_1F_3;
        cameras[3] = camera_2F_1;
        cameras[4] = camera_2F_2;
        cameras[5] = camera_2F_3;

    }

    // Start is called before the first frame update
    void Start()
    {
        Current = 0;
        CurrentCamera = 0;
        player.enabled = true;
        cameras[0].enabled = false;
        cameras[1].enabled = false;
        cameras[2].enabled = false;
        cameras[3].enabled = false;
        cameras[4].enabled = false;
        cameras[5].enabled = false;
        Text();
    }

    void incCamera()
    {
        cameras[CurrentCamera].enabled = false;

        CurrentCamera = CurrentCamera + 1;

        if (CurrentCamera > 5)
        {
            CurrentCamera = 0;
        }
        Text();
        cameras[CurrentCamera].enabled = true;
    }

    void decCamera()
    {
        cameras[CurrentCamera].enabled = false;

        CurrentCamera = CurrentCamera - 1;

        if (CurrentCamera < 0)
        {
            CurrentCamera = 5;
        }
        Text();
        cameras[CurrentCamera].enabled = true;
    }

    void GoCamera()
    {

        if (Current == 0)
        {
            player.enabled = false;
            
            cameras[CurrentCamera].enabled = true;
        }
        if (Current == 1)
        {
            cameras[CurrentCamera].enabled = false;
            
            player.enabled = true;
        }

    }

    void Text()
    {
        if (CurrentCamera==0)
        {
            CameraText.text = "1F_Living_Room";
        }
        if (CurrentCamera==1)
        {
            CameraText.text = "1F_Kitchen";
        }
        if (CurrentCamera==2)
        {
            CameraText.text = "1F_Room";
        }
        if (CurrentCamera==3)
        {
            CameraText.text = "2F_Room1";
        }
        if (CurrentCamera==4)
        {
            CameraText.text = "2F_Room2";
        }
        if(CurrentCamera==5)
        {
            CameraText.text = "2F_Hallway";
        }
        if(Current==0)
        {
            CameraText.text = " ";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            GoCamera();
            if (Current == 0)
            {
                Current = 1;
                Text();
            }
            else if (Current == 1)
            {
                Current = 0;
                Text();
            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (Current == 1)
            {
                incCamera();
            }

        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (Current == 1)
            {
                decCamera();
            }
        }
    }
}
