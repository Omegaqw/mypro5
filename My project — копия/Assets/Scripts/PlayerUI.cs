using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public RectTransform healthBarFill; 


    private float maxWidth;

    private void Start()
    {
        
        maxWidth = healthBarFill.sizeDelta.x;
    }

    private void Update()
    {
        if (playerHealth != null)
        {
            
            float newWidth = maxWidth * ((float)playerHealth.currentHealth / playerHealth.maxHealth);
            healthBarFill.sizeDelta = new Vector2(newWidth, healthBarFill.sizeDelta.y);
        }
    }
}
