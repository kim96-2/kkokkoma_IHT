using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onoff : MonoBehaviour
{
    public bool On = false;
    // Start is called before the first frame update

    private void Update()
    {
        if(On)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
            //Debug.Log("On");
            //Debug.Log(this);
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
    public void  Change()
    {
        On = !On;
    }
}
