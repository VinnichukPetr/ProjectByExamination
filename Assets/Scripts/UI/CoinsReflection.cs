using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CoinsReflection : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private PlayerModel player;
        
        [Header(("UI"))]
        [SerializeField] private TMP_Text coinsText;
        [SerializeField] private Image coinImage;
        
        
        private void Start()
        {
            var coinsTransform = transform; 
            var position = coinsTransform.position;
            
            Instantiate(coinImage, position, Quaternion.identity, coinsTransform);
            coinsText.text = "0";
        }


        private void OnEnable() => player.CoinsChanged += OnCoinsChange;
        private void OnDisable() => player.CoinsChanged -= OnCoinsChange;
        
        
        private void OnCoinsChange() =>  coinsText.text = player.Coin.ToString();
    }
}