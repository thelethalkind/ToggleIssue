using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAudio : MonoBehaviour
{
    //[SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] private Toggle toggleMusic, toggleEffects;
    //Vector2 handlePostion;
    bool muteMusic;

    void Start()
    {
        if (!PlayerPrefs.HasKey("muteMusic"))
        {
            PlayerPrefs.SetInt("muteMusic", 0);
            LoadMusicPref();
        }
        else
        {
            LoadMusicPref();
        }
    }

    public void OnMusicMute(bool muteMusic)
    {
        AudioPlayer.instance.ToggleMusic(muteMusic);
        //uiHandleRectTransform.anchoredPosition = muteMusic ? handlePostion * -1: handlePostion;
        Save();
    }

    // public void OnEffectsMute(bool muteEffects)
    // {
    //     PlayerPrefs.SetInt("ToggleEffects", 0);
    // }

    void LoadMusicPref()
    {
        muteMusic = PlayerPrefs.GetInt("muteMusic") == 1;
    }

    void Save()
    {
        Debug.Log("muteMusic is set to:" + muteMusic);
        PlayerPrefs.SetInt("muteMusic", muteMusic ? 1 : 0);
    }
}
