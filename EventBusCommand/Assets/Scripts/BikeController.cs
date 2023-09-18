using UnityEngine;

namespace Chapter.EventBus
{
    public class BikeController : MonoBehaviour
    {
        public enum Direction
        {
            Left = -1,
            Right = 1
        }
        private string _status;
        private bool _isTurboOn;
        private float _distance = 1.0f;
        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, StartBike);
            RaceEventBus.Subscribe(RaceEventType.STOP, StopBike);
        }
        void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.START, StartBike);
            RaceEventBus.Unsubscribe(RaceEventType.STOP, StopBike);
        }
        private void StartBike()
        {
            _status = "Started";
        }
        private void StopBike()
        {
            _status = "Stopped";
        }
        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(10, 60, 200, 20), "BIKE STATUS: " + _status);
        }
        public void ToggleTurbo()
        {
            _isTurboOn = !_isTurboOn;
        }

        public void Turn(Direction direction)
        {
            if (direction == Direction.Left)
                transform.Translate(Vector3.left * _distance);

            if (direction == Direction.Right)
                transform.Translate(Vector3.right * _distance);
        }

        public void ResetPosition()
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}