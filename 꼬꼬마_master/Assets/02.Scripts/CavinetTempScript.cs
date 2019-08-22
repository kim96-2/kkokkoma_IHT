using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavinetTempScript : MonoBehaviour
{
    public bool open = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
