using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricLine : MonoBehaviour
{   
    private LineRenderer line;

    public Transform point1;
    public Transform point2;
    
    // Start is called before the first frame update
    void Start()
    {
        line = this.GetComponent<LineRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, point1.position);
        line.SetPosition(1, point2.position);
    }
}
