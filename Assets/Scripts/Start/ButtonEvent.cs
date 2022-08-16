using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    public GameObject hint;
    public Transform cam;
    public AudioClip clickClip;
    public GameObject volumeFace;
    public GameObject ThanksFace;

    public float progressTime;
    private void Update()
    {
        ClickSound();
        if (ThanksFace.activeInHierarchy)
        {
            ProgressBar();
        }
    }
    public void Scenechange()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void DisplayHint()
    {
        hint.SetActive(true);
    }
    public void EixtHint()
    {
        hint.SetActive(false);
    }

    public void ClickSound()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AudioSource.PlayClipAtPoint(clickClip, cam.position);
        }
    }

    public void BGVolumeChange()
    {
        Transform slider = volumeFace.transform.Find("Slider");
        float volume = slider.GetComponent<Slider>().value;
        cam.gameObject.GetComponent<AudioSource>().volume = volume;
    }

    public void DispalySlider()
    {
        volumeFace.SetActive(true);
    }
    public void EixtSlider()
    {
        volumeFace.SetActive(false);
    }

    public void DispalyThankFace()
    {
        ThanksFace.SetActive(true);
    }
    public void ProgressBar()
    {
        Transform slider = ThanksFace.transform.Find("Slider");
        Transform numText = slider.transform.Find("NumText");
        slider.GetComponent<Slider>().value += progressTime * Time.deltaTime;
        float volume = slider.GetComponent<Slider>().value;
        numText.GetComponent<Text>().text = ((int)(volume * 100f)).ToString() + "%";
        if (volume >= 1f)
        {
            Scenechange();
        }
    }
}
