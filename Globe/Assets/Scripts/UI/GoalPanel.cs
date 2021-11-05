using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPanel : MonoBehaviour
{
    [SerializeField] private GoalItem goalPrefab;
    private List<GoalItem> goalItemsList;

    private void Start()
    {
        goalItemsList = new List<GoalItem>();
        int levelsNumber = GoalManager.Instance.levelGoals.Length;
        
        for (int i = 0; i < levelsNumber; i++)
        {
            GoalItem goalItem = Instantiate(goalPrefab, this.transform);
            goalItemsList.Add(goalItem);
        }

        for (int i = 0; i < goalItemsList.Count; i++)
        {
            goalItemsList[i].SetCounter(GoalManager.Instance.levelGoals[i].numberNeeded);
            goalItemsList[i].SetColor(GoalManager.Instance.levelGoals[i].colorType);
        }
    }
}
