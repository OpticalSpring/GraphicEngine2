using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Material map1;
    public Material map2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Flash());
    }
   

    IEnumerator Flash()
    {
        while (true)
        {
            for (int i = 0; i < Random.Range(5, 20); i++)
            {
            FlashOff();
            yield return new WaitForSeconds(Random.Range(0,0.3f));
            FlashOn();
            yield return new WaitForSeconds(Random.Range(0,0.6f));
            }
            yield return new WaitForSeconds(Random.Range(5f, 20f));
        }
    }

    void FlashOn()
    {
        gameObject.GetComponent<MeshRenderer>().material = map1;
       // gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.GetComponent<Light>().enabled = true;
    }

    void FlashOff()
    {
        gameObject.GetComponent<MeshRenderer>().material = map2;
       // gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(0).gameObject.GetComponent<Light>().enabled = false;
    }
}
