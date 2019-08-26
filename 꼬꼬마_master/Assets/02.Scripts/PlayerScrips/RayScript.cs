using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    

    RaycastHit hit;
    public float MaxDistance = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.blue, 0.3f);
            if(Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance))
            {
                if (hit.collider.tag == "doors")
                {
                    //Debug.Log("player_door_Hit");
                    hit.collider.gameObject.GetComponent<DoorScript>().ChangeDoorState();
                }
                else if (hit.collider.tag == "StrangeObject")
                {
                    Debug.Log("r_Hit");
                    hit.collider.gameObject.GetComponentInParent<Onoff>().turnoff();
                }
                else if(hit.collider.tag == "cavinets")
                {
                    hit.collider.gameObject.GetComponentInParent<CavinetScript>().ChangeCavinetState();
                }



            }

        }
   
    }
}
