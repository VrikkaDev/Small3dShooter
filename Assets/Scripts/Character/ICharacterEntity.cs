
using UnityEngine;

namespace Character
{
    public interface ICharacterEntity
    {
        public CharacterTags GetTag();
        
        public CharacterModes Mode { get; set; }
        public GameObject GetGameObject();
        public float Health { get; set; }
        public void GotShot(CharacterBodyParts bodyPart);

        public void Kill();
        public void Spawn();
    }
}