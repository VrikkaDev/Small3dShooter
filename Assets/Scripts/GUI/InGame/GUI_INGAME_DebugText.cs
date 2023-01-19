using TMPro;
using UnityEngine;

namespace GUI.InGame
{

    public enum DebugTextType
    {
        FPS
    }
    public class GUI_INGAME_DebugText : MonoBehaviour
    {
        [SerializeField]
        private DebugTextType _type;

        private TextMeshProUGUI _text;
        private void OnEnable()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            switch (_type)
            {
                case DebugTextType.FPS:
                    _text.text = "FPS:"+calculateFps();
                    break;
                default:
                    break;
            }
        }
        
        private float _fps = 0;
        private float _delta = 0;

        private float calculateFps()
        {
            _delta += (Time.deltaTime - _delta) * 0.1f;
            _fps = 1.0f / _delta;
            
            return _fps;
        }
    }
}