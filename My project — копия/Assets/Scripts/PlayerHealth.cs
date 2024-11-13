using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное здоровье
    public int currentHealth; // Текущее здоровье

    private void Start()
    {
        // Инициализация текущего здоровья
        currentHealth = maxHealth;
    }

    // Метод для получения урона
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Текущее здоровье: " + currentHealth); // Для отладки
        Debug.Log("Бочка взорвалась! Урон: 20");
        Debug.Log("Текущее здоровье игрока: " + currentHealth);


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Метод смерти игрока
    private void Die()
    {
        Debug.Log("Игрок мертв!");
        // Логика смерти, например, уничтожение игрока
        Destroy(gameObject);
    }
}
