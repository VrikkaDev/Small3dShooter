using System.Collections.Generic;
using Map;
using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] 
        private int _enemyCount = 2;
        [SerializeField]
        private GameObject _enemyPrefab;

        private List<GameObject> _enemiesList = new List<GameObject>();

        private void Start()
        {
            GameClient.GetInstance().enemyManager = this;
        }

        public void RemoveEntityObject(GameObject go)
        {
            _enemiesList.Remove(go);
        }

        private void FixedUpdate()
        {
            if (_enemiesList.Count < _enemyCount)
            {
                GameObject enemy = Instantiate(_enemyPrefab, transform);
                RespawnManager.Respawn(enemy.GetComponent<EnemyScript>());
                _enemiesList.Add(enemy);
            }
        }
    }
}