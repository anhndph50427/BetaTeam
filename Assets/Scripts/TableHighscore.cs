using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TableHighscore : MonoBehaviour
{
    public List<HighscoreData> highscoreDatas = new List<HighscoreData>();
    public GameObject scoreLine;
    public Transform content;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            int rd = UnityEngine.Random.Range(0, 200);
            print(rd);

            HighscoreData newData = new HighscoreData();
            newData.score = rd;
            newData.name = "aaa";
            
            foreach (Transform line in content)
            {
                Destroy(line.gameObject);
            }

            if (highscoreDatas.Count < 5)
            {
                print("thêm 1 dòng mới");
                highscoreDatas.Add(newData);

                highscoreDatas = highscoreDatas.OrderByDescending(x => x.score).ToList(); //Sắp xếp các phần tử theo score giảm dần

                for (int i = 0; i < highscoreDatas.Count; i++)
                {
                    highscoreDatas[i].rank = i + 1;

                    GameObject line = Instantiate(scoreLine, content);
                    line.GetComponent<ControlScoreLine>().SetText(highscoreDatas[i]);
                }
            }
            else
            {
                HighscoreData getMin = highscoreDatas.OrderBy(x => x.score).FirstOrDefault(); //sắp xếp các phần tử theo score tăng dần, sau đó lấy ra phần tử đầu tiên.

                if (rd > getMin.score)
                {
                    highscoreDatas.Remove(getMin); //xóa người chơi có điểm thấp nhất => list chỉ còn 4 phần tử
                    highscoreDatas.Add(newData); // thêm người chơi có điểm cao hơn vào list => list luc này có 5 phần tử

                    highscoreDatas = highscoreDatas.OrderByDescending(x => x.score).ToList(); //Sắp xếp các phần tử theo score giảm dần

                    for (int i = 0; i < highscoreDatas.Count; i++)
                    {
                        highscoreDatas[i].rank = i + 1;

                        GameObject line = Instantiate(scoreLine, content);
                        line.GetComponent<ControlScoreLine>().SetText(highscoreDatas[i]);
                    }
                }
            }
        }
    }
}

[Serializable]
public class HighscoreData
{
    public int rank;
    public string name;
    public float score;
}