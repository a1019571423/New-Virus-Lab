using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIEvent : MonoBehaviour
{
    public GameObject tipsFace;
    public GameObject menuFace;
    public GameObject hint;
    public Transform cam;
    public GameObject volumeFace;
    public GameObject player;
    float hpVolue;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public GameObject gameOver;
    //public GameObject bluebt;
    //public GameObject yellowbt;
    //public GameObject purplebt;

    private void Update()
    {
        HpChange();
        if (hpVolue == 0)
        {
            DisGameOver();
        }
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void ExitTips()
    {
        tipsFace.SetActive(false);
    }

    public void DispalyMenu()
    {
        Time.timeScale = 0;
        menuFace.SetActive(true);
    }

    public void ExitMenu()
    {
        Time.timeScale = 1;
        menuFace.SetActive(false);
    }

    public void DisplayHint()
    {
        hint.SetActive(true);
    }
    public void ExitHint()
    {
        hint.SetActive(false);
    }

    public void BGVolumeChange()
    {
        Transform slider = volumeFace.transform.Find("Slider");
        float volume =  slider.GetComponent<Slider>().value;
        cam.gameObject.GetComponent<AudioSource>().volume = volume;
    }

    public void DispalySlider()
    {
        volumeFace.SetActive(true);
    }
    public void ExitSlider()
    {
        volumeFace.SetActive(false);
    }

    public void HpChange()
    {
        hpVolue = player.GetComponent<PlayerCha>().ph;
        if (hpVolue == 3)
        {
            hp3.SetActive(true);
            hp2.SetActive(true);
            hp1.SetActive(true);
        }
        if (hpVolue == 2)
        {
            hp3.SetActive(false);
            hp2.SetActive(true);
            hp1.SetActive(true);
        }
        if (hpVolue == 1)
        {
            hp3.SetActive(false);
            hp2.SetActive(false);
            hp1.SetActive(true);
        }
        if (hpVolue == 0)
        {
            hp3.SetActive(false);
            hp2.SetActive(false);
            hp1.SetActive(false);
        }
    }

    public void DisGameOver()
    {
        gameOver.SetActive(true);
    }
   
    public void SenceChange()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    //public void btChange()
    //{
    //    Rigidbody2D rigid = player.GetComponent<PlayerCha>().bullets[0];
    //    int num = player.GetComponent<PlayerController>().btIndex;
    //    if (rigid.name == "BlueAgentiaBullet")
    //    {
    //        if (num == 0)
    //        {
    //            bluebt.SetActive(true);
    //            yellowbt.SetActive(false);
    //            purplebt.SetActive(false);
    //        }
    //        else if (num == 1)
    //        {
    //            bluebt.SetActive(false);
    //            yellowbt.SetActive(true);
    //            purplebt.SetActive(false);
    //        }
    //        else if (num == 2)
    //        {
    //            bluebt.SetActive(false);
    //            yellowbt.SetActive(false);
    //            purplebt.SetActive(true);
    //        }
    //    }
    //}
}
