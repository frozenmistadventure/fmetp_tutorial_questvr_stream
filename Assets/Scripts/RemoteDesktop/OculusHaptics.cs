using System.Collections;
using UnityEngine;
/// <summary>
/// This script is responsible for the vibrations of the controller
/// </summary>
public enum VibrationForce {
    Light,
    Medium,
    Hard,
}


public class OculusHaptics : MonoBehaviour {


    private OVRHapticsClip clipLight;
    private OVRHapticsClip clipMedium;
    private OVRHapticsClip clipHard;
    public static OculusHaptics instance;
    private bool forcedHaptic;

    public float lowViveHaptics { get; private set; }
    public float mediumViveHaptics { get; private set; }
    public float hardViveHaptics { get; private set; }


    private void Start() {
        InitializeOVRHaptics();
        instance = this;
    }
    //short vibration
    public static IEnumerator Vibrate(float frequency, float amplitude, OVRInput.Controller m_controller) {
        OVRInput.SetControllerVibration(frequency, amplitude, m_controller);
        yield return new WaitForSeconds(0.1f);
        OVRInput.SetControllerVibration(0, 0, m_controller);
    }
    //long vibraion, has to be turned off
    public static void ConstantVibrate(OVRInput.Controller m_controller) {
        OVRInput.SetControllerVibration(0.1f, 0.09f, m_controller);

    }
    public static void StopVibrate(OVRInput.Controller m_controller) {
        OVRInput.SetControllerVibration(0.0f, 0.0f, m_controller);

    }
    private void InitializeOVRHaptics() {

        int cnt = 10;
        clipLight = new OVRHapticsClip(cnt);
        clipMedium = new OVRHapticsClip(cnt);
        clipHard = new OVRHapticsClip(cnt);
        for (int i = 0; i < cnt; i++) {
            clipLight.Samples[i] = i % 2 == 0 ? (byte)0 : (byte)45;
            clipMedium.Samples[i] = i % 2 == 0 ? (byte)0 : (byte)100;
            clipHard.Samples[i] = i % 2 == 0 ? (byte)0 : (byte)180;
        }

        clipLight = new OVRHapticsClip(clipLight.Samples, clipLight.Samples.Length);
        clipMedium = new OVRHapticsClip(clipMedium.Samples, clipMedium.Samples.Length);
        clipHard = new OVRHapticsClip(clipHard.Samples, clipHard.Samples.Length);
    }


    void OnEnable() {
        InitializeOVRHaptics();
        instance = this;

    }

    public void Vibrate(VibrationForce vibrationForce, OVRHaptics.OVRHapticsChannel channel) {
        switch (vibrationForce) {
            case VibrationForce.Light:
            channel.Preempt(clipLight);
            break;
            case VibrationForce.Medium:
            channel.Preempt(clipMedium);
            break;
            case VibrationForce.Hard:
            channel.Preempt(clipHard);
            break;
        }
    }



    public IEnumerator VibrateTime(VibrationForce force, float time, OVRHaptics.OVRHapticsChannel channel) {
        forcedHaptic = true;
        

        for (float t = 0; t <= time; t += Time.deltaTime) {
            switch (force) {
                case VibrationForce.Light:
                channel.Queue(clipLight);
                break;
                case VibrationForce.Medium:
                channel.Queue(clipMedium);
                break;
                case VibrationForce.Hard:
                channel.Queue(clipHard);
                break;
            }
        }
        yield return new WaitForSeconds(time);
        channel.Clear();
        forcedHaptic = false;
        yield return null;

    }
}