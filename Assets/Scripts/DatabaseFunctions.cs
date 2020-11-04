using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseFunctions : MonoBehaviour
{
    public string username = "null";
    public int score;
    public Text text;
    public Text text2;
    public Text[] Highscores;
    private GameObject playerScore;
    public InputField nameInput;

    private void Start()
    {
        playerScore = GameObject.Find("/Plane");
        var playerScoreScript = playerScore.GetComponent<PlayerScore>();
        score = playerScoreScript.GetScore();
        UpdateScore();
    }

    public void NameValueChanged()
    {
        username = nameInput.text.ToString();
        UpdateScore();
    }

    public void UpdateScore()
    {
        text.text = score.ToString();
        text2.text = username;
    }
    public void SendInformationToDatabase()
    {
        if (username != "null")
        {
            string name = "@I€" + username;
            StartCoroutine(GetEntriesRequest(name, score.ToString()));
        }
    }
    private IEnumerator GetEntriesRequest(string inName, string inScore)
    {
        string url = "http://hers.hosts1.ma-cloud.nl/create.php?name=" + inName + "&score=" + inScore;
        WWW request = new WWW(url);
        yield return request;
        Debug.Log(request.text);
    }

    public void GetInformationFromDatabase()
    {
        StartCoroutine(GetResultRequest());
    }

    private IEnumerator GetResultRequest()
    {
        WWW request = new WWW("http://hers.hosts1.ma-cloud.nl/read.php");
        yield return request;
        //Debug.Log(request.text);
        Entries json = JsonUtility.FromJson<Entries>(request.text);
        json.entries.Sort((x, y) => y.score.CompareTo(x.score));
        //Debug.Log(json.entries.Count);
        int index = 0;
        for (int i=0; i<json.entries.Count; i++)
        { 
            string[] name = json.entries[i].name.Split('€');
            if (name.Length > 1 && index < Highscores.Length)
            {
                /*if (name[1] == username)
                {
                    text.text = json.entries[i].score.ToString();
                }*/
                string scoreText = name[1] + ": " + json.entries[i].score.ToString();
                Highscores[index].text = scoreText;
                index++;
                //Debug.Log(name[1]);
                //Debug.Log(json.entries[i].name);
                //Debug.Log(json.entries[i].score);
            }
        }
    }
}

[System.Serializable]
public struct Entries
{
    public List<Entry> entries;
}

[System.Serializable]
public struct Entry
{
    public int score;
    public string name;
    public string time;
}