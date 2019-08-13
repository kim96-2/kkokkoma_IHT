using System.Collections;
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

    protected Camera[] cameras;

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
    }

    void incCamera()
    {
        cameras[CurrentCamera].enabled = false;

        CurrentCamera = CurrentCamera + 1;

        if (CurrentCamera > 5)
        {
            CurrentCamera = 0;
        }

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            GoCamera();
            if (Current == 0)
            {
                Current = 1;
            }
            else if (Current == 1)
            {
                Current = 0;
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
