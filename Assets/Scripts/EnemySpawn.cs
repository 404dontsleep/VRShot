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

    public GameObject entity;
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
        if (GameObject.FindWithTag("Cake") == null)
        {
            ScoreManager.instance.AddScore(GameScore.instance.GetScore());
            SceneManager.LoadScene("ScoreBoard");
        }
    }

    void Spawn()
    {
        if(entity == null) return;
        GameObject spawn = Instantiate(entity);
        spawn.transform.SetParent(transform);
        spawn.transform.position = transform.position;
    }
}
