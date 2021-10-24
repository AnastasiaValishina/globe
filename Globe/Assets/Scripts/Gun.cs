using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform[] place = new Transform[2];

    Queue<Bullet> bullets = new Queue<Bullet>();
    Spawner spawner;

    private void Awake()
    {
        spawner = FindObjectOfType<Spawner>();
    }
    private void Start()
    {
        PrepareBalls();
    }
    public void Shoot()
    {
        Bullet bullet = bullets.Dequeue();
        bullet.canShoot = true;
        ResetPosition();
        SpawnNewBullet(1);
    }

    private void PrepareBalls()
    {
        for (int i = 0; bullets.Count < 2; i++)
        {
            SpawnNewBullet(i);
        }
        bullets.Peek().transform.localScale = new Vector3(1f, 1f);
    }

    private void ResetPosition()
    {
        Bullet bullet = bullets.Peek();
        bullet.transform.position = place[0].position;
        bullet.transform.localScale = new Vector3(1f, 1f);
    }

    private void SpawnNewBullet(int placeIndex)
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullets.Enqueue(bullet);
        bullet.transform.position = place[placeIndex].position;
        spawner.SetRandomColor(bullet);
        bullet.transform.localScale = new Vector3(0.5f, 0.5f);
    }
}
