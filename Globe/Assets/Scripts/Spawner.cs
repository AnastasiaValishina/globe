using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private Transform parent;
    [SerializeField] private int startingNumber;
    [SerializeField] private float timeBetweenSpawns;
    public ColorType[] colors;
    BallManager ballManager;

    private void Awake()
    {
        ballManager = FindObjectOfType<BallManager>();
    }
    private void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        int nameIndex = 1;
        for (int i = 0; i < startingNumber; i++)
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
