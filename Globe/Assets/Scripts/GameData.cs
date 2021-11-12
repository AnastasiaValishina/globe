using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public ColorType[] allColors;
    public BallManager ballManager;
    public LevelManager levelManager;
    public Spawner spawner;
    public int currentLevel;

    static GameData instance;
    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameData>();
            }
            return instance;
        }
    }

    public Level GetCurrentLevel()
    {
        return levelManager.levels[currentLevel];
    }

    public void NextLevel()
    {
        if (levelManager.levels.Length <= currentLevel)
        {
            currentLevel += 1;
            SetLevel();
        }
        else
        {
            Debug.Log("There are no more levels");
        }
    }

    public void SetLevel()
    {
        spawner.SetLevelData();
        spawner.StartSpawning();
    }
}
