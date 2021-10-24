using System.Collections;
using UnityEngine;

public class RotateBehaviour : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [SerializeField] private float delay;

    public bool isRotating = false;

    private Camera myCam;
    private Vector3 screenPos;
    private float angleOffset;
    private CircleCollider2D col;
    private bool canRotate = true;

    private void Start()
    {
        myCam = Camera.main;
        col = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (!canRotate) return;

        Vector3 mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                screenPos = myCam.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
                isRotating = true;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(ShootCor());
            isRotating = false;
        }
    }

    IEnumerator ShootCor()
    {
        canRotate = false;
        gun.Shoot();
        yield return new WaitForSeconds(delay);
        canRotate = true;
    }
}
