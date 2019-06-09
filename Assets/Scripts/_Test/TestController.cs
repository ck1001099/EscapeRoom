using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test{
    public class TestController : MonoBehaviour
    {
        public string ObjectOverlapping_DisplayTime = "10.0.1.61/DisplayTime";

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(ServerController.ObjectOverlapping_DisplayTime(ObjectOverlapping_DisplayTime, () => {
                Debug.Log("Good!!");
            }));
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}