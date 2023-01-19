using Character;
using UnityEngine;

namespace Player
{
    public class PlayerScript : MonoBehaviour, ICharacterEntity
    {
        private void Start()
        {
            GameClient.GetInstance().player = this;
        }

        public CharacterTags GetTag()
        {
            return CharacterTags.Player;
        }
        public CharacterModes Mode { get; set; }
        public GameObject GetGameObject()
        {
            return gameObject;
        }
        
        public void GotShot(CharacterBodyParts bodyPart)
        {
        }
        public float Health { get; set; }
        public void Kill()
        {
        }
        public void Spawn()
        {
        }
    }
}
