using Character;
using Map;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyScript : MonoBehaviour, ICharacterEntity
    {
        private Transform _healthBarTransform;
        private Image _healthBar;
        private Transform _player;
        
        private void Start()
        {
            _healthBarTransform = transform.Find("HealthBar");
            _healthBar = _healthBarTransform.Find("Canvas").Find("Bar").GetComponent<Image>();
        }

        private void FixedUpdate()
        {
            if (_player.IsUnityNull())
            {
                _player = GameClient.GetInstance().player.transform;
                return;
            }
            _healthBarTransform.LookAt(_player);
        }

        public CharacterTags GetTag()
        {
            return CharacterTags.Enemy;
        }
        
        public CharacterModes Mode { get; set; }
        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public float Health { get; set; } = 100;

        public void GotShot(CharacterBodyParts bodyPart)
        {
            Health -= (int)bodyPart;

            _healthBar.fillAmount = (Health / 100);

            if (Health <= 0f)
            {
                Kill();
            }
        }

        public void Kill()
        {
            RespawnManager.OnDeath(this);
            GameClient.GetInstance().enemyManager.RemoveEntityObject(gameObject);
            Destroy(gameObject);
        }

        public void Spawn()
        {
            
        }
    }
}