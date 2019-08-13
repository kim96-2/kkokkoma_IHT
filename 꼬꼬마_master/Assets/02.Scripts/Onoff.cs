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
            Debug.Log("On");
            Debug.Log(this);
        }
    }
    public void  Change()
    {
        On = !On;
    }
}
