using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{

    public GameObject point1;
    public GameObject point2;
    public Vector3 delta;
    public float deltaX;
    public float deltaY;
    public float deltaZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (point1.transform.position + point2.transform.position) / 2f;
        transform.localScale = new Vector3(0.3f, Vector3.Magnitude(delta), 0.3f); 


        // point1.transform.position + point2.transform.position
        delta = point1.transform.position - point2.transform.position;
        deltaX = delta.x;
        deltaY = delta.y;
        deltaZ = delta.z;
        transform.eulerAngles = new Vector3(Mathf.Cos(deltaX/deltaY), 30, 0);
    }
}
