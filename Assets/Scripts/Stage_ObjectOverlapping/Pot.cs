using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public Transform waterOutPos;

    public GameObject waterDropPref;
    public float waterDropGenerateTime = 0.2f;
    public float waterDropGenerateTimer;


    public Transform checkPoint1;
    public Transform checkPoint2;

    public float startWaterOutRz = 30f;
    public float endWaterOutRz = 210f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkPoint1.position.y < checkPoint2.position.y){
            if (waterDropGenerateTimer > waterDropGenerateTime){
                waterDropGenerateTimer = 0f;
                GameObject obj = GameObject.Instantiate(waterDropPref);
                obj.transform.position = waterOutPos.position;
            } else {
                waterDropGenerateTimer = waterDropGenerateTimer + Time.deltaTime;
            }
        } else {
            waterDropGenerateTimer = 0f;
        }
    }
}
