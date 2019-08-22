using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onoff : MonoBehaviour
{
    public bool On = false;

    public GameObject InactiveObject;
    public GameObject ActiveObject;


    private void Start()
    {
        if(InactiveObject) InactiveObject.SetActive(true);
        if(ActiveObject) ActiveObject.SetActive(false);

    }

    // Start is called before the first frame update
    private void Update()
    {
        if(On)
        {
            if (InactiveObject) InactiveObject.SetActive(false);
            if (ActiveObject) ActiveObject.SetActive(true);
        }
        else
        {
            if (InactiveObject) InactiveObject.SetActive(true);
            if (ActiveObject) ActiveObject.SetActive(false);
        }
    }
    public void  turnoff()
    {
        On = false;
    }
}
