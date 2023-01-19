using UnityEngine;

namespace Weapons
{
    public class BulletScript : MonoBehaviour
    {
        private const float _bulletSpeed = 50f;
        private Vector3 _startingPosition;

        private void Start()
        {
            _startingPosition = transform.position;
        }

        private void FixedUpdate()
        {
            transform.Translate(0,0,_bulletSpeed * Time.deltaTime, Space.Self);


            if (Vector3.Distance(_startingPosition, transform.position) > 100)
            {
                Destroy(gameObject);
            }
        }
    }
}