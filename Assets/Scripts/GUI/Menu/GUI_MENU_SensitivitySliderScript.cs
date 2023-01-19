using System;
using Player;
using Settings;
using TMPro;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

namespace GUI.Menu
{
    public enum SensitivityDirection
    {
        X,
        Y
    }

    public enum SensitivityType
    {
        Sensitivity,
        Acceleration
    }
    public class GUI_MENU_SensitivitySliderScript : MonoBehaviour
    {
        private Slider _slider;
        private TextMeshProUGUI _text;

        [SerializeField]
        private SensitivityDirection _direction;
        [SerializeField]
        private SensitivityType _sensitivityType;
        
        private SettingManager _settingManager;

        private bool _initialized = false;
        private void OnEnable()
        {
            _slider = gameObject.GetComponent<Slider>();
            _text = GetComponentInChildren<TextMeshProUGUI>();

            _settingManager = GameClient.GetInstance().settingManager;

            if (_sensitivityType == SensitivityType.Sensitivity)
            {
                _slider.minValue = Sensitivity.SensitivityRange.min;
                _slider.maxValue = Sensitivity.SensitivityRange.max;

                _slider.value = (_direction == SensitivityDirection.X
                    ? _settingManager.sensitivity.Value.x
                    : _settingManager.sensitivity.Value.y);
            }
            else
            {
                _slider.minValue = Sensitivity.AccelerationRange.min;
                _slider.maxValue = Sensitivity.AccelerationRange.max;
                
                _slider.value = (_direction == SensitivityDirection.X
                    ? _settingManager.sensitivity.Acceleration.x
                    : _settingManager.sensitivity.Acceleration.y);
            }

            _initialized = true;
            
            UpdateText();
        }

        private void UpdateText()
        {
            _text.text = _sensitivityType + " " + _direction + ": " + _slider.value;
        }
        
        public void OnValueChanged()
        {

            if (!_initialized)
            {
                return;
            }
            
            float sliderValue = _slider.value;
            
            
            _slider.value = (float)Math.Round(sliderValue, 2);

                if (_sensitivityType == SensitivityType.Sensitivity)
            {
                _settingManager.sensitivity.Value = (_direction == SensitivityDirection.X
                    ? new Vector2(sliderValue, _settingManager.sensitivity.Value.y)
                    : new Vector2(_settingManager.sensitivity.Value.x, sliderValue));
            }
            else
            {
                _settingManager.sensitivity.Acceleration = (_direction == SensitivityDirection.X
                    ? new Vector2(sliderValue, _settingManager.sensitivity.Acceleration.y)
                    : new Vector2(_settingManager.sensitivity.Acceleration.x, sliderValue));
            }
            UpdateText();
        }

        public void ResetToDefault()
        {
            var sens = new Sensitivity();
            _slider.value = (_sensitivityType == SensitivityType.Sensitivity
                ? (_direction == SensitivityDirection.X ? sens.Value.x : sens.Value.y)
                : (_direction == SensitivityDirection.X ? sens.Acceleration.x : sens.Acceleration.y));
        }
    }
}