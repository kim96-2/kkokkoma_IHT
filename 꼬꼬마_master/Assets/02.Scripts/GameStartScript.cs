using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScript : MonoBehaviour
{
    public bool On;
    public GameObject System;
    // Start is called before the first frame update
    void Start()
    {
        On = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (On)
        {
            System.SetActive(true);

            Destroy(this.gameObject);
        }
    }
}
