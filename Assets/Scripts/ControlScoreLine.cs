using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlScoreLine : MonoBehaviour
{
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI scoreText;

    public void SetText(HighscoreData data)
    {
        rankText.text = data.rank.ToString();
        nameText.text = data.name;
        scoreText.text = data.score.ToString();
    }
}
