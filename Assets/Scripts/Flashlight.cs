using Unity.VisualScripting;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject nearestEnemy;
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        float nearestDistance = 10000;

        foreach (GameObject enemy in enemies) {
            float distance = Vector3.Distance(this.transform.position, enemy.transform.position);

            if (distance < nearestDistance) {
                nearestDistance = distance;
                nearestEnemy = enemy;

            }
        }

        Vector3 direction = (nearestEnemy.transform.position - transform.position);
        float dot = Vector3.Dot(Vector3.forward, direction.normalized);

        // Enemy can see you
        if (dot < 0.0f) {
            transform.LookAt(new Vector3(nearestEnemy.transform.position.x, transform.position.y, nearestEnemy.transform.position.z));
        }
    }
}
