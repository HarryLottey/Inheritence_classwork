using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform target;
    public Transform[] spawnPos;
    public GameObject[] enemyType;
    public float spawnDelay = 5f * Time.deltaTime;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Spawn(spawnDelay));
    }

    // Update is called once per frame
    void Update()
    {
        spawnDelay -= 0.05f;
    }

    IEnumerator Spawn(float delay)
    {
        while (true)
            for (int i = 0; i < enemyType.Length; i++) // Loop through the different prefabs
            {
                GameObject clone = Instantiate(enemyType[Random.Range(0, enemyType.Length)]);
                clone.transform.position = spawnPos[Random.Range(0, spawnPos.Length)].transform.position;
                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.target = target;

                //         GameObject clone = Instantiate(enemyType[0], spawnPos[Random.Range(0, spawnPos.Length)]);
                //     Enemy enemy = clone.GetComponent<Enemy>();
                //    enemy.target = target;
                yield return new WaitForSeconds(delay);
            }




    }
}
