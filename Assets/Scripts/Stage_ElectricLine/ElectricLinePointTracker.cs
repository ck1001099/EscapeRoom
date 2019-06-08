using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricLinePointTracker : MonoBehaviour
{
    public ElectricLinePoint point;
    
    public void ConnectPoint(Vector3 posConnected){
        point.Connect(posConnected);
    }

    public void Disconnect(){
        point.Disconnect();
    }
}
