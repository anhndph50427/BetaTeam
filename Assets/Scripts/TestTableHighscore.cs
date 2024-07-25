using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestTableHighscore : MonoBehaviour
{
    public List<HighScoreData> listScore;
    public HighScoreData newdata;

    // Start is called before the first frame update
    private void Start()
    {
        listScore = new List<HighScoreData>();
        listScore.Add(new HighScoreData() { name = "Thuy", score = 5 });
        listScore.Add(new HighScoreData() { name = "Phong", score = 15 });
        listScore.Add(new HighScoreData() { name = "Lap", score = 25 });
        listScore.Add(new HighScoreData() { name = "Tien", score = 51 });
        listScore.Add(new HighScoreData() { name = "Quynh", score = 62 });
        listScore.Add(new HighScoreData() { name = "Hue", score = 12 });

        listScore = listScore.OrderByDescending(x => x.score).ToList();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            int rd = UnityEngine.Random.Range(0, 200);
            print(rd);
            newdata = new HighScoreData() { name = "newPlayer", score = rd };

            var getMin = listScore.OrderBy(a => a.score).FirstOrDefault();

            if (newdata.score > getMin.score)
            {
                print("Highscore");
                listScore.Remove(getMin);
                listScore.Add(newdata);

                listScore = listScore.OrderByDescending(x => x.score).ToList();
            }
        }        
    }
}

[Serializable]
public class HighScoreData
{
    public string name;
    public float score;
}