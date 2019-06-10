using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public List<Material> skyboxs;
    public Light light;
    
    public float timer;

    public bool hasStart = false;

    public int index = 0;
    public float timePoint1 = 12f;
    public float timePoint2 = 9f;
    public float timePoint3 = 18f;

    public float changeRate = 0.1f;

    public float timeChangePause = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            Debug.Log("Start");
            hasStart = true;
            timeChangePause = 3f;
            timer = 12f;
            index = 0;
            return;
        }

        if (!hasStart){
            return;
        }

        if (index == 0){
            timer = timePoint1;
            index = 1;
        } else if (index == 1){
            timer = timer - Time.deltaTime * changeRate;
            if (timer < timePoint2){
                index = 2;
            }
        } else if (index == 2){
            timeChangePause = timeChangePause - Time.deltaTime;
            if (timeChangePause < 0f){
                index = 3;
            }
        } else if (index == 3){
            timer = timer + Time.deltaTime * changeRate;
            if (timer > timePoint3){
                index = 4;
            }
        }


        
        timer = timer % 24;
        
        int skyboxIndex = (int)(skyboxs.Count * (timer - 6f) / (18f - 6f));
        Debug.Log(skyboxIndex);

        if (timer < 6f || timer > 18f){
            light.intensity = 0f;
        } else {
            RenderSettings.skybox = skyboxs[skyboxIndex];
            light.intensity = 2f * (1f - Mathf.Abs((timer - 12f) / (12f - 6f)));
            light.transform.parent.eulerAngles = new Vector3(0f, 0f, 90f * (timer - 12f) / (12f - 6f));
        }
        
    }
}
