using System;
using UnityEngine;

namespace Player
{
    //Set This script to playerObject
    public class MovementController : MonoBehaviour
    {
        [SerializeField]
        private float _maxSpeed = 3f;

        //this variable is been set bu GUI.InGame.GUI_INGAME_JoystickScript.cs
        [NonSerialized] public Vector2 MovementInput = Vector2.zero;

        private void Start()
        {
            GameClient.GetInstance().movementController = this;
        }

        private Vector3 _vector3;
        private void Update()
        {
            _vector3 = transform.right * MovementInput.x;
            _vector3 += transform.forward * MovementInput.y;
            _vector3 *= Time.deltaTime * _maxSpeed;
            transform.position += _vector3;
        }
    }
}