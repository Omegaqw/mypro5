using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            Wallet playerWallet = other.GetComponent<Wallet>();
            if (playerWallet != null)
            {
                playerWallet.AddCoins(coinValue);
            }

            
            Destroy(gameObject);
        }
    }
}
