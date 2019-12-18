using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public GameObject point;
    public float movementSpeed;
    // Start is called before the first frame upd

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, point.transform.position,movementSpeed* Time.deltaTime);
    }
}
