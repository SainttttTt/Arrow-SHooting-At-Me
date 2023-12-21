using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighestScoreInTextMenu : MonoBehaviour
{
    public TMP_Text text;

    private void Start()
    {
        text.text = "Highscore: " +  PlayerPrefs.GetInt("HighScore").ToString();    
    }
}
