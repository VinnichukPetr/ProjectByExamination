using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class EndGame:MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private PlayerModel player;

        [Header("UI")]
        [SerializeField] private TMP_Text resultGame;
        [SerializeField] private TMP_Text resultCoin;
        [SerializeField] private GameObject starOne;
        [SerializeField] private GameObject starTwo;
        [SerializeField] private GameObject starThree;
        
        
        private void OnEnable()
        {
            resultGame.text = player.Health > 0 ? "You Win!" : "You Lose";
            resultCoin.text = $"Coins on this Level: {player.Coin}";

            if (player.Health <= 0) return;
            
            starOne.SetActive(true);

            if (player.Coin == player.MaxCoin)
            {
                starTwo.SetActive(true);
            }

            if (player.Health == player.MaxHealth)
            {
                starThree.SetActive(true);
            }
        }
    }
}