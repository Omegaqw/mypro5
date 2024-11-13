using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public float explosionForce = 500f;
    public float explosionRadius = 5f;
    public GameObject explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 5f) // Условие для силы удара
        {
            Explode();
        }
    }

    private void Explode()
    {
        // Создание эффекта взрыва
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // Получение всех объектов в радиусе взрыва
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            // Проверка, является ли объект игроком, и уменьшение здоровья
            if (hit.CompareTag("Player"))
            {
                PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(20); // Уменьшаем здоровье игрока на 20
                }
            }
        }

        // Уничтожение бочки
        Destroy(gameObject);
    }

}
