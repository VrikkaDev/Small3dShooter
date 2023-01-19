using Input;
using Settings;
using UnityEngine;

namespace Player
{
    public class CameraController : MonoBehaviour
    {
        //Put this script on playerobject

        private GameClient _client;

        private SettingManager _settings;
        private Camera _fpsCamera;
        
        private void Start()
        {
            _client = GameClient.GetInstance();
            _client.cameraController = this;
            _settings = gameObject.GetComponent<SettingManager>();
            _fpsCamera = transform.GetComponentInChildren<Camera>();
        }

        private void Update()
        {
            Vector2 mouseDifference = InputManager.GetMouseDifference(_settings.sensitivity);
            transform.Rotate(mouseDifference.x, mouseDifference.y, 0);
            
            
            //Set z to 0
            Vector2 currentRot = transform.eulerAngles;
            transform.eulerAngles = new Vector3(currentRot.x, currentRot.y, 0f);
        }

        public Camera GetCamera()
        {
            return _fpsCamera;
        }
    }   
}