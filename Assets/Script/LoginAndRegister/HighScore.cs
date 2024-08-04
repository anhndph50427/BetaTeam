using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class HighScore : MonoBehaviour
{
    public List<HighScoreContent> HightScoreData = new List<HighScoreContent>();
    public GameObject ScoreInfo;
    public Transform Column;
    public int timeFinish;
    void Start()
    {
        HighScoreContent content = new HighScoreContent();
        content.name = "Latina";
        content.time = timeFinish;

        foreach (Transform t in Column)
        {
            Destroy(t.gameObject);
        }

        if (HightScoreData.Count < 3)
        {
            Debug.Log("Th�m m?t d�ng m?i");
            HightScoreData.Add(content);

            HightScoreData = HightScoreData.OrderBy(x => x.time).ToList();

            for (int i = 0; i < HightScoreData.Count; i++)
            {
                HightScoreData[i].rank = i + 1;
                GameObject lines = Instantiate(ScoreInfo, Column);
                lines.GetComponent<ScoreLine>().setText(HightScoreData[i]);
            }

        }
        else
        {
            var min = HightScoreData.OrderByDescending(x => x.time).FirstOrDefault();
            if (min != null)
            {
                Debug.Log("X�a 1 d�ng");
                HightScoreData.Remove(min);
                if (timeFinish > min.time)
                {
                    HightScoreData = HightScoreData.OrderBy(x => x.time).ToList();
                    for (int i = 0; i <= HightScoreData.Count; i++)
                    {
                        HightScoreData[i].rank = i + 1;
                        GameObject lines = Instantiate(ScoreInfo, Column);
                        lines.GetComponent<ScoreLine>().setText(HightScoreData[i]);
                    }
                }
            }
        }

    }
}


[System.Serializable]
public class HighScoreContent
{
    public int rank;
    public string name;
    public int time;
}
