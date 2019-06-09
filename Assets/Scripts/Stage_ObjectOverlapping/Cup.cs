using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public GameObject cupTop;
    public GameObject cupBottom;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if (GameObject.ReferenceEquals(other.gameObject, target)){
            cupBottom.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (GameObject.ReferenceEquals(other.gameObject, target)){
            cupBottom.SetActive(false);
        }
    }
}
