using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(transform.forward * movementSpeed * Time.deltaTime);
        if(gameObject.transform.position.z < -70)
        {
            GameObject.Find("EventManager").GetComponent<SubwayBackground>().delayDelete = false;
        }
        if (gameObject.transform.position.z < -100)
        {
            Destroy(gameObject);
        }
    }
}
