using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class TrackerClient : MonoBehaviour
{
    public SteamVR_TrackedObject target;

    public TrackerController.TrackerIndex trackerIndex;

    void Reset()
    {
        target = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        target.index = TrackerController.GetIndex(trackerIndex);
    }
}