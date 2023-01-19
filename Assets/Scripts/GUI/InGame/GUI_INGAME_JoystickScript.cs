using Input;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GUI.InGame
{
    public class GUI_INGAME_JoystickScript : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler, IPointerDownHandler,IPointerUpHandler
    {
        private RectTransform _knob;
        
        private bool _isPointerOnTop = false;
        private bool _isDragging = false;

        private MovementController _movementController;

        private void OnEnable()
        {
            _knob = transform.Find("Knob").GetComponent<RectTransform>();
        }

        private void FixedUpdate()
        {
            if (_movementController.IsUnityNull())
            {
                _movementController = GameClient.GetInstance().movementController;
                return;
            }
            if (_isDragging)
            {
                Vector2 vec = InputManager.GetPointerPos(false);
                Vector2 diff = difference(vec,transform.position);
                _knob.transform.position = transform.position + clamped(new Vector3(diff.x, diff.y, 0), 200);
            }
            else
            {
                _knob.transform.localPosition = new Vector3(0,0,0);
            }
            _movementController.MovementInput = GetValue();
        }
        public Vector2 GetValue()
        {
            return _knob.transform.localPosition.normalized;
        }
        private Vector2 difference(Vector2 vec1, Vector2 vec2)
        {
            return new Vector2(vec1.x - vec2.x, vec1.y - vec2.y);
        }
        private Vector3 clamped(Vector3 vec, float radius)
        {
            return Vector3.ClampMagnitude(vec, radius);;
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
                _isDragging = true;
            }
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if (_isDragging)
            {
                _isDragging = false;
            }
        }
    }
}