using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class routinehappen : MonoBehaviour
{
    // Start is called before the first frame update
    public bool on = false;

    void Start()
    {

    }
    void Update ()
    {
        if (on)
        {
            Debug.Log("changed");
        }
    }
    void Check()
    {
       
    }
    public void Onoff()
    {
        on =!on;
    }

}
