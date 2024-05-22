using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class MouseScript : MonoBehaviour
{
    // Start is called before the first frame update

    NavMeshAgent agent;
    Transform target = null;
    public int maxHealth = 3;
    private Canvas healthBar = null;
    private Slider healthSlider = null;
    public AudioSource destroySound = null;
    private int health = 0;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        healthSlider = GetComponentInChildren<Slider>();
        healthBar = GetComponentInChildren<Canvas>();
    }
    void Start()
    {
        health = maxHealth;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cake"))
        { 
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (destroySound != null) destroySound.Play();
            health--;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
                GameScore.instance.AddScore(1);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {   
        if (healthSlider != null)
        {
            healthSlider.value = (float)health / (float)maxHealth;
        }

        GameObject[] cakes = GameObject.FindGameObjectsWithTag("Cake");

        float shortestDistance = Mathf.Infinity;
        GameObject nearestCake = null;

        // Iterate through all cake objects to find the nearest one
        foreach (GameObject cake in cakes)
        {
            float distance = Vector3.Distance(transform.position, cake.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestCake = cake;
            }
        }

        // If a nearest cake is found, move towards it
        if (nearestCake != null && Vector3.Distance(nearestCake.transform.position, transform.position) <= 10)
        {
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(nearestCake.transform.position);
            target = nearestCake.transform;
        }
        else
        {
            agent = GetComponent<NavMeshAgent>();
            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(RandomPoint());
            }
        }

        if (healthBar != null)
        {
            healthBar.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
    }
    
    public Vector3 RandomPoint()
    {
        float walkRadius = 10f;
        Vector3 pos = Vector3.zero;
        Vector3 random = Random.insideUnitSphere * walkRadius;
        random += transform.position;
        if(NavMesh.SamplePosition(random, out NavMeshHit hit, walkRadius, 1))
        {
            pos = hit.position;
        }
        return pos;
    }
}
