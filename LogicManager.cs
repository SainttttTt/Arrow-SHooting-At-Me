using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public AudioSource MenuAudio;
    public Slider volumeslider;
    public GameObject GearCanva;
    public GameObject MenuCanva;
    public bool GearsOpen = false;

    void Start()
    {
        MenuAudio.Play();
        MenuAudio.volume = PlayerPrefs.GetFloat("Volume", 0.25f);
        volumeslider.value = MenuAudio.volume;
    }

    public void PlayButtonClicked()
    {
        MenuAudio.Stop();
        SceneManager.LoadScene("GameScene");
    }

    public void onGearButton()
    {
        if (GearsOpen == false)
        {
            GearsOpen = true;
            GearCanva.SetActive(true);
            MenuCanva.SetActive(false);
            return;
        }

        GearsOpen = false;
        GearCanva.SetActive(false);
        MenuCanva.SetActive(true);
    }
    public void setVolume()
    {
        MenuAudio.volume = volumeslider.value;
        PlayerPrefs.SetFloat("VolumeSaver", MenuAudio.volume);
    }
}
