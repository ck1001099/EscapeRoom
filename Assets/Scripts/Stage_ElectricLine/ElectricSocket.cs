using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSocket : MonoBehaviour
{
    public bool isConnected;
    
    public GameObject objConnected;

    public Transform connectPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        ElectricLinePointTracker tracker = other.GetComponent<ElectricLinePointTracker>();
        if (tracker != null){
            if (!isConnected){
                tracker.ConnectPoint(connectPoint.position);
                ConnectObject(tracker.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other){
        if (GameObject.ReferenceEquals(other.gameObject, objConnected)){
            DisconnectObject();
            other.GetComponent<ElectricLinePointTracker>().Disconnect();
        }
    }

    void ConnectObject(GameObject obj){
        isConnected = true;
        objConnected = obj;
        // TODO: animation
    }

    void DisconnectObject(){
        isConnected = false;
        objConnected = null;
        // TODO: animation
    }
}
