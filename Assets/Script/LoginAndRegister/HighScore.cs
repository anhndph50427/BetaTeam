using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public List<HighScoreContent> contents = new List<HighScoreContent>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class HighScoreContent
{
    public TextMeshProUGUI rank;
    public TextMeshProUGUI name;
    public TextMeshProUGUI score;
}
