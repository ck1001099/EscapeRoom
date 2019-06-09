using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController singleton;

    public List<GameObject> stages;
    
    public TrackerController trackerController;

    // Start is called before the first frame update
    void Start()
    {
        if (GameController.singleton == null){
            singleton = this;
        } else {
            Destroy(this);
        }

        StartCoroutine(GameFlow());
    }

    IEnumerator GameFlow(){
        foreach (GameObject stage in stages){
            StageController stageController = stage.GetComponent<StageController>();
            stageController.Initialization();
            while (!stageController.IsCompleted()){
                yield return null;
            }
        }
        
    }
}
