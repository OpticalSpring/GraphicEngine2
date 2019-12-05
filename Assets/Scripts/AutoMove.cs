using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AuraAPI;

public class AutoMove : MonoBehaviour
{
    public float movementSpeed;
    public GameObject[] aura;
    // Start is called before the first frame update
    void Start()
    {
        aura[0].GetComponent<AuraLight>().enabled = true;
        aura[1].GetComponent<AuraLight>().enabled = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(transform.forward * movementSpeed * Time.deltaTime);
        if (gameObject.transform.position.z < -100)
        {
            Destroy(gameObject);
        }
    }
}
