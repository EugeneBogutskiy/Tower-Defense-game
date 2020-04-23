using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wayPointsIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = WayPoints.points[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if (wayPointsIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            GameObject burstGameObject = Instantiate(enemy.burstEffect, transform.position, enemy.burstEffect.transform.rotation);
            Destroy(burstGameObject, 2f);
            PlayerStats.lives--;
            return;
        }

        wayPointsIndex++;
        target = WayPoints.points[wayPointsIndex];
    }
}
