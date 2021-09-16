using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    public bool canShoot;
    

    public void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        canShoot = false;
    }
}
