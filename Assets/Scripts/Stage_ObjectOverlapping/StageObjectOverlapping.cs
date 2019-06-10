using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObjectOverlapping : MonoBehaviour, StageController
{
    public static StageObjectOverlapping singleton;

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
        Debug.Log("[Stage Start] Stage Name: StageObjectOverlapping");
        this.gameObject.SetActive(true);
        isCompleted = false;
    }

    public bool IsCompleted(){
        return isCompleted;
    }

    public void End(){
        isCompleted = true;
        Debug.Log("[Stage End] Stage Name: StageObjectOverlapping");
    }
}
