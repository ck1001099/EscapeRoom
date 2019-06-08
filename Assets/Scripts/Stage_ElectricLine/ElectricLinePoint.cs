using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricLinePoint : MonoBehaviour
{
    public bool isConnect;
    
    public ElectricLinePointTracker tracker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isConnect){
            this.transform.position = tracker.transform.position;
        }
    }

    public void Connect(Vector3 posConnected){
        isConnect = true;
        this.transform.position = posConnected;

        // TODO: animation (now just only change the color)
        this.GetComponent<MeshRenderer>().material.color = new Color(230 / 256f, 220 / 256f, 130 / 256f);
    }

    public void Disconnect(){
        isConnect = false;

        // TODO: animation (now just only change the color)
        this.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
