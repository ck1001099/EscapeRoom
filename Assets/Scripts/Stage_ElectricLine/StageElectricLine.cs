using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class StageElectricLine : MonoBehaviour, StageController
{
    public static StageElectricLine singleton;

    public ElectricLine electricLine;

    private bool isCompleted;
    
    // Start is called before the first frame update
    void Start()
    {
        if (singleton == null){
            singleton = this;
        } else {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialization(){
        Debug.Log("[Stage Start] Stage Name: StageElectricLine");
        this.gameObject.SetActive(true);
        isCompleted = false;
    }

    public bool IsCompleted(){
        return isCompleted;
    }

    public void End(){
        electricLine.GetComponent<LineRenderer>().material.color = new Color(230 / 256f, 220 / 256f, 130 / 256f);

        electricLine.point1.GetComponent<ElectricLinePoint>().tracker.GetComponent<SteamVR_TrackedObject>().enabled = false;
        electricLine.point2.GetComponent<ElectricLinePoint>().tracker.GetComponent<SteamVR_TrackedObject>().enabled = false;

        StartCoroutine(EndAnimation( () => {
            isCompleted = true;
            Debug.Log("[Stage End] Stage Name: StageElectricLine");
        }));
    }

    IEnumerator EndAnimation(System.Action callback){
        // TODO: light house
        yield return null;

        callback();
    }
}
