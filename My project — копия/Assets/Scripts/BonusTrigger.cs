using UnityEngine;

public class BonusTrigger : MonoBehaviour
{
    public Color enterColor = Color.red; 
    public Color exitColor = Color.white; 
    private Renderer objectRenderer;

    private void Start()
    {
        
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            
            objectRenderer.material.color = exitColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && objectRenderer != null)
        {
            
            objectRenderer.material.color = enterColor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player") && objectRenderer != null)
        {
            
            objectRenderer.material.color = exitColor;
        }
    }
}
