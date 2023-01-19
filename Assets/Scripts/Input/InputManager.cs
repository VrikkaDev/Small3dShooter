using Settings;
using UnityEngine;

namespace Input
{
    public class InputManager
    {
        private static Vector2 _currentPos = new Vector2(200,200);
        
        //This whole touch input system doesnt work properly when added more than 2 fingers but it is perfectly fine for this project

        //Returns the difference of previous mousepos and current.
        public static Vector2 GetMouseDifference(Sensitivity sensitivity)
        {
            Vector2 pointerPos = GetPointerPos(true);

            if (pointerPos.magnitude == 0f)
            {
                _currentPos = Vector2.zero;
                return Vector2.zero;
            }
            if (_currentPos.magnitude == 0f)
            {
                _currentPos = pointerPos;
            }

            _currentPos = pointerPos- _currentPos ;
            Vector3 vec = new Vector3(-_currentPos.y * 0.1f * sensitivity.Value.y * sensitivity.Acceleration.y,
                _currentPos.x * 0.1f * sensitivity.Value.x * sensitivity.Acceleration.x, 0 );
            _currentPos = pointerPos;

            return vec;
        }
        
        public static Vector2 GetPointerPos(bool onRight)
        {
            float middlepoint = (Screen.width / 2);
            Vector2 pos = Vector2.zero;
            for (var i = 0; i < UnityEngine.Input.touchCount;i++)
            {
                Touch touch = UnityEngine.Input.GetTouch(i);

                if (onRight && touch.position.x <= middlepoint)
                {
                    continue;
                }else if (!onRight && touch.position.x >= middlepoint)
                {
                    continue;
                }

                pos = UnityEngine.Input.GetTouch(i).position;
            }

            return pos;
        }
        
    }
}