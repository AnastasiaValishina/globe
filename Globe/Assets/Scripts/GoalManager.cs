using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public struct Goal
{
    public ColorType colorType;
    public int numberNeeded;
    public int numberCollected;
}

public class GoalManager : MonoBehaviour
{
    public Goal[] levelGoals;
    private int goalsCompleted = 0;
    private bool isGoalsReached = false;

    static GoalManager instance;
    public static GoalManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GoalManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        levelGoals = GameData.Instance.levelManager.levels[GameData.Instance.currentLevel].levelGoals;
        Debug.Log("GoalManager : " + levelGoals.Length);
    }

    private void Update()
    {
        if (isGoalsReached) return;

        for (int i = 0; i < levelGoals.Length; i++)
        {
            if (levelGoals[i].numberCollected >= levelGoals[i].numberNeeded)
            {
                goalsCompleted++;
                Debug.Log("goals completed " + goalsCompleted);
            }
        }

        if (goalsCompleted >= levelGoals.Length)
        {
            isGoalsReached = true;
            Debug.Log("you win");
        }
    }

    public void CompareGoals(BallKind ballKind)
    {
        for (int i = 0; i < levelGoals.Length; i++)
        {
            if (levelGoals[i].colorType.ballKind == ballKind)
            {
                levelGoals[i].numberCollected++;
            }
        }
    }
}