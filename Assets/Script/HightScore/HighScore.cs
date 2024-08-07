using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HighScore : MonoBehaviour
{
    public List<HighScoreContent> highScoreContents = new List<HighScoreContent>();
    private void Start()
    {
        StartCoroutine(GetHightScore());
    }


    IEnumerator GetHightScore()
    {
        WWWForm formGetScore = new WWWForm();
        formGetScore.AddField("token", PlayerPrefs.GetString("token"));
        UnityWebRequest request = UnityWebRequest.Post("https://fpl.expvn.com/GetHighscore.php" , formGetScore);
        yield return request.SendWebRequest();
        if (!request.isDone)
        {
            Debug.Log("Không kết nối được với sever");
        }
        else
        {
            Debug.Log("Kết nối thành công");
            string[] getScore = request.downloadHandler.text.Split('\n');
            for (int i = 0; i < getScore.Length - 1; i++)
            {
                string[] cols = getScore[i].Split('\t');
                HighScoreContent dataPlayer = new HighScoreContent();
                dataPlayer.rank = i + 1;
                dataPlayer.name = cols[0];
                dataPlayer.Time = float.Parse(cols[1]);
                highScoreContents.Add(dataPlayer);
            }


        }
    }
}

[System.Serializable]
public class HighScoreContent
{
    public int rank;
    public string name;
    public float Time;
}
