using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSocketManager : MonoBehaviour
{
    public List<ElectricSocket> electricSockets;
    
    // TODO: more sockets and random choose two
    // TODO: combine these two into a data structure
    // public List<Vector3> positions;
    // public List<Vector3> directions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ElectricSocket socket in electricSockets){
            if (!socket.isConnected){
                return;
            }
        }

        StageElectricLine.singleton.End();
        this.enabled = false;
    }

    
}
