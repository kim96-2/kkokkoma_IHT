using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCtrl : MonoBehaviour
{

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Bullet")
        {
            Destroy(coll.gameObject);

            Debug.Log("Wall Hit!");
        }
    }
}