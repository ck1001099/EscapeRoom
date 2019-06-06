﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController singleton;

    // Start is called before the first frame update
    void Start()
    {
        if (GameController.singleton == null){
            singleton = this;
        } else {
            Destroy(this);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
