using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public float explosionForce = 500f;
    public float explosionRadius = 5f;
    public GameObject explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 5f) 
        {
            Explode();
        }
    }

    private void Explode()
    {
        
        Instantiate(explosionEffect, transform.position, transform.rotation);

        
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            
            if (hit.CompareTag("Player"))
            {
                PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(20); 
                }
            }
        }

        
        Destroy(gameObject);
    }

}
