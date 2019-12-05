using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public int eventNumber;
    public bool eventProceeding;


    public GameObject player;
    public GameObject[] checkPos;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        EventCheck();
    }

    void EventCheck()
    {
        if (eventProceeding == false)
        {
            switch (eventNumber)
            {
                case 0:
                    StartCoroutine(Event_0());
                    break;
                case 1:
                    if (Vector3.Distance(player.transform.position, checkPos[0].transform.position) < 2)
                    {
                        StartCoroutine(Event_1());
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
    }

    

    IEnumerator Event_0()
    {
        eventNumber++;
        eventProceeding = true;
        yield return new WaitForSeconds(6);
        eventProceeding = false;
    }
    IEnumerator Event_1()
    {
        eventNumber++;
        eventProceeding = true;
        yield return new WaitForSeconds(3);
        //sound_eff.enabled = true;
        yield return new WaitForSeconds(3);
        yield return new WaitForSeconds(3);
        yield return new WaitForSeconds(3);
        yield return new WaitForSeconds(3);
        eventProceeding = false;
    }
    IEnumerator Event_2()
    {
        yield return new WaitForSeconds(0);
    }
    IEnumerator Event_3()
    {
        yield return new WaitForSeconds(0);
    }
    IEnumerator Event_4()
    {
        yield return new WaitForSeconds(0);
    }
}
