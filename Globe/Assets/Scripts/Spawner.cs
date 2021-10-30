using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private Transform parent;
    [SerializeField] LevelManager levelManager;

    private int level;
    private BallManager ballManager;
    private int ballsAtStart;
    private float timeBetweenSpawns;
    private ColorType[] colors;

    private void Awake()
    {
        ballManager = GetComponent<GameData>().ballManager;
        if (levelManager != null)
        {
            if (level < levelManager.levels.Length)
            {
                if (levelManager.levels[level] != null)
                {                   
                    ballsAtStart = levelManager.levels[level].ballsAtStart;
                    timeBetweenSpawns = levelManager.levels[level].timeBetweenSpawns;
                    colors = levelManager.levels[level].colors;
                }
            }
        }        
    }
    private void Start()
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
