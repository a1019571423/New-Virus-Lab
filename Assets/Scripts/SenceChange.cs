using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenceChange : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform thanksFace =  canvas.transform.Find("�����˽���");

        thanksFace.gameObject.SetActive(true);
        
        //canvas.GetComponent<UIEvent>().ProgressBar();
    }
}
