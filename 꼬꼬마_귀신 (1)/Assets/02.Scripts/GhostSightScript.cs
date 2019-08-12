using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostSightScript : MonoBehaviour
{
    public bool IsInSight;

    public float SightRange = 8f;
    public float SightshortRange = 4f;

    public float NormalSpeed = 2f;
    public float MaxSpeed = 4f;

    public GameObject Player;

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        IsInSight = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SearchInSight_1() && SearchInSight_2())
        {
            IsInSight = true;

            GetComponent<test>().TargetPos = Player.transform;

            SpeedSet();

            Debug.Log("Player in");

        }else if (IsInSight)
        {
            IsInSight = false;

            int temppath = Random.Range(0, GetComponent<test>().pathnum - 1);
            GetComponent<test>().paths = temppath;
            GetComponent<test>().TargetPos = GetComponent<test>().targets[temppath].transform;

            Debug.Log("Player out");
        }
    }

    bool SearchInSight_1()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, SightRange);
        foreach(Collider coll in colls)
        {
            if (coll.tag == "Player")
                return true;
        }

        return false;

    }

    bool SearchInSight_2()
    {
        Vector3 Dir;
        Dir = (Player.transform.position - this.transform.position).normalized;
            
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Dir,out hit, SightRange))
        {
            //Gizmos.color = Color.red;
           // Gizmos.DrawRay(transform.position, Dir * hit.distance);

            if (hit.collider.tag == "Player")
                return true;
        }

        return false;
    }

    void SpeedSet()
    {
        float Dis = Vector3.Distance(transform.position, Player.transform.position);

        if (Dis <= SightshortRange) agent.speed = Mathf.Lerp(agent.speed, MaxSpeed, Time.deltaTime);
        else if (Dis <= SightRange) agent.speed = Mathf.Lerp(agent.speed, NormalSpeed, Time.deltaTime);
    }
}
