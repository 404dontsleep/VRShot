using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 1.0f;
    float lastSpawn = 0.0f;
    public float range = 1.0f;

    public GameObject[] entitys;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastSpawn += Time.deltaTime;
        if(lastSpawn >= delay)
        {
            lastSpawn %= delay;
            Spawn();
        }
    }

    void Spawn()
    {
        if(entitys.Length == 0) return;
        GameObject randomEntity = entitys[Random.Range(0, entitys.Length)];
        GameObject spawn = Instantiate(randomEntity);
        spawn.transform.SetParent(transform);
        spawn.transform.position = transform.position;
    }
}
