using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public RectTransform healthBarFill; // »спользуем RectTransform дл€ изменени€ ширины


    private float maxWidth;

    private void Start()
    {
        // —охран€ем исходную ширину полоски
        maxWidth = healthBarFill.sizeDelta.x;
    }

    private void Update()
    {
        if (playerHealth != null)
        {
            // ¬ычисл€ем новую ширину полоски на основе текущего здоровь€
            float newWidth = maxWidth * ((float)playerHealth.currentHealth / playerHealth.maxHealth);
            healthBarFill.sizeDelta = new Vector2(newWidth, healthBarFill.sizeDelta.y);
        }
    }
}
