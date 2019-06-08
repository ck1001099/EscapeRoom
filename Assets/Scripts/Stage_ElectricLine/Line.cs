using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Line : MonoBehaviour
{
    protected LineRenderer line;

    // Start is called before the first frame update
    protected void Start()
    {
        line = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    protected abstract void Update();
}
