using Player;
using UnityEngine;

namespace GUI
{
    public class GuiManager : MonoBehaviour
    {
        [SerializeField] private Canvas StartingCanvas;
        private Canvas _activeCanvas;
        
        private void Start()
        {
            GameClient.GetInstance().guiManager = this;
            foreach (var canvas in transform.GetComponentsInChildren<Canvas>())
            {
                if (canvas.gameObject != gameObject)
                {
                    canvas.gameObject.SetActive(false);
                }
            }

            StartingCanvas.gameObject.SetActive(true);
            _activeCanvas = StartingCanvas;
        }

        public Canvas GetActiveCanvas()
        {
            return _activeCanvas;
        }

        public void SetActiveCanvas(Canvas canvas)
        {
            _activeCanvas.gameObject.SetActive(false);
            _activeCanvas = canvas;
            _activeCanvas.gameObject.SetActive(true);
        }
    }
}