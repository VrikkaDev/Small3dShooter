using UnityEngine;

namespace Character
{
    public class CharacterBodyPartScript : MonoBehaviour
    {
        [SerializeField]
        private CharacterBodyParts _bodyPart;

        public void OnHit()
        {
            GetComponentInParent<ICharacterEntity>().GotShot(_bodyPart);
        }
    }
}