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
        [SerializeField] private KeyCode debugKeyCode = KeyCode.None;
        private void Update()
        {
            int _eventInt = 0;
            if (OVRInput.GetDown(button, controller) || Input.GetKeyDown(debugKeyCode))
            {
                _eventInt = 1;
#if !UNITY_EDITOR
                StartCoroutine(OculusHaptics.Vibrate(0.4f, 0.1f, controller));
#endif
            }
            else if (OVRInput.GetUp(button, controller) || Input.GetKeyUp(debugKeyCode))
            {
                _eventInt = 2;
            }
            else if (OVRInput.Get(button, controller) || Input.GetKey(debugKeyCode))
            {
                _eventInt = 3;
            }

            if (eventInt != _eventInt)
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