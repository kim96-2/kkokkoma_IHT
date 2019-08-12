using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorScript : MonoBehaviour
{
    public bool open = false;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float doorFirstAngele;
    public float smoot = 2f;
void Start()
    {
        //doorFirstAngele = transform.localRotation.y;
    }
    public void ChangeDoorState()
    {
        open = !open;
    }
    void Update()
    {
        if (open)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle + doorFirstAngele, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
        }
        else { Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle + doorFirstAngele, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smoot * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        //if (coll.gameObject.tag == "ghost")
        //open = true;
        //Debug.Log("In");
    }
}





