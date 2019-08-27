using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLaaLaaScript : MonoBehaviour
{
    public GameObject laalaa;
    public Transform[] LaaLaaSpots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Appear.count >= 2)
        {
            //Instantiate(laalaa, LaaLaaSpots[Random.Range(0, 3)].position, transform.rotation);

            laalaa.SetActive(true);
            laalaa.transform.position = LaaLaaSpots[Random.Range(0, 3)].position;

            Destroy(this.gameObject);
        }
    }
}
