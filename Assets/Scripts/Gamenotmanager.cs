using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamenotmanager : MonoBehaviour
{
    public static int score;
    public static int health;
    [SerializeField] private Levelsdata levelsdata;
    [SerializeField] private GameObject resWindow;
    [SerializeField] private Text winLooseText;
    private void Start()
    {
        score = 0;
        health = 3;
    }
    private void Update()
    {
        if (score>10)
        {
            Time.timeScale = 0;
            resWindow.SetActive(true);
            winLooseText.text = "Victory!";
            int scenenum = SceneManager.GetActiveScene().buildIndex;
            levelsdata.levels[scenenum].status = Levelsdata.LevelStatus.Open;
            levelsdata.levels[scenenum - 1].status = Levelsdata.LevelStatus.Completed;
        }
        if (health<=0)
        {
            Time.timeScale = 0;
            resWindow.SetActive(true);
            winLooseText.text = "You loose";
        }
    }
    public  void RestartLevel()
    {
        Time.timeScale = 1;
        score = 0;
        health = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
