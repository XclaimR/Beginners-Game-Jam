using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<ScoreboardEntry> scoreboardEntryList;
    private List<Transform> scoreboardEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("EntryContainer");
        entryTemplate = entryContainer.Find("EntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        scoreboardEntryList = new List<ScoreboardEntry>
        {
            new ScoreboardEntry{time = 124234, name = "ABC"},
            new ScoreboardEntry{time = 1234, name = "RTF"},
            new ScoreboardEntry{time = 253462, name = "EWQ"},
            new ScoreboardEntry{time = 345, name = "BHY"},
            new ScoreboardEntry{time = 890678, name = "HUY"},
            new ScoreboardEntry{time = 2245, name = "NMK"},
            new ScoreboardEntry{time = 6666, name = "KIR"}
        };

        //Sorting
        for(int i = 0; i < scoreboardEntryList.Count; i++)
        {
            for(int j = i+1;j < scoreboardEntryList.Count; j++)
            {
                if(scoreboardEntryList[j].time < scoreboardEntryList[i].time)
                {
                    //Swap
                    ScoreboardEntry temp = scoreboardEntryList[i];
                    scoreboardEntryList[i] = scoreboardEntryList[j];
                    scoreboardEntryList[j] = temp;
                }
            }
        }


        scoreboardEntryTransformList = new List<Transform>();
        foreach(ScoreboardEntry scoreboardEntry in scoreboardEntryList)
        {
            CreateScoreboardEntry(scoreboardEntry, entryContainer, scoreboardEntryTransformList);
        }

        PlayerPrefs.SetString("scoreboardTable", "100");
        PlayerPrefs.Save();
        PlayerPrefs.GetString("scoreboardTable");
    }

    private void CreateScoreboardEntry(ScoreboardEntry scoreboardEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        Debug.Log(transformList.Count);
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);


        int rank = transformList.Count + 1;
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
                rankString = "2st";
                break;
            case 3:
                rankString = "3rd";
                break;
        }
        entryTransform.Find("Position").GetComponent<Text>().text = rankString;

        float time = scoreboardEntry.time;
        entryTransform.Find("Time").GetComponent<Text>().text = time.ToString();

        string name = scoreboardEntry.name;
        entryTransform.Find("Name").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
        
    }


    private class ScoreboardEntry{
        public float time;
        public string name; 
    }        
}
