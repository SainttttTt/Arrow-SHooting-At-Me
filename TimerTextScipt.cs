using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerTextScipr : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private float timer = 0.0f;
    public PlayerMovement player;

    private void Update()
    {
        if (player.isAlive)
        {
            timer += Time.deltaTime;
            TimerText.text = (timer * 100).ToString("0000");
        }

    }

}
