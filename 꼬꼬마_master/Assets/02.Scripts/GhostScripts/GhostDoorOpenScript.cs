using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostDoorOpenScript : MonoBehaviour
{

    public bool CabinetChecking = false;

    public float plusOpenOc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetComponent<NavMeshAgent>().velocity.magnitude);
        //if (Mathf.Abs(GetComponent<NavMeshAgent>().velocity.magnitude) < 0.1f) Debug.Log("low speed");
        //else Debug.Log("high speed");

        if (GetComponent<test>().TargetPos.tag == "Player") CabinetChecking = false;
    }

    private void OnTriggerEnter(Collider coll)
    {
        
        //최종 문함수 보고 수정해야함
        if (coll.tag == "doors")
        {
            coll.gameObject.GetComponentInParent<DoorScript>().open = true;
        }else if(coll.tag == "cavinets")
        {
            if (Appear.count < 5)
            {
                plusOpenOc = 0f;
            }
            else if (Appear.count < 10)
            {
                plusOpenOc = 1.5f;
            }
            else
            {
                plusOpenOc = 4f;
            }
            if (GetComponent<test>().TargetPos.tag != "Player")
            {//Mathf.Abs(GetComponent<NavMeshAgent>().velocity.magnitude) < 0.1f && GetComponent<test>().TargetPos.tag != "Player"
                if (!CabinetChecking)
                {

                    CabinetChecking = true;

                    if (Random.Range(0f, 10f) < 5f+plusOpenOc)
                    {

                        StartCoroutine(OpenCavinet(coll));
                    }

                }
            }
        }

    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "cavinets") CabinetChecking = false;
    }

    IEnumerator OpenCavinet(Collider coll)
    {

        //스크립트 변경 예정(CavinetTempScript)
        if (coll.gameObject.GetComponentInParent<CavinetScript>().open == true) yield break;
        else
        {
            yield return new WaitForSeconds(2f);
            
            
            coll.gameObject.GetComponentInParent<CavinetScript>().open = true;
        }

        yield break;
    }
}
