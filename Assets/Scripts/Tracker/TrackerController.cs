using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[System.Serializable]
public class TrackerController
{   
    public SteamVR_TrackedObject.EIndex tracker1;
    public SteamVR_TrackedObject.EIndex tracker2;
    public SteamVR_TrackedObject.EIndex tracker3;
    public SteamVR_TrackedObject.EIndex tracker4;
    public SteamVR_TrackedObject.EIndex tracker5;
    public SteamVR_TrackedObject.EIndex tracker6;
    public SteamVR_TrackedObject.EIndex tracker7;
    public SteamVR_TrackedObject.EIndex tracker8;
    public SteamVR_TrackedObject.EIndex tracker9;
    public SteamVR_TrackedObject.EIndex tracker10;

    public enum TrackerIndex
    {
        Tracker1,
        Tracker2,
        Tracker3,
        Tracker4,
        Tracker5,
        Tracker6,
        Tracker7,
        Tracker8,
        Tracker9,
        Tracker10,
    }

    public static SteamVR_TrackedObject.EIndex GetIndex(TrackerIndex index){
        if (GameController.singleton == null){
            return GameController.singleton.trackerController.tracker1;
        }

        if (index == TrackerIndex.Tracker1) return GameController.singleton.trackerController.tracker1;
        else if (index == TrackerIndex.Tracker2) return GameController.singleton.trackerController.tracker2;
        else if (index == TrackerIndex.Tracker3) return GameController.singleton.trackerController.tracker3;
        else if (index == TrackerIndex.Tracker4) return GameController.singleton.trackerController.tracker4;
        else if (index == TrackerIndex.Tracker5) return GameController.singleton.trackerController.tracker5;
        else if (index == TrackerIndex.Tracker6) return GameController.singleton.trackerController.tracker6;
        else if (index == TrackerIndex.Tracker7) return GameController.singleton.trackerController.tracker7;
        else if (index == TrackerIndex.Tracker8) return GameController.singleton.trackerController.tracker8;
        else if (index == TrackerIndex.Tracker9) return GameController.singleton.trackerController.tracker9;
        else if (index == TrackerIndex.Tracker10) return GameController.singleton.trackerController.tracker10;
        else return GameController.singleton.trackerController.tracker1;
    }
}
