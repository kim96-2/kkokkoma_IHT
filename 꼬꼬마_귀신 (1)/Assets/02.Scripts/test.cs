using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{
    public GameObject[] targets = new GameObject[7];
    public GameObject Player;

    public Transform TargetPos;

    public NavMeshAgent agent;

    public int paths ;
    public int pathnum;
    
    
    // Start is called before the first frame update
    void Start()
    {
        paths = Random.Range(0, pathnum-1);
        TargetPos = targets[paths].transform;

        Player = GameObject.FindGameObjectWithTag("Player");

        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(TargetPos.position);
    }

    private void OnTriggerEnter(Collider coll)
    {
        //Debug.Log("in");
        if (coll.gameObject.name == targets[paths].name)
        {
            
            while (coll.gameObject.name == targets[paths].name)
            {
                paths = Random.Range(0, pathnum-1);
            }
            Invoke("ChangeTarget", Random.Range(2f,4f));
        }

        /*//최종 문함수 보고 수정해야함
        if (coll.tag == "doors")
        {
            coll.gameObject.GetComponentInParent<DoorScript>().open = true;
            Debug.Log("out");
        }*/
        
    }

    void ChangeTarget()
    {
        TargetPos = targets[paths].transform;
    }

   

    
}
