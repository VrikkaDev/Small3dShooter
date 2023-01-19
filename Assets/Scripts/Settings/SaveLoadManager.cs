using System;
using UnityEngine;

namespace Settings
{
    public class SaveLoadManager
    {

        private enum m_SaveKeys
        {
            Sensitivity_x = 0,
            Sensitivity_y = 1,
            Acceleration_x = 2,
            Acceleration_y = 3
        }
        
        public static void Save(SettingManager settingManager)
        {
            PlayerPrefs.SetFloat(m_SaveKeys.Sensitivity_x.ToString(), settingManager.sensitivity.Value.x);
            PlayerPrefs.SetFloat(m_SaveKeys.Sensitivity_y.ToString(), settingManager.sensitivity.Value.y);
            PlayerPrefs.SetFloat(m_SaveKeys.Acceleration_x.ToString(), settingManager.sensitivity.Acceleration.x);
            PlayerPrefs.SetFloat(m_SaveKeys.Acceleration_y.ToString(), settingManager.sensitivity.Acceleration.y);
            
            PlayerPrefs.Save();
        }

        public static void Load(SettingManager settingManager)
        {
            foreach (m_SaveKeys key in (m_SaveKeys[])
                     Enum.GetValues(typeof(m_SaveKeys)))
            {

                if (!PlayerPrefs.HasKey(key.ToString()))
                {
                    continue;
                }
                
                switch (key)
                {
                    case m_SaveKeys.Sensitivity_x:

                        float sensX = PlayerPrefs.GetFloat(key.ToString());
                        if (!Sensitivity.IsValidSensitivity(sensX)) { continue; }

                        float currentSensY = settingManager.sensitivity.Value.y;
                        
                        settingManager.sensitivity.Value = new Vector2(sensX, currentSensY);
                        break;
                    case m_SaveKeys.Sensitivity_y:
                        
                        float sensY = PlayerPrefs.GetFloat(key.ToString());
                        if (!Sensitivity.IsValidSensitivity(sensY)) { continue; }

                        float currentSensX = settingManager.sensitivity.Value.x;
                        
                        settingManager.sensitivity.Value = new Vector2(currentSensX, sensY);
                        break;
                    case m_SaveKeys.Acceleration_x:
                        
                        float accX = PlayerPrefs.GetFloat(key.ToString());
                        if (!Sensitivity.IsValidAcceleration(accX)) { continue; }

                        float currentAccY = settingManager.sensitivity.Acceleration.y;
                        
                        settingManager.sensitivity.Acceleration = new Vector2(accX, currentAccY);
                        break;
                    case m_SaveKeys.Acceleration_y:
                        
                        float accY = PlayerPrefs.GetFloat(key.ToString());
                        if (!Sensitivity.IsValidAcceleration(accY)) { continue; }

                        float currentAccX = settingManager.sensitivity.Acceleration.x;
                        
                        settingManager.sensitivity.Acceleration = new Vector2(currentAccX, accY);
                        break;
                    
                    default:
                        break;
                }
            }
        }
    }
}