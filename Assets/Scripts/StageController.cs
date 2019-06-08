using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StageController
{
    void Initialization();
    bool IsCompleted();
    void End();
}
