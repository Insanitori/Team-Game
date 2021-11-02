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
        float spawnPosX = Random.Range(8, 95);
        Vector3 randomPos = new Vector3(spawnPosX, 0, -3);
        Instantiate(zoomiePrefab, randomPos, zoomiePrefab.transform.rotation);
    }
}
