using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayScript : MonoBehaviour
{
    public Text CountText;
    RaycastHit hit;
    public float MaxDistance = 5.0f;
    public int KeyNumber = 0;


    // Start is called before the first frame update
    void Start()
    {
        //CountText = GameObject.Find("CountText");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.blue, 0.3f);
            if(Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance))
            {
                if (hit.collider.tag == "doors")
                {
                    //Debug.Log("player_door_Hit");
                    hit.collider.gameObject.GetComponent<DoorScript>().ChangeDoorState();
                }
                else if (hit.collider.tag == "StrangeObject")
                {

                    if (hit.collider.gameObject.GetComponentInParent<Onoff>() == true)
                    {
                        hit.collider.gameObject.GetComponentInParent<Onoff>().turnoff();
                        Appear.count -= 1;
                    }
                    
                }
                else if(hit.collider.tag == "cavinets")
                {
                    hit.collider.gameObject.GetComponentInParent<CavinetScript>().ChangeCavinetState();
                }

                else if(hit.collider.tag == "Key")
                {

                    Destroy(hit.collider.gameObject);
                    KeyNumber += 1;

                    //CountText.SendMessage("CountUp");
                    
                }

                else if((hit.collider.tag == "FinalDoor") && (CountUI.count == 5))
                {

                    hit.collider.gameObject.GetComponent<DoorScript>().ChangeDoorState();

                }
                else if(hit.collider.tag == "StartPresent")
                {
                    hit.collider.gameObject.GetComponent<GameStartScript>().On = true;
                }



            }

        }

        CountText.text= "Count is :" + KeyNumber ;

    }
}
