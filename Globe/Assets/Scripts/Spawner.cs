using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private Transform parent;
    [SerializeField] private int startingNumber;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private ColorType[] colors;
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
        for (int i = 0; i < startingNumber; i++)
        {
            int randomIndex = Random.Range(0, colors.Length);
            Vector2 pos = transform.position;
            Ball ball = Instantiate(ballPrefab, pos, Quaternion.identity);
            ball.transform.parent = parent;
            ball.SetColor(colors[randomIndex]);
            ball.name = colors[randomIndex].ballKind.ToString();
            ballManager.allBalls.Add(ball);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
