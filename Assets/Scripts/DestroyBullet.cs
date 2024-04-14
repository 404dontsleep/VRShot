using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> FlowerList;
    public float LifeTime = 10.0f;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Plane"))
    //    {
    //        SpawnFlower_(gameObject.transform.position);
    //        Destroy(gameObject);
    //    }
    //}
    private void SpawnFlower_(Vector3 position)
    {
        GameObject flower = Instantiate(FlowerList[Random.Range(0, FlowerList.Count)]);
        flower.transform.position = new Vector3(position.x, 0.1f, position.z);
        flower.transform.localScale = Vector3.one * 3.0f;
        Destroy(flower, LifeTime);
    }
}
