using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighScoreCounter : MonoBehaviour {

    [SerializeField]
    private NativeEvent playerShootEvent;

    [SerializeField]
    private NativeEvent playerHitEvent;

    [SerializeField]
    private NativeEvent endGameEvent;

    public int OldHighScore { get; set; }

    public float HighScore
    {
        get
        {
            if(playerShoots == 0)
            {
                return 0;
            }
            return Mathf.Round(playerHits * 100 / playerShoots);
        }
    }

    private int playerShoots;
    private int playerHits;

    private void Start()
    {
        ReadHighScore();
    }

    private void OnEnable()
    {
        playerShootEvent.AddListener(PlayerShootCounter);
        playerHitEvent.AddListener(PlayerHitCounter);
        endGameEvent.AddListener(EndGame);
    }

    private void OnDisable()
    {
        endGameEvent.RemoveListener(EndGame);
        playerShootEvent.RemoveListener(PlayerShootCounter);
        playerHitEvent.RemoveListener(PlayerHitCounter);
    }

    private void PlayerShootCounter()
    {
        playerShoots++;
    }

    private void PlayerHitCounter()
    {
        playerHits++;
    }

    private void ReadHighScore()
    {
        FileInfo fileInfo = new FileInfo(Application.persistentDataPath + FindObjectOfType<DataStorage>().playerHighScoreFilePath);


        if (fileInfo.Exists)
        {
            StreamReader reader = fileInfo.OpenText();
            string score = reader.ReadLine();
            if (score != null)
                OldHighScore = int.Parse(score);
            else
                OldHighScore = 0;

        }
        else
        {
            OldHighScore = 0;
        }
    }


    private void EndGame()
    {
        FileInfo fileInfo = new FileInfo(Application.persistentDataPath + FindObjectOfType<DataStorage>().playerHighScoreFilePath);
        StreamWriter writer = null;
        

        if (!fileInfo.Exists)
        {
            writer = fileInfo.CreateText();
        }
       
        int score = OldHighScore;

        if (HighScore > score)
        {
            File.WriteAllLines(Application.persistentDataPath + FindObjectOfType<DataStorage>().playerHighScoreFilePath, new string[] { HighScore.ToString() });
        }

        if (writer != null)
            writer.Close();
    }
}
