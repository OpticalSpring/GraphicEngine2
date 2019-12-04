using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayBackground : MonoBehaviour
{
    public float delaySpawnTime;
    public GameObject railWall;
    public GameObject subwayObject;
    public GameObject spawnPoint;
    public bool spawnState;
    public bool delayDelete;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelaySubwaySpawn());

    }

    // Update is called once per frame
    void Update()
    {
        if(spawnState == false && delayDelete == false)
        {
            railWall.SetActive(false);
        }
    }

    IEnumerator DelaySubwaySpawn()
    {
        while (spawnState == true)
        {
            delayDelete = true;
            GameObject temp = Instantiate(subwayObject);
            temp.transform.position = spawnPoint.transform.position;
            temp.transform.rotation = spawnPoint.transform.rotation;
            yield return new WaitForSeconds(delaySpawnTime);
        }
    }
    
}
