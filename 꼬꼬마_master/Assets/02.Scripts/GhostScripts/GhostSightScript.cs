using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostSightScript : MonoBehaviour
{
    public bool IsInSight;

    public float SightAngle=60f;
    public float SightRange = 8f;
    public float SightshortRange = 4f;
    public float SightDis = 6f;//원형 시아 중심을 앞으로 보내 진짜 시아처럼 만들기 위한 변수

    public float NormalSpeed = 2f;
    public float FollowSpeed = 2f;
    public float MaxSpeed = 4f;
    

    public GameObject Player;

    public NavMeshAgent agent;

    public Transform GhostHeadPos;

    Vector3 Dir;//플레이어와 귀신의 방향

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
        
        Dir = (Player.transform.position - GhostHeadPos.position).normalized;

        if (SearchInSight_1() && SearchInSight_2())//플레이어가 시아에 있을때
        {
            IsInSight = true;

            GetComponent<test>().TargetPos = Player.transform;

            SpeedSet();


        }else if (IsInSight)//플레이어가 시아에서 없어졌을때
        {
            IsInSight = false;

            agent.speed = NormalSpeed;//기본속도로 설정

            //플레이어와 가장 가까운 경로 찾기
            float pathDis = 10000f;
            int tempPath = 0;
            

            for(int i = 0; i < GetComponent<test>().pathnum-1; i++)
            {
                if((Player.transform.position- GetComponent<test>().targets[i].transform.position).sqrMagnitude < pathDis)
                {
                    tempPath = i;
                    pathDis = (Player.transform.position - GetComponent<test>().targets[i].transform.position).sqrMagnitude;
                }
            }
            GetComponent<test>().paths = tempPath;
            GetComponent<test>().TargetPos = GetComponent<test>().targets[tempPath].transform;

        }
    }

    bool SearchInSight_1()//플레이어가 시아 콜라이더에 있는지 확인
    {
        //시야각 사용하여 시야에 있는지 확인
        float Dot = Vector3.Dot(Dir, transform.forward);
        float Angle = Mathf.Acos(Dot)*Mathf.Rad2Deg;

        if (Angle < SightAngle) return true;


        //시아에 별개로 플레이어가 가까이 있을때를 확인
        Collider[] colls;
        colls = Physics.OverlapSphere(GhostHeadPos.position, 8f);
        foreach (Collider coll in colls)
        {
            if (coll.tag == "Player")
                return true;
        }

        return false;

    }

    bool SearchInSight_2()//플레이어가 가려져 있는지 확인
    {
        
            
        RaycastHit hit;
        if(Physics.Raycast(GhostHeadPos.position,Dir,out hit, 50f))
        {
            //Debug.Log("tag = " + hit.collider.tag);
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
