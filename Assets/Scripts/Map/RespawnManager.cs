using System.Collections.Generic;
using Character;
using Enemy;
using Random = UnityEngine.Random;

namespace Map
{
    public class RespawnManager
    {
        private static Dictionary<CharacterTags, List<SpawnPointScript>> _spawnPoints = 
            new Dictionary<CharacterTags, List<SpawnPointScript>>();

        private static Dictionary<EnemyScript, int> _enemiesOnPoints = new Dictionary<EnemyScript, int>();
        public static void Respawn(ICharacterEntity entity)
        {
            var tag = entity.GetTag();
            
            if (!_spawnPoints.ContainsKey(tag))
            {
                return;
            }

            int range = getRange(entity);

            
            _spawnPoints[tag][range].Spawn(entity);
            entity.Spawn();
        }

        private static int _maxTries = 100;
        private static int getRange(ICharacterEntity entity)
        {
            if (entity.GetType() != typeof(EnemyScript)) return Random.Range(0, _spawnPoints[entity.GetTag()].Count);
            
            EnemyScript enemy = (EnemyScript)entity;

            int range = Random.Range(0, _spawnPoints[entity.GetTag()].Count);

            int tries = 0;
            
            while (true)
            {
                if (!_enemiesOnPoints.ContainsValue(range) || tries >= _maxTries)
                {
                    break;
                }

                tries++;
                range = Random.Range(0, _spawnPoints[entity.GetTag()].Count);
            }
            
            _enemiesOnPoints.Add(enemy, range);

            return range;
        }

        public static void OnDeath(ICharacterEntity entity)
        {
            if (entity.GetType() != typeof(EnemyScript)) return;

            EnemyScript enemy = (EnemyScript)entity;
            
            if (_enemiesOnPoints.ContainsKey(enemy))
            {
                _enemiesOnPoints.Remove(enemy);
            }
        }
        public static void AddSpawnPoint(SpawnPointScript spawnPoint)
        {
            foreach (var tag in spawnPoint.GetTags())
            {
                if (!_spawnPoints.ContainsKey(tag))
                {
                    _spawnPoints.Add(tag, new List<SpawnPointScript>());
                }
                
                List<SpawnPointScript> spawnPointScripts = _spawnPoints[tag];


                if (!spawnPointScripts.Contains(spawnPoint))
                {
                    spawnPointScripts.Add(spawnPoint);
                    _spawnPoints[tag] = spawnPointScripts;
                }
            }
        }
    }
}