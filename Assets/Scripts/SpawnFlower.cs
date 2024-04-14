using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnFlower : MonoBehaviour
{
    public InputActionProperty InputFire;
    public GameObject bullet;
    public float LifeTime = 10.0f;
    public float TimeDelay = 1.0f;
    private float time = 0.0f;
    public float bulletSpeed = 10.0f;
    public Transform spawnPoint;
    public int spawnCount = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float value = InputFire.action.ReadValue<float>();
        if (value > 0.9 && time > TimeDelay)
        {
            time %= TimeDelay;
            for(int i = 0; i < spawnCount; i++)
            {
                SpawnBullet();
            }
        }
    }
    private void SpawnBullet()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = spawnPoint.transform.position;
        newBullet.GetComponent<Rigidbody>().velocity = (spawnPoint.transform.forward + Random.insideUnitSphere) * bulletSpeed;
        Destroy(newBullet, LifeTime);
    }
    

}
