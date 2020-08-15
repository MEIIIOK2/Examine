using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;
    [SerializeField] private Levelsdata data;
    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            
            
            if (data.levels[i].status==Levelsdata.LevelStatus.Closed)
            {
                buttons[i].GetComponent<Image>().color = Color.red;
                buttons[i].enabled = false;
            }
            else if (data.levels[i].status == Levelsdata.LevelStatus.Completed)
            {
                buttons[i].GetComponent<Image>().color = Color.green;
                
            }
            else
            {
                buttons[i].GetComponent<Image>().color = Color.yellow;
            }


            //buttons[i].GetComponent<Button>().onClick.AddListener(delegate { ChangeScene(i); }); странно, но не работает
            
        }
        
        buttons[0].GetComponent<Button>().onClick.AddListener(delegate { ChangeScene(data.levels[0].sceneBuildnumber); });
        buttons[1].GetComponent<Button>().onClick.AddListener(delegate { ChangeScene(data.levels[1].sceneBuildnumber); });
        buttons[2].GetComponent<Button>().onClick.AddListener(delegate { ChangeScene(data.levels[2].sceneBuildnumber); });
    }

    // Update is called once per frame
    private void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber+1);
    }
}
