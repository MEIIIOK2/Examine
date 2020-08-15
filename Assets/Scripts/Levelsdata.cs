using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Levels Data",menuName ="Levels Data")]

public class Levelsdata : ScriptableObject
{
    
    
    public List<Level> levels;
    public enum LevelStatus
    {
        Closed,Open,Completed
    }
    
    [Serializable]
    public class Level
    {
        
        public LevelStatus status;
        public int sceneBuildnumber;
    }
}
