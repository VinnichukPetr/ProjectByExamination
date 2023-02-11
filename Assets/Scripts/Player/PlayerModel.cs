using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerModel : MonoBehaviour
    {
        [Header("Heat Point")]
        [SerializeField] private int maxHealth = 3;
        [SerializeField] private int health = 3;
        
        [Header("Speed")]
        [SerializeField] private float speed = 1f;
        [SerializeField] private float rotationSpeed = 70f; 
        [SerializeField] private float acceleration = 1.2f;
        [SerializeField] private float deceleration = 0.8f;
        [SerializeField] private bool activeDeceleration = false;
        
        [Header("Coin")] 
        [SerializeField] private int coin = 0;
        [SerializeField] private int maxCoin = 0;
        
        public int Health
        {
            get => health;
            set
            {
                if (value > maxHealth || value < 0) return;

                health = value;
                HealthChanged?.Invoke();
            }
        }
        public int Coin
        {
            get => coin;
            set
            {
                coin = value;
                CoinsChanged?.Invoke();
            }
        }
        public int MaxCoin
        {
            get => maxCoin;
            set => maxCoin = value;
        }
        public bool ActiveDeceleration
        {
            set => activeDeceleration = value;
        }
        
        
        public int MaxHealth => maxHealth;
        public float Sped => speed;
        public float RotationSpeed => rotationSpeed;
        public float Acceleration => acceleration;
        public float Deceleration => activeDeceleration ? deceleration : 1;
        public event UnityAction HealthChanged;
        public event UnityAction CoinsChanged;
    }
}