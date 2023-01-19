using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using Unity.VisualScripting;
using UnityEngine;

namespace Map
{
    public class SpawnPointScript : MonoBehaviour
    {
        [SerializeField]
        private List<CharacterTags> SpawnableTags = new List<CharacterTags>();

        private void Awake()
        {
            RespawnManager.AddSpawnPoint(this);
        }

        public List<CharacterTags> GetTags()
        {
            return SpawnableTags;
        }
        
        public void Spawn(ICharacterEntity characterEntity)
        {
            if (transform.IsUnityNull()) return;

            characterEntity.Mode = CharacterModes.Alive;
            characterEntity.GetGameObject().transform.position = transform.position;
        }
    }
}

