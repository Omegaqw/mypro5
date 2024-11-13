using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 5f;
    private Vector3 startPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(moveDistance, 0, 0);
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Меняем направление
            Vector3 temp = startPosition;
            startPosition = targetPosition;
            targetPosition = temp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Наносим урон
            }
        }
    }
}


