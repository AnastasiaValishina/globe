using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public ColorType[] allColors;
    public BallManager ballManager;
    public LevelManager levelManager;
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
}
