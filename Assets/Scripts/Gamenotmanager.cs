using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamenotmanager : MonoBehaviour
{
    public static int score;
    [SerializeField] private GameObject resWindow;
    [SerializeField] private Text winLooseText;
    private void Update()
    {
        if (score>10)
        {
            Time.timeScale = 0;
            resWindow.SetActive(true);
            winLooseText.text = "Victory!";
        }
    }
    public  void RestartLevel()
    {
        Time.timeScale = 1;
        score = 0;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
