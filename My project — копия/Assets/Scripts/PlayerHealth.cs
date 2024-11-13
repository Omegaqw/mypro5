using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // ������������ ��������
    public int currentHealth; // ������� ��������

    private void Start()
    {
        // ������������� �������� ��������
        currentHealth = maxHealth;
    }

    // ����� ��� ��������� �����
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("������� ��������: " + currentHealth); // ��� �������
        Debug.Log("����� ����������! ����: 20");
        Debug.Log("������� �������� ������: " + currentHealth);


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ����� ������ ������
    private void Die()
    {
        Debug.Log("����� �����!");
        // ������ ������, ��������, ����������� ������
        Destroy(gameObject);
    }
}
