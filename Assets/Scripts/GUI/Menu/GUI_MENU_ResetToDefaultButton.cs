using System.Collections.Generic;
using UnityEngine;

namespace GUI.Menu
{
    public class GUI_MENU_ResetToDefaultButton : MonoBehaviour
    {
        private List<GUI_MENU_SensitivitySliderScript> _sliders;

        private void OnEnable()
        {
            _sliders = new List<GUI_MENU_SensitivitySliderScript>(transform.parent
                .GetComponentsInChildren<GUI_MENU_SensitivitySliderScript>());
        }

        public void OnButtonPress()
        {
            foreach (var slider in _sliders)
            {
                slider.ResetToDefault();
            }
        }
    }
}