using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public GameObject waypoint;
    public GameObject lookpoint;
    int waypointNum;
    int nowNum;
    public float movementSpeed;
    public float rotateSpeed;    // Start is called before the first frame update
    void Start()
    {
        waypointNum = waypoint.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(nowNum == waypointNum)
        {
            return;
        }
        if (Vector3.Distance(gameObject.transform.position, waypoint.transform.GetChild(nowNum).position) < 0.3f)
        {
            nowNum++;
        }

        Vector3 nePos = lookpoint.transform.GetChild(nowNum).position - gameObject.transform.position;
        Vector3 look = Vector3.Slerp(gameObject.transform.forward, nePos.normalized, rotateSpeed*Time.deltaTime);
        gameObject.transform.rotation = Quaternion.LookRotation(look, Vector3.up);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, waypoint.transform.GetChild(nowNum).position, movementSpeed * Time.deltaTime);
    }
}
