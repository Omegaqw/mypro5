using UnityEngine;
using UnityEngine.UI; 

public class Wallet : MonoBehaviour
{
    private int totalCoins = 0; 

    public Text coinText;
    private void Start()
    {
        
        UpdateCoinDisplay();
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount; 
        UpdateCoinDisplay();  
    }

    private void UpdateCoinDisplay()
    {
        
        if (coinText != null)
        {
            coinText.text = "Coins: " + totalCoins;
        }
    }
}
