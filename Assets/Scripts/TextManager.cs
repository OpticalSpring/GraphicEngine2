using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextManager : MonoBehaviour
{
    public GameObject panel;
    public bool textProceeding;
    

    public void SetTextUp(Sprite image, float delayTime)
    {
        panel.SetActive(true);
        panel.GetComponent<Image>().sprite = image;
        panel.GetComponent<Image>().SetNativeSize();
        textProceeding = true;
        StartCoroutine(DelayOff(delayTime));
    }

    IEnumerator DelayOff(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        panel.SetActive(false);
        textProceeding = false;
    }
}
