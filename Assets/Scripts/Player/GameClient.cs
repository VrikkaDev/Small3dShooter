using System;
using Enemy;
using GUI;
using Settings;
using UnityEngine;

namespace Player
{
    public class GameClient : MonoBehaviour
    {
        private static GameClient _instance;
        public static GameClient GetInstance()
        {
            return _instance;
        }
        [NonSerialized]
        public SettingManager settingManager;
        [NonSerialized]
        public PlayerScript player;
        [NonSerialized]
        public GuiManager guiManager;
        [NonSerialized] 
        public MovementController movementController;
        [NonSerialized] 
        public CameraController cameraController;
        [NonSerialized] 
        public EnemyManager enemyManager;

        private void Awake()
        {
            _instance = this;
        }
    }
}