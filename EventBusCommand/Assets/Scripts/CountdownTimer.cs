using System.Collections;
using UnityEngine;

namespace Chapter.EventBus
{
    public class CountdownTimer : MonoBehaviour
    {
        private float _currentTime;
        private float duration = 3.0f;

        //will only listen for events when it's active
        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StartTimer);
        }
        void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, StartTimer);
        }
        private void StartTimer()
        {
            StartCoroutine(Countdown());
        }
        private IEnumerator Countdown()
        {
            _currentTime = duration;
            while (_currentTime > 0)
            {
                yield return new WaitForSeconds(1f);
                _currentTime--;
            }
            RaceEventBus.Publish(RaceEventType.START);
        }
        void OnGUI()
        {
            GUI.color = Color.blue;
            GUI.Label(new Rect(125, 0, 200, 20), "COUNTDOWN: " + _currentTime);
        }
    }
}
