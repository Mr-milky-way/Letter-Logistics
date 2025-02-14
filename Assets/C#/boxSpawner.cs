using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxSpawner : MonoBehaviour
{
    public GameObject Spawner;
    public GameObject BoxPrefab;
    public float TimeNSpawn = 4;
    float time;

    void Update()
    {
        time += Time.deltaTime;
        if (time > TimeNSpawn)
        {
            Instantiate(BoxPrefab, Spawner.transform);
            time = 0;
        }
    }
}
