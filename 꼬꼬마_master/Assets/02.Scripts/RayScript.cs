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
                // 앞에 닿으면 F로 상호작용할 수 있음

                hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;

            }

        }
   
    }
}
