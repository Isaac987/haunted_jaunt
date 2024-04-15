using Unity.VisualScripting;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject nearestEnemy;
    public float speed = 5.0f;
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float nearestDistance = 10000;

        foreach (GameObject enemy in enemies) {
            float distance = Vector3.Distance(this.transform.position, enemy.transform.position);

            if (distance < nearestDistance) {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        Vector3 direction = (nearestEnemy.transform.position - transform.position).normalized;
        float dot = Vector3.Dot(Vector3.forward, direction);

        // Enemy can see you
        if (dot < 0.0f) {

            // Rotate towards the enemy
            Quaternion toRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
        } else {

            // Rotate towards the parent forward position
            Quaternion parentRotation = Quaternion.LookRotation(new Vector3(transform.parent.forward.x, 0.0f, transform.parent.forward.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, parentRotation, speed * Time.deltaTime);
        }
    }
}
