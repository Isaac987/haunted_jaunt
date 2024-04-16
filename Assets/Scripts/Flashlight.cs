using Unity.VisualScripting;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    GameObject GetNearestEnemy() {
        GameObject nearestEnemy = enemies[0];

        // Set the nearest enemey distance to some large number so it updates correctly
        float nearestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies) {

            // We don't care about distance, just which ghost is closer
            float squaredDistance = Vector3.SqrMagnitude(this.transform.position - enemy.transform.position);

            if (squaredDistance < nearestDistance) {
                nearestDistance = squaredDistance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject nearestEnemy = GetNearestEnemy();

        // Get the direction vector and ignore the y-axis so this rotates in a circle
        Vector3 direction = (nearestEnemy.transform.position - transform.position).normalized;
        direction.y = 0.0f;

        // Standard angle calculation
        float dot = Vector3.Dot(transform.forward.normalized, direction);
        float angle = Mathf.Rad2Deg * Mathf.Acos(dot);
        Vector3 cross = Vector3.Cross(transform.forward.normalized, direction);

        // Quaternion magic and LERP
        Quaternion rotation = Quaternion.AngleAxis(angle, cross);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation * transform.rotation, Time.deltaTime * rotationSpeed);
    }
}
