using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;


public class HighScore : MonoBehaviour
{
    public List<HighScoreContent> HightScoreData = new List<HighScoreContent>();
    public GameObject ScoreInfo;
    public Transform Column;
    public int timeFinish;
    void Start()
    {
        HighScoreContent content = new HighScoreContent();
        content.name = "001";
        content.time = timeFinish;

        foreach (Transform t in Column)
        {
            Destroy(t.gameObject);
        }

        if (HightScoreData.Count < 3)
        {
            Debug.Log("Thêm m?t dòng m?i");
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
                Debug.Log("Xóa 1 dòng");
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

    #region test
    //IEnumerator GetScore()
    //{
    //    WWWForm getScore = new WWWForm();
    //    getScore.AddField("token", PlayerPrefs.GetString("token"));
    //    UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/GetHighscore.php", getScore);
    //    yield return www.SendWebRequest();
    //    if (!www.isDone)
    //    {
    //        Debug.Log("ErrorGetScore");
    //    }
    //    else
    //    {
    //        Debug.Log("Finish");
    //        string[] get = www.downloadHandler.text.Split('\n');
    //        HighScoreContent content = new HighScoreContent();
    //        for (int i = 1; i < get.Length; i++)
    //        {
    //            string[] cols = get[i].Split('\t');
    //            Debug.Log("Name: " + cols[0]);
    //            Debug.Log("Score: " + cols[1]);

    //        }

    //        //HighScoreContent content = new HighScoreContent();


    //        foreach (Transform t in Column)
    //        {
    //            Destroy(t.gameObject);
    //        }

    //        if (HightScoreData.Count < 3)
    //        {
    //            Debug.Log("Thêm m?t dòng m?i");
    //            HightScoreData.Add(content);

    //            HightScoreData = HightScoreData.OrderBy(x => x.time).ToList();

    //            for (int i = 0; i < HightScoreData.Count; i++)
    //            {
    //                HightScoreData[i].rank = i + 1;
    //                GameObject lines = Instantiate(ScoreInfo, Column);
    //                lines.GetComponent<ScoreLine>().setText(HightScoreData[i]);
    //            }

    //        }
    //        else
    //        {
    //            var min = HightScoreData.OrderByDescending(x => x.time).FirstOrDefault();
    //            if (min != null)
    //            {
    //                Debug.Log("Xóa 1 dòng");
    //                HightScoreData.Remove(min);
    //                if (timeFinish > min.time)
    //                {
    //                    HightScoreData = HightScoreData.OrderBy(x => x.time).ToList();
    //                    for (int i = 0; i <= HightScoreData.Count; i++)
    //                    {
    //                        HightScoreData[i].rank = i + 1;
    //                        GameObject lines = Instantiate(ScoreInfo, Column);
    //                        lines.GetComponent<ScoreLine>().setText(HightScoreData[i]);
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
    #endregion
}


[System.Serializable]
public class HighScoreContent
{
    public int rank;
    public string name;
    public int time;
}
