using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayBackground : MonoBehaviour
{
    public float delaySpawnTime;
    public GameObject subwayObject;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelaySubwaySpawn());
    }
    

    IEnumerator DelaySubwaySpawn()
    {
        while (true)
        {
            GameObject temp = Instantiate(subwayObject);
            temp.transform.position = spawnPoint.transform.position;
            temp.transform.rotation = spawnPoint.transform.rotation;
            yield return new WaitForSeconds(delaySpawnTime);
        }
    }
    
}
