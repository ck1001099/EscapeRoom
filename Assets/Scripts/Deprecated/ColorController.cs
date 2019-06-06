using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorController : MonoBehaviour
{
    public float currentTime;
    public Text clockText;

    public Color brightBlue;
    public Color brightRed;
    public Color darkRed;
    public Color darkBlue;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = 12f;
        brightBlue = new Color(214f / 256f, 236f / 256f, 248f / 256f);
        brightRed = new Color(234f / 256, 230f / 256f, 224f / 256f);
        darkRed = new Color(241f / 256f, 115f / 256f, 92f / 256f);
        darkBlue = new Color(72f / 256f, 80f / 256f, 111f / 256f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float timePass = Input.GetAxis("Horizontal");
        if (currentTime > 8 && currentTime < 24) {
            currentTime = currentTime + timePass * 0.1f;
        }
        else if (currentTime <= 8) { 
            if (timePass > 0) { currentTime = currentTime + timePass * 0.1f; }
            else { currentTime = 8f; }
        }
        else if (currentTime >= 24)
        {
            if (timePass < 0) { currentTime = currentTime + timePass * 0.1f; }
            else { currentTime = 24f; }
        }


        // set clock
        int hour = (int)currentTime;
        int minute = (int)((int)(currentTime * 60f) % 60f);
        clockText.text = "Time = " + hour.ToString() + ":" + minute.ToString("00");


        // change color
        if (currentTime <= 11) { gameObject.GetComponent<MeshRenderer>().material.color = brightBlue; }
        else if (currentTime <= 13)
        { 
            gameObject.GetComponent<MeshRenderer>().material.color = GetMixedColor(brightBlue, brightRed, 11, 13);
        }
        else if (currentTime <= 15) 
        {
            gameObject.GetComponent<MeshRenderer>().material.color = brightRed; 
        }
        else if (currentTime <= 17)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = GetMixedColor(brightRed, darkRed, 15, 17);
        }
        else if (currentTime <= 18) 
        {
            gameObject.GetComponent<MeshRenderer>().material.color = darkRed; 
        }
        else if (currentTime <= 19)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = GetMixedColor(darkRed, darkBlue, 18, 19);
        }
        else {
            gameObject.GetComponent<MeshRenderer>().material.color = darkBlue; }
    }

    private Color GetMixedColor(Color color1, Color color2, float lowerBound, float upperBound)
    {
        float ratio = (currentTime - lowerBound) / (upperBound - lowerBound);
        Color mixedColor = color1 * (1 - ratio) + color2 * ratio;
        return mixedColor;
    }

}
