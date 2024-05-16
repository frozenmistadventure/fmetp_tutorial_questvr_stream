using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace FMSolution
{
    public class OculusPerformanceManager : MonoBehaviour
    {
        // Start is called before the first frame update
        private IEnumerator Start()
        {
            yield return new WaitForSecondsRealtime(3f);
            if (Unity.XR.Oculus.Performance.TryGetDisplayRefreshRate(out var rate))
            {
                float newRate = 90f; // fallback to this value if the query fails.
                if (Unity.XR.Oculus.Performance.TryGetAvailableDisplayRefreshRates(out var rates))
                {
                    newRate = rates.Max();
                }
                if (rate < newRate)
                {
                    if (Unity.XR.Oculus.Performance.TrySetDisplayRefreshRate(newRate))
                    {
                        Time.fixedDeltaTime = 1f / newRate;
                        Time.maximumDeltaTime = 1f / newRate;
                    }
                }
            }

            if (Unity.XR.Oculus.Performance.TrySetCPULevel(2))
            {
                //it works
            }
            if (Unity.XR.Oculus.Performance.TrySetGPULevel(2))
            {
                //it works
            }
        }
    }
}