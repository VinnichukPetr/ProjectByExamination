using UnityEngine;

namespace Sound
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioBomb;
        [SerializeField] private AudioSource audioCoin;
        [SerializeField] private AudioSource audioFreezeBomb;
        [SerializeField] private AudioSource audioHealth;

        public void BombPlay() => audioBomb.Play();
        public void CoinPlay() => audioCoin.Play();
        public void FreezeBombPlay() => audioFreezeBomb.Play();
        public void HealthPlay() => audioHealth.Play();
    }
}