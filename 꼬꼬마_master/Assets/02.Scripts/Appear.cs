using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public GameObject[] spots;
    int count = 0, k;
    int[] array= new int[100];
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Choose");

    
    }

    IEnumerator Choose()

    {
        while (count<7)

        {
            if (count < 3)
            {
                yield return new WaitForSeconds(3f);
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
                k = Random.Range(0, spots.Length);
                GameObject pt = spots[k];
                if (array[k] != 1)
                {
                    pt.GetComponent<Onoff>().Change();
                    array[k] = 1;
                    count++;
                }
            
        }

    }


    // Update is called once per frame
  
}
