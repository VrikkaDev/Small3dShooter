using System;
using Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Weapons
{
    //put this script to the Gun object 
    public class WeaponAnimator : MonoBehaviour
    {
        [SerializeField]
        private float _bobbingStrength = 0.001f;
        [SerializeField]
        private float _bobbingSpeed = 5f;

        private MovementController _movementController;

        private void Update()
        {
            if (_movementController.IsUnityNull())
            {
                _movementController = GameClient.GetInstance().movementController;
                return;
            }
            float speed = _movementController.MovementInput.sqrMagnitude;

            if (speed == 0) return;

            Vector3 pos = transform.position;
            pos.y += (float)Math.Sin(Time.time * _bobbingSpeed) * _bobbingStrength * speed;
            transform.position = pos;
        }
    }
}