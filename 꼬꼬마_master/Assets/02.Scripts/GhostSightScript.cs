using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostSightScript : MonoBehaviour
{
    public bool IsInSight;

    public float SightRange = 8f;
    public float SightshortRange = 4f;
    public float SightDis = 6f;//원형 시아 중심을 앞으로 보내 진짜 시아처럼 만들기 위한 변수

    public float NormalSpeed = 2f;
    public float FollowSpeed = 2f;
    public float MaxSpeed = 4f;

    public GameObject Player;

    public NavMeshAgent agent;

    public Transform GhostHeadPos;

    // Start is called before the first frame update
    void Start()
    {
        IsInSight = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = NormalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (SearchInSight_1() && SearchInSight_2())//플레이어가 시아에 있을때
        {
            IsInSight = true;

            GetComponent<test>().TargetPos = Player.transform;

            SpeedSet();

            Debug.Log("Player in");

        }else if (IsInSight)//플레이어가 시아에서 없어졌을때
        {
            IsInSight = false;

            agent.speed = NormalSpeed;//기본속도로 설정

            //다른 경로 찾기
            int temppath = Random.Range(0, GetComponent<test>().pathnum - 1);
            GetComponent<test>().paths = temppath;
            GetComponent<test>().TargetPos = GetComponent<test>().targets[temppath].transform;

            Debug.Log("Player out");
        }
    }

    bool SearchInSight_1()//플레이어가 시아 콜라이더에 있는지 확인
    {
        Collider[] colls = Physics.OverlapSphere(GhostHeadPos.position+Vector3.forward*SightDis, SightRange);
        foreach(Collider coll in colls)
        {
            if (coll.tag == "Player")
                return true;
        }
        colls = Physics.OverlapSphere(GhostHeadPos.position, 4f);//시아에 별개로 플레이어가 가까이 있을때를 확인
        foreach (Collider coll in colls)
        {
            if (coll.tag == "Player")
                return true;
        }

        return false;

    }

    bool SearchInSight_2()//플레이어가 가려져 있는지 확인
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

    void SpeedSet()//시야 조절 함수
    {
        float Dis = Vector3.Distance(transform.position, Player.transform.position);

        if (Dis <= SightshortRange) agent.speed = Mathf.Lerp(agent.speed, MaxSpeed, Time.deltaTime);
        else if (Dis <= SightRange) agent.speed = Mathf.Lerp(agent.speed, FollowSpeed, Time.deltaTime);
    }
}
