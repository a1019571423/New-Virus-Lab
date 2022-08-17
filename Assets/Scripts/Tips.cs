using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    public GameObject tipsFace;
    public GameObject tips;
    private void OnTriggerStay2D(Collider2D collision)
    {
        tips.SetActive(true);
        if (Input.GetKeyDown(KeyCode.T))
        {
            tipsFace.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tips.SetActive(false);
    }
}
