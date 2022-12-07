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

        public UnityEventBool OnInputGetKeyEvent = new UnityEventBool();

        public
        // Update is called once per frame
        void Update()
        {
            if (OVRInput.GetDown(button, controller) || Input.GetKeyDown(KeyCode.Space))
            {
                TestObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                OnInputGetKeyEvent.Invoke(true);

                StartCoroutine(OculusHaptics.Vibrate(0.4f, 0.2f, controller));

            }
            if (OVRInput.GetUp(button, controller) || Input.GetKeyUp(KeyCode.Space))
            {
                TestObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                OnInputGetKeyEvent.Invoke(false);
            }
        }
    }
}