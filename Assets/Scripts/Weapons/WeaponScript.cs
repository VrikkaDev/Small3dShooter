using Character;
using Player;
using UnityEngine;

namespace Weapons
{
    public class WeaponScript : MonoBehaviour
    {
        public void Shoot()
        {
            var origin = GameClient.GetInstance().cameraController.GetCamera().transform.position;
            GameObject bullet = Instantiate(WeaponManager.BulletPrefab, WeaponManager.BulletsObject.transform);
            bullet.transform.rotation = transform.rotation;
            bullet.transform.position = origin;

            RaycastHit hit;

            if (!Physics.Raycast(origin, transform.forward, out hit, 100)) return;
            Transform hitTransform = hit.transform;
            if (hitTransform.gameObject.CompareTag("Enemy"))
            {
                hitTransform.GetComponent<CharacterBodyPartScript>().OnHit();
            }
        }
    }
}