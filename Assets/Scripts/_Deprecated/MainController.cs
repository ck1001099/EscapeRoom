using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    private const string gameRuleText = "w/s/a/d: up/down/left/right \nf: front/g: down \nh: change target";
    private const string finishText = "Finish!";
    private Color targetColor = new Color(230 / 256f, 220 / 256f, 130 / 256f);
    private Color otherColor = new Color(256 / 256f, 256 / 256f, 256 / 256f);

    public float distance; // distance between two points
    public float stepSize;
    public string targetPoint;
    public Text targetText;
    public Text GameRuleText;


    // Start is called before the first frame update
    void Start()
    {
        stepSize = 0.1f;
        targetPoint = "Point (1)";
        GameRuleText.text = gameRuleText;
        GameObject.Find(targetPoint).GetComponent<MeshRenderer>().material.color = targetColor;
        SetText();
    }

    // Update is called once per frame
    void Update()
    {

        // select the target point
        if (CheckFinish(GameObject.Find("Target (1)"), GameObject.Find("Target (2)")) == false) {
            if (Input.GetKey("h"))
            {
                if (targetPoint == "Point (2)")
                {
                    GameObject.Find(targetPoint).GetComponent<MeshRenderer>().material.color = otherColor;
                    targetPoint = "Point (1)";
                    GameObject.Find(targetPoint).GetComponent<MeshRenderer>().material.color = targetColor;

                }
                else
                {
                    GameObject.Find(targetPoint).GetComponent<MeshRenderer>().material.color = otherColor;
                    targetPoint = "Point (2)";
                    GameObject.Find(targetPoint).GetComponent<MeshRenderer>().material.color = targetColor;
                }
                //SetText();
            }

            // control the position of Point (1) or (2)
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            GameObject.Find(targetPoint).transform.position += new Vector3(moveHorizontal, moveVertical, 0) * stepSize;

            if (Input.GetKey("f"))
            {
                GameObject.Find(targetPoint).transform.position += new Vector3(0, 0, -stepSize);
            }
            else if (Input.GetKey("g"))
            {
                GameObject.Find(targetPoint).transform.position += new Vector3(0, 0, stepSize);
            }

            // change the position of line
            //GameObject.Find("Line").transform.position = GameObject.Find(target).transform.position;
            //distance = Vector3.Distance(GameObject.Find("Point (1)").transform.position, GameObject.Find("Point (2)").transform.position);
            //GameObject.Find("Line").transform.localScale = new Vector3(0.3f, distance - 1f, 0.3f);
            //GameObject.Find("Line").transform.Rotate(new Vector3(0.3f, distance - 1f, 0.3f));

            DrawLine();
            CheckCollider(GameObject.Find("Target (1)"), GameObject.Find("Point (1)"), GameObject.Find("Point (2)"));
            CheckCollider(GameObject.Find("Target (2)"), GameObject.Find("Point (1)"), GameObject.Find("Point (2)"));
        }

        else
        {
            GameRuleText.text = finishText;
        }

    }

    private void SetText()
    {
        targetText.text = "Move the balls to touch the buttons!";
        //targetPoint;
    }


    void DrawLine(float duration = 0.05f)
    {
        Vector3 start = GameObject.Find("Point (1)").transform.position;
        Vector3 end = GameObject.Find("Point (2)").transform.position;
        //Color color = targetColor;

        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        //lr.startColor = targetColor;
        //lr.endColor = targetColor;
        //(color, color);
        lr.startWidth = 0.2f;
        lr.endWidth = 0.2f;
        lr.material.color = otherColor; 
        //(0.2f, 0.2f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        //GameObject.
        Destroy(myLine, duration);
    }


    void CheckCollider(GameObject targetObject, GameObject pointObject1, GameObject pointObject2) 
    {   
        if (Vector3.Magnitude(targetObject.transform.position - pointObject1.transform.position) < 0.5f ||
            Vector3.Magnitude(targetObject.transform.position - pointObject2.transform.position) < 0.5f)
        {
            targetObject.GetComponent<MeshRenderer>().material.color = targetColor;

        }
        else
        {
            targetObject.GetComponent<MeshRenderer>().material.color = otherColor;
        }
    
    }

    bool CheckFinish(GameObject targetObject1, GameObject targetObject2)
    {
        if (targetObject1.GetComponent<MeshRenderer>().material.color == targetColor &&
            targetObject2.GetComponent<MeshRenderer>().material.color == targetColor)
        {
            return true;
        }
        return false;
    }
}
