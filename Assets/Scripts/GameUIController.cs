using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

    [SerializeField]
    private NativeEvent EndGameEvent;

    [SerializeField]
    private IntEvent SetPlayerHealthEvent;

    [SerializeField]
    private GameObject endGamePanel;

    [SerializeField]
    private Text ScoreText;

    [SerializeField]
    private Text HighScoreText;

    private HighScoreCounter highScoreCounter;

    private void Start()
    {
        highScoreCounter = GetComponent<HighScoreCounter>();        
    }

    private void OnEnable()
    {
        EndGameEvent.AddListener(EnableEndGamePanel);
    }

    private void OnDisable()
    {
        EndGameEvent.RemoveListener(EnableEndGamePanel);
    }


    private void EnableEndGamePanel()
    {
        endGamePanel.SetActive(true);
        ScoreText.text += highScoreCounter.HighScore + "%";
        HighScoreText.text += highScoreCounter.OldHighScore + "%";
    }

    public void StartAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
