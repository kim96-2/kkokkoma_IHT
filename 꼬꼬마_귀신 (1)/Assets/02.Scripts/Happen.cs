using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happen : MonoBehaviour

{
    private float time;
    public GameObject[] spots;
    int idx;

    // Start is called before the first frame update

    private void Awake()
    {
        time = 0f;
    }

    void Start()
    {
        StartCoroutine("SpawnEnemy");
        

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {

            idx = Random.Range(0, spots.Length);
            GameObject pt = spots[idx];

            //if(pt.GetComponent<routinehappen>().on==false)
            pt.GetComponent<routinehappen>().Onoff();

            int t = Random.Range(0, 3);
            yield return new WaitForSeconds(t);
        }
    }


}