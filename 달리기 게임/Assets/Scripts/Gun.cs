using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public int BulletMax;           //총알 최대 수
    public int BulletNow;           //현재 총알 수

    public float BetweenShots;      //발사간격 (ms)
    public float ReloadTime;        //재장전 속도 (s)
    public float muzzleVelocity;    //총알 속도 
    public float nextShotTime = 0f;     //총알 발사 간격을 위한 변수
    public float nextReloadTime = 0f;      //총  재장전 간격을 위한 변수

    public bool ReloadValue = false;

    public GameObject Bullet;       //총알 오브젝트
    public Transform muzzle;        //총알 발사 위치

    //총 발사 함수
    public void Shoot()
    {
        if (BulletNow > 0)
        {
            //총알 수가 1개 이상인 경우
            Debug.Log("Bullet now 0 over!");

            if (ReloadValue == false && Time.time > nextShotTime)
            {
                //재장전 시간, 총 발사 간격의 시간이 지난 경우
                nextShotTime = Time.time + BetweenShots / 1000;
                Debug.Log("nextShotTime is" + nextShotTime);

                GameObject newBullet = Instantiate(Bullet, muzzle.position, muzzle.rotation) as GameObject;
                Debug.Log("newBullet is Created!");

                newBullet.GetComponent<Bullet>().SetSpeed(muzzleVelocity);
                Debug.Log("Bullet set speed to " + muzzleVelocity);

                BulletNow -= 1;
                Debug.Log("Bullet now is" + BulletNow);

                Debug.Log("BULLET SHOT Finish!");
            }

        }
        else
        {
            if (ReloadValue == false)
            {
                //총알 수 0개, 재장전하지 않음
                Reload();
                Debug.Log("Bullet is 0. Reload Bullet Start!");
            }
        }
    }

    //총 재장전 함수
    public void Reload()
    {
        nextReloadTime = Time.time + 2;
        ReloadValue = true;
        Debug.Log("Reload Time is " + nextReloadTime);
    }
}