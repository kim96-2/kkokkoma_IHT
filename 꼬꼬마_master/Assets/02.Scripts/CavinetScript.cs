using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavinetScript : MonoBehaviour
{

    public bool open = false;
    public float CavinetOpenAngle = 90f;
    public float CavinetCloseAngle = 0f;

    public float smoot = 10;

    public GameObject LeftDoor;
    public GameObject RightDoor;



    public void ChangeCavinetState()
    {
        open = !open;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation;


        if (open)
        {
            targetRotation = Quaternion.Euler(LeftDoor.transform.localRotation.eulerAngles.x, LeftDoor.transform.localRotation.eulerAngles.y, CavinetOpenAngle);
            LeftDoor.transform.localRotation = Quaternion.Slerp(LeftDoor.transform.localRotation, targetRotation, smoot * Time.deltaTime);

            targetRotation = Quaternion.Euler(RightDoor.transform.localRotation.eulerAngles.x, RightDoor.transform.localRotation.eulerAngles.y, CavinetOpenAngle-180);
            RightDoor.transform.localRotation = Quaternion.Slerp(RightDoor.transform.localRotation, targetRotation, smoot * Time.deltaTime);
        }
        else
        {
            targetRotation = Quaternion.Euler(LeftDoor.transform.localRotation.eulerAngles.x, LeftDoor.transform.localRotation.eulerAngles.y, CavinetCloseAngle);
            LeftDoor.transform.localRotation = Quaternion.Slerp(LeftDoor.transform.localRotation, targetRotation, smoot * Time.deltaTime);

            targetRotation = Quaternion.Euler(RightDoor.transform.localRotation.eulerAngles.x, RightDoor.transform.localRotation.eulerAngles.y, CavinetCloseAngle-180);
            RightDoor.transform.localRotation = Quaternion.Slerp(RightDoor.transform.localRotation, targetRotation, smoot * Time.deltaTime);
        }
    }
}
