using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public GameObject keys;


    public GameObject[] spots;
    public Transform[] keyspots;

    public static int count = 0;

    public int Keynumber = 0;
    int keycount = 0;

    public int k;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Choose");
        StartCoroutine("KeyAppear");
    
    }

    void Update()
    {
        
    }

    IEnumerator Choose()
    {
        while (true)

        {
            if (count < 3)
            {
                yield return new WaitForSeconds(3f);
            }
            else if(count<=spots.Length-1)
            {
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(1f);

                continue;
            }

            k = Random.Range(0, spots.Length-1);
            GameObject CheckingSpot=spots[k];

            /*while (CheckingSpot.GetComponent<Onoff>().On != false)
            {
                k = Random.Range(0, spots.Length - 1);
                CheckingSpot = spots[k];
            }*/
            if(CheckingSpot.GetComponent<Onoff>().On == false)
            {
                //Debug.Log("turn on " + k + "spot");
                CheckingSpot.GetComponentInParent<Onoff>().On = true;
                count++;
                keycount++;
            }
            
            
        }

    }

    IEnumerator KeyAppear()
    {
        while (Keynumber<5)
        {
            yield return new WaitForSeconds(1f);
            if (keycount < 5) continue;
            keycount -= 5;

         

            Debug.Log("Key apear");
            Instantiate(keys, keyspots[Keynumber].position, transform.rotation);

            Keynumber += 1;

        }
    }
}
