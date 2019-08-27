﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
public class test : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject Player;

    public Transform TargetPos;

    public NavMeshAgent agent;

    public AudioSource footstep;

    public int paths ;
    public int pathnum;
    
    
    // Start is called before the first frame update
    void Start()
    {
        pathnum = targets.Length;
        paths = Random.Range(0, pathnum-1);
        TargetPos = targets[paths].transform;

        Player = GameObject.FindGameObjectWithTag("Player");

        agent = GetComponent<NavMeshAgent>();
        footstep = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(TargetPos.position);
        //footsteps();
    }

    private void OnTriggerEnter(Collider coll)
    {
        //Debug.Log("in");
        if (coll.gameObject == targets[paths])
        {
            
            while (coll.gameObject == targets[paths])
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

   
    void footsteps()
    {
        Debug.Log("speed = " + agent.velocity.sqrMagnitude);
        if (agent.velocity==Vector3.zero)
        {
            
            footstep.Stop();
        }
        else
        {
            footstep.Play();
        }
    }
    
}
