using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZ : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject zombbie;
    float spawntime;
    float lasttimespawn;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectsWithTag("Zombie");
        UpdateSpawnTime();
    }

    void UpdateSpawnTime()
    {
        lasttimespawn = Time.time;
        spawntime = 3f;
    }
    void Spawn()
    {
        int point = Random.Range(0, spawnPoint.Length);
        Instantiate(zombbie,spawnPoint[point].transform.position,Quaternion.identity);
        UpdateSpawnTime();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > lasttimespawn + spawntime)
        {
            Spawn();
        }
    }
}
