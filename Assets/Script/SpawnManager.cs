using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject zoomiePrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnZoomies", 10, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnZoomies()
    {
        float spawnPosZ = Random.Range(17, -75);
        Vector3 randomPos = new Vector3(38, 0, spawnPosZ);
        Instantiate(zoomiePrefab, randomPos, zoomiePrefab.transform.rotation);
    }
}
