using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCtrl : MonoBehaviour
{

    public GameObject[] SpawnPool;
    public List<GameObject> EnemyPool = new List<GameObject>();
    public GameObject EnemyPrefabs;

    private float createTime = 2.0f;
    private Player playerCs;

    // Use this for initialization
    void Start()
    {
        playerCs = GameObject.FindWithTag("Player").GetComponent<Player>();

        for (int i = 0; i < 10; i++)
        {
            GameObject Enemy = (GameObject)Instantiate(EnemyPrefabs);
            Enemy.name = "Enemy_" + i.ToString();
            Enemy.SetActive(false);
            EnemyPool.Add(Enemy);
        }

        SpawnPool = GameObject.FindGameObjectsWithTag("Respawn");

        StartCoroutine(this.CreateEnemy());
    }

    IEnumerator CreateEnemy()
    {
        Debug.Log("Start CreateEnemy Coroutine!");
        while (playerCs.PlayerHP != 0)
        {
            yield return new WaitForSeconds(createTime);

            Debug.Log("Start CreateEnemy Coroutine! 1");

            if (playerCs.PlayerHP == 0) yield break;

            Debug.Log("Start CreateEnemy Coroutine! 2");

            foreach (GameObject Enemy in EnemyPool)
            {
                Debug.Log("Start CreateEnemy Coroutine! roop");
                if (!Enemy.activeSelf)
                {
                    int idx = Random.Range(1, SpawnPool.Length);
                    Enemy.transform.position = SpawnPool[idx].transform.position;
                    Enemy.SetActive(true);
                    Debug.Log("Create Enemy : " + Enemy.name);

                    break;
                }
            }

            yield return null;
        }
    }
}