using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLine : MonoBehaviour
{
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI timeText;

    public void setText(HighScoreContent data)
    {
        rankText.text = data.rank.ToString();
        nameText.text = data.name.ToString();
        timeText.text = convertNumberToTime(data.time);
    }


    string convertNumberToTime(float number)
    {
        int minute = (int)(number / 60);
        int second = (int)(number % 60);

        return $"{minute}:{second}";

    }
}
