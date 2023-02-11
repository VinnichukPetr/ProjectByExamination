using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthReflection : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private PlayerModel player;

        [Header("Sprite")] 
        [SerializeField] private Image heartImage;

        private List<Image> _heartImages;

        
        private void Start()
        {
            var heartTransform = transform;
            var position = heartTransform.position;
            
            _heartImages = new List<Image>();
           
            for (var i = 0; i < player.MaxHealth; i++)
            {
                var heart = Instantiate(heartImage, position, Quaternion.identity, heartTransform);
                
                _heartImages.Add(heart);
                position.x -= 50;
            }
        }

        
        private void OnEnable() => player.HealthChanged += OnHealthChange;
        private void OnDisable() => player.HealthChanged -= OnHealthChange;

        
        private void OnHealthChange()
        {
            for (var i = 0; i < _heartImages.Count; i++)
            {
                var heart = _heartImages[i];

                heart.gameObject.SetActive(i < player.Health);
            }
        }
    }
}