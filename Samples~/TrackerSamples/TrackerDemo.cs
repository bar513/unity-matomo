//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System.Collections;
using UnityEngine;

namespace Lumpn.Matomo.Demo
{
    public class TrackerDemo : MonoBehaviour
    {
        [SerializeField] private MatomoTrackerData trackerData;
        [SerializeField] private int numRecords = 10;

        IEnumerator Start()
        {
            var tracker = trackerData.CreateTracker();
            var session = tracker.CreateSession("user1234");

            for (int i = 0; i < numRecords; i++)
            {
                using (var request = session.CreateWebRequest("Start", "TrackerDemo/Start", Random.value))
                {
                    yield return request.SendWebRequest();
                    Debug.Log(request.responseCode);
                    Debug.Log(request.downloadHandler.text);
                }
            }
        }
    }
}