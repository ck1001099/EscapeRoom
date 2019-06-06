using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{

    //private Color targetColor = new Color(230 / 256f, 220 / 256f, 130 / 256f);
    //private Color otherColor = new Color(256 / 256f, 256 / 256f, 256 / 256f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<MeshRenderer>().material.color = otherColor;
    }


    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Target (1)")
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color = targetColor;
            //count = count + 1;
        }
        if (other.gameObject.name == "Target (2)")
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color = targetColor;
            //count = count + 1;
        }
    }*/
}
