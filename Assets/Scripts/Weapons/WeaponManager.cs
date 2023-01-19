using UnityEngine;

namespace Weapons
{
    public class WeaponManager : MonoBehaviour
    {
        public static GameObject BulletPrefab;
        public static GameObject BulletsObject;
        public static WeaponScript CurrentWeapon;

        [SerializeField]
        private GameObject _bulletPrefab;
        private void Start()
        {
            BulletPrefab = _bulletPrefab;
            CurrentWeapon = GetComponentInChildren<WeaponScript>();
            BulletsObject = GameObject.Find("Bullets");
        }
    }
}