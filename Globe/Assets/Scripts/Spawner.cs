using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private Transform parent;

    private int currentLevel;
    private LevelManager levelManager;
    private BallManager ballManager;
    private int ballsAtStart;
    private float timeBetweenSpawns;
    private ColorType[] colors;

    private void Awake()
    {
        ballManager = GameData.Instance.ballManager;
        levelManager = GameData.Instance.levelManager;
        currentLevel = GameData.Instance.currentLevel;

        SetLevelData();
    }

    public void SetLevelData()
    {
        if (levelManager != null)
        {
            if (currentLevel < levelManager.levels.Length)
            {
                if (levelManager.levels[currentLevel] != null)
                {
                    ballsAtStart = levelManager.levels[currentLevel].ballsAtStart;
                    timeBetweenSpawns = levelManager.levels[currentLevel].timeBetweenSpawns;
                    colors = levelManager.levels[currentLevel].colors;
                }
            }
        }
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        int nameIndex = 1;
        for (int i = 0; i < ballsAtStart; i++)
        {
            Vector2 pos = transform.position;
            Ball ball = Instantiate(ballPrefab, pos, Quaternion.identity);
            SetRandomColor(ball);
            ball.transform.parent = parent;
            ball.name = nameIndex.ToString();
            ballManager.allBalls.Add(ball);
            nameIndex++;
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void SetRandomColor(BallBase ball)
    {
        int randomIndex = Random.Range(0, colors.Length);
        ball.SetColor(colors[randomIndex]);
    }
}
