using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public GameObject[] spots;
    public int count = 0, k;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Choose");
    
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
            else if(count<spots.Length-1)
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

            while (CheckingSpot.GetComponent<Onoff>().On != false)
            {
                k = Random.Range(0, spots.Length - 1);
                CheckingSpot = spots[k];
            }

            CheckingSpot.GetComponent<Onoff>().Change();
            count++;
            
        }

    }
  
}
