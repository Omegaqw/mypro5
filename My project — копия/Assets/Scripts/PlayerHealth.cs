using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; 
    public int currentHealth; 

    private void Start()
    {
        ˙
        currentHealth = maxHealth;
    }

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Ňĺęóůĺĺ çäîđîâüĺ: " + currentHealth); 
        Debug.Log("Áî÷ęŕ âçîđâŕëŕńü! Óđîí: 20");
        Debug.Log("Ňĺęóůĺĺ çäîđîâüĺ čăđîęŕ: " + currentHealth);


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    
    private void Die()
    {
        Debug.Log("Čăđîę ěĺđňâ!");
        
        Destroy(gameObject);
    }
}
