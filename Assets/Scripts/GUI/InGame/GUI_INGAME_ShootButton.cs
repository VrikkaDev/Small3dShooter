using UnityEngine;
using UnityEngine.EventSystems;
using Weapons;

namespace GUI.InGame
{
    public class GUI_INGAME_ShootButton : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler, IPointerDownHandler,IPointerUpHandler
    {
        private bool _isPointerOnTop = false;
        private bool _isHolding = false;

        private int _lastTime = 0;
        private void FixedUpdate()
        {
            if (_lastTime > 0)
            {
                _lastTime--;
            }
            
            if (_isHolding && _lastTime <= 0)
            {
                _lastTime = 10;
                WeaponManager.CurrentWeapon.Shoot();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _isPointerOnTop = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isPointerOnTop = false;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isPointerOnTop)
            {
                _isHolding = true;
            }
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if (_isHolding)
            {
                _isHolding = false;
            }
        }
    }
}