using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FMETP
{
    public class FMOVRInput : MonoBehaviour
    {
        public GameObject TestObject;
        // Start is called before the first frame update
        void Start()
        {
            //OVRInput.GetActiveController();
        }

        [SerializeField] private OVRInput.Controller controller = OVRInput.Controller.RTouch;
        [SerializeField] private OVRInput.Button button = OVRInput.Button.PrimaryIndexTrigger;

        public UnityEventInt OnInputGetKeyEvent = new UnityEventInt();

        [SerializeField] private int eventInt = 0;
        private void Update()
        {
            int _eventInt = 0;
            if (OVRInput.GetDown(button, controller))
            {
                _eventInt = 1;
#if !UNITY_EDITOR
                StartCoroutine(OculusHaptics.Vibrate(0.4f, 0.1f, controller));
#endif
            }
            else if (OVRInput.GetUp(button, controller))
            {
                _eventInt = 2;
            }
            else if (OVRInput.Get(button, controller))
            {
                _eventInt = 3;
            }

            //down(1) and up(2) only trigger once, while drag(3) can be triggered every frame
            if (eventInt != _eventInt || _eventInt == 3)
            {
                eventInt = _eventInt;
                OnInputGetKeyEvent.Invoke(eventInt);
            }
        }

        private void OnDisable()
        {
            eventInt = 0;
            OnInputGetKeyEvent.Invoke(eventInt);
        }
    }
}