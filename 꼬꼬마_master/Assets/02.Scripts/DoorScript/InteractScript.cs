using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public float interactDistance = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.tag=="doors")
            {
                //Debug.Log("player_door_Hit");
                hit.collider.gameObject.GetComponentInParent<DoorScript>().ChangeDoorState();
            }
        } 
    }
}
