using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public struct Goal
{
    public ColorType colorType;
    public int numberNeeded;
    public bool isReached;
}

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GoalPanel goalPanel;
    [SerializeField] private GameObject winScreen;
    public Goal[] levelGoals;
    private int goalsCompleted = 0;
    private bool allGoalsReached = false;

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
    }

    private void CheckReachedGoals()
    {
        if (allGoalsReached) return;

        for (int i = 0; i < levelGoals.Length; i++)
        {
            if (!levelGoals[i].isReached && levelGoals[i].numberNeeded <= 0)
            {
                levelGoals[i].isReached = true;
                goalsCompleted++;
            }
        }

        if (goalsCompleted >= levelGoals.Length)
        {
            allGoalsReached = true;
            winScreen.SetActive(true);
        }
    }

    public void CompareGoals(BallKind ballKind)
    {
        for (int i = 0; i < levelGoals.Length; i++)
        {
            if (levelGoals[i].colorType.ballKind == ballKind)
            {
                levelGoals[i].numberNeeded--;
                goalPanel.UpdateGoals();                
            }
        }
        CheckReachedGoals();
    }
}
