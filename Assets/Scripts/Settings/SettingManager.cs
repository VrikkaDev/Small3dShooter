using Player;
using UnityEngine;

namespace Settings
{
    //put this script on playerobject
    public class SettingManager : MonoBehaviour
    {
        public Sensitivity sensitivity = new Sensitivity();

        private void Start()
        {
            GameClient.GetInstance().settingManager = this;
            SaveLoadManager.Load(this);
        }
        private void OnApplicationQuit()
        {
            SaveSettings();
        }
        public void SaveSettings()
        {
            SaveLoadManager.Save(this);
        }
    }
}

