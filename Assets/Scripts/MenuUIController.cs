using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour {

    [SerializeField]
    private Text enemyCountText;

    [SerializeField]
    private Slider enemyCountSlider;

    [SerializeField]
    private Text playerHighScoreText;
    
    private string baseEnemyCountText;
    private int enemyCount;
    private DataStorage dataStorage;

    private void Start()
    {
        dataStorage = FindObjectOfType<DataStorage>();
        baseEnemyCountText = enemyCountText.text;
        EnemyCountSliderChanged();
        ReadHighScore();
    }

    public void EnemyCountSliderChanged()
    {
        enemyCount = (int)enemyCountSlider.value;
        enemyCountText.text = baseEnemyCountText + " " + enemyCountSlider.value;
    }

    public void StartGame()
    {
        dataStorage.EnemyCount = enemyCount;
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void ReadHighScore()
    {
        FileInfo fileInfo = new FileInfo(Application.persistentDataPath + FindObjectOfType<DataStorage>().playerHighScoreFilePath);


        if (fileInfo.Exists)
        {
            StreamReader reader = fileInfo.OpenText();
            string score = reader.ReadLine();
            playerHighScoreText.text += score + "%";
        }
        else
        {
            playerHighScoreText.text += "none";
        }
    }

}
