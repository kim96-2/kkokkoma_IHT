using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostDoorOpenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetComponent<NavMeshAgent>().velocity.magnitude);
    }

    private void OnTriggerEnter(Collider coll)
    {
        
        //최종 문함수 보고 수정해야함
        if (coll.tag == "doors")
        {
            coll.gameObject.GetComponentInParent<DoorScript>().open = true;
            //Debug.Log("out");
        }else if(coll.tag == "cavinets")
        {
            if (GetComponent<NavMeshAgent>().velocity.magnitude == 0 && GetComponent<test>().TargetPos.tag != "Player")
            {
                if (Random.Range(0f, 10f) < 5f)
                {
                    Debug.Log("Open cavinet");
                    StartCoroutine(OpenCavinet(coll));
                }
            }
        }

    }

    IEnumerator OpenCavinet(Collider coll)
    {

        //스크립트 변경 예정(CavinetTempScript)
        if (coll.gameObject.GetComponent<CavinetTempScript>().open == true) yield break;
        else
        {
            yield return new WaitForSeconds(1f);
            
            
            coll.gameObject.GetComponent<CavinetTempScript>().open = true;
        }

        yield break;
    }
}
