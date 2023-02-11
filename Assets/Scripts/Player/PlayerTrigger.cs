using System.Collections;
using Objects;
using Objects.Chest;
using Sound;
using UnityEngine;

namespace Player
{
    public class PlayerTrigger: MonoBehaviour
    {
        [Header("Player property")]
        [SerializeField] private PlayerModel player;

        [Header("Game property")] 
        [SerializeField] private SoundController soundController;
        [SerializeField] private GameObject endGameScene;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CoinPrefab coin))
            {
                soundController.CoinPlay();
                player.Coin++;
                Destroy(coin.gameObject);
                
            }
            else if(other.TryGetComponent(out BombPrefab bomb))
            {
                soundController.BombPlay();
                player.Health--;
                Destroy(bomb.gameObject);
                
                if(player.Health <= 0) endGameScene.SetActive(true);
            }
            else if(other.TryGetComponent(out HealthRecoveryPrefab healthRecovery))
            {
                soundController.HealthPlay();
                player.Health++;
                Destroy(healthRecovery.gameObject);
            }
            else if(other.TryGetComponent(out FreezeBombPrefab freezeBombPrefab))
            {
                soundController.FreezeBombPlay();
                ActivateDeceleration();
                Destroy(freezeBombPrefab.gameObject);
                StartCoroutine(nameof(DeactivateDeceleration));
            }
            else if(other.TryGetComponent(out ChestPrefab portalPrefab))
            {
                endGameScene.SetActive(true);
            }
        }

        
        private void ActivateDeceleration() =>  player.ActiveDeceleration = true;
        private IEnumerator DeactivateDeceleration()
        {
            yield return new WaitForSeconds(5f);
            player.ActiveDeceleration = false;
        }
    }
}