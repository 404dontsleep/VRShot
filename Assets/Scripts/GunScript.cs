using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunScript : MonoBehaviour
{
    public Transform SpawnBulletPoint;
    public GameObject BulletObject;
    public InputActionProperty ShotActionProperty;

    public float DelayShot = 0.1f;
    public float BulletSpeed = 1.0f;
    private float TimeCounter = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeCounter += Time.deltaTime;
        if (ShotActionProperty != null)
        {
            float value = ShotActionProperty.action.ReadValue<float>();
            if (value > 0.9f && TimeCounter >= DelayShot)
            {
                TimeCounter %= DelayShot;
                Shot();
            }
        }
        
    }

    void Shot()
    {
        if (SpawnBulletPoint != null && BulletObject != null)
        {
            GameObject bullet = Instantiate(BulletObject);
            bullet.transform.SetPositionAndRotation(SpawnBulletPoint.position, SpawnBulletPoint.rotation);
            if (bullet.GetComponent<Rigidbody>() != null)
            {
                bullet.GetComponent<Rigidbody>().velocity = SpawnBulletPoint.transform.forward * BulletSpeed;
            }
            Destroy(bullet, 10);
        }
    }
}
