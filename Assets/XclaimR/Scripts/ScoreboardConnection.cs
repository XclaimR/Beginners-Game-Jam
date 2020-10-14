using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardConnection : MonoBehaviour
{
    const string privateCode = "SJg1R6-OM0-_hJufXUm9dgzPeJulv5o0aYHcp-hYb7Dw";
    const string publicCode = "5f85e36deb371809c47dd85b";
    const string webURL = "http://dreamlo.com/lb/";

    private Transform entryContainer;
    private Transform entryTemplate;

    public ScoreboardEntry[] scoreboardList;

    void Awake()
    {

        entryContainer = transform.Find("EntryContainer");
        entryTemplate = entryContainer.Find("EntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //AddScoreboard("Nishanth", 123);
        //AddScoreboard("Quinea", 345);
        //AddScoreboard("OddSheep", 567);

        DownloadScoreboard();
    }

    public void AddScoreboard(string username,int time)
    {
        Debug.Log("In Addscoreboard"+username +" " + time);
        StartCoroutine(UploadScoreboard(username, time));
    }

    IEnumerator UploadScoreboard(string username, int time)
    {
        Debug.Log("In Uploadscoreboard" + username + " " + time);
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + time);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload Success");
        }
        else
        {
            Debug.Log("Error Uploading" + www.error);
        }
    }

    public void DownloadScoreboard()
    {
        StartCoroutine("DownloadScoreboardfromDB");
    }

    IEnumerator DownloadScoreboardfromDB()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe-asc/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatScoreboard(www.text);
            Debug.Log("Download Success");
        }
        else
        {
            Debug.Log("Error Uploading" + www.error);
        }
    }

    void FormatScoreboard(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        scoreboardList = new ScoreboardEntry[entries.Length];
        Debug.Log("Entries Length:"+entries.Length);
        for(int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string uname = entryInfo[0];
            int time = int.Parse(entryInfo[1]);
            scoreboardList[i] = new ScoreboardEntry(uname, time);
            Debug.Log(scoreboardList[i].name + " " + scoreboardList[i].time);
            CreateScoreboardEntry(scoreboardList[i], entryContainer, i);
        }
    }

    private void CreateScoreboardEntry(ScoreboardEntry scoreboardEntry, Transform container, int index)
    {
        float templateHeight = 30f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        //Debug.Log(transformList.Count);
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * index);
        entryTransform.gameObject.SetActive(true);


        int rank = index + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "th";
                break;
            case 1:
                rankString = "1st";
                break;
            case 2:
                rankString = "2nd";
                break;
            case 3:
                rankString = "3rd";
                break;
        }
        entryTransform.Find("Position").GetComponent<Text>().text = rankString;

        float time = scoreboardEntry.time/1000;
        GameObject timer = GameObject.Find("Timer");
        
        entryTransform.Find("Time").GetComponent<Text>().text = timer.GetComponent<Timer>().DisplayTime(time);

        string name = scoreboardEntry.name;
        entryTransform.Find("Name").GetComponent<Text>().text = name;

        //transformList.Add(entryTransform);

    }

    public class ScoreboardEntry
    {
        public int time;
        public string name;

        public ScoreboardEntry(string uname, int _time)
        {
            name = uname;
            time = _time;
        }
    }
}
