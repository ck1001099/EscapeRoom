using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game2MainController : MonoBehaviour
{
    private int stage;
    public Text GameRuleText;
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        GameObject.Find("Table").transform.position = new Vector3(0, -1f, 0);
        GameRuleText.text = "Stage " + stage.ToString() + ": Press 'n' to the next stage.";
        //Target = GameObject.Find("Target");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stage == 0 && Input.GetKey("n"))
        {
            stage = 1;
            GameRuleText.text = "Stage " + stage.ToString() + ": Press 'n' to the next stage.";
        }
        else if (stage == 1) { 
            TableAppear();
        }
        else if (stage == 2 && Input.GetKey("n"))
        {
            GameRuleText.text = "Stage " + stage.ToString() + ": Move the cup by using arrow keys. Use 'b' to pour the water.";
            stage = 3;
        }
        else if (stage == 3)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            GameObject.Find("Cup").transform.position += new Vector3(moveHorizontal, moveVertical, 0) * 0.1f;
            GameObject.Find("WaterDrop").transform.position = GameObject.Find("Cup").transform.position;

            if (Input.GetKey("b"))
            {
                //GameObject.Find("Cup").transform.eulerAngles = new Vector3(GameObject.Find("Cup").transform.eulerAngles.x, GameObject.Find("Cup").transform.eulerAngles.y + 120, GameObject.Find("Cup").transform.eulerAngles.z);
                GameObject.Find("Cup").transform.eulerAngles += new Vector3(0, 0, 10);
            }

            //GameObject.Find("Cup").transform.eulerAngles = new Vector3(GameObject.Find("Cup").transform.eulerAngles.x, GameObject.Find("Cup").transform.eulerAngles.y + 120, GameObject.Find("Cup").transform.eulerAngles.z);
            //GameObject.Find("Cup").transform.eulerAngles = new Vector3(0, 0, 120);
            if (GameObject.Find("Cup").transform.eulerAngles.z > 120) {
                stage = 4;
                GameRuleText.text = "Stage " + stage.ToString() + ": Water Fall";
                GameObject.Find("WaterDrop").transform.position += new Vector3(-0.15f, 0, 0);
            }
             

        }
        else if (stage == 4)
        {
            WaterFall();
        }

        else if (stage == 5)
        {
            //GameRuleText.text = "Stage " + stage.ToString() + ": Finish!";
        }
    }


    void TableAppear()
    {
        if (GameObject.Find("Table").transform.position[1] < 1.5)
        {
            GameObject.Find("Table").transform.position += new Vector3(0, 2f * Time.deltaTime, 0);
        }
        else { stage = 2; }
    }

    void WaterFall()
    {
        float distance = Vector3.Distance(GameObject.Find("WaterDrop").transform.position, Target.transform.position);
        GameRuleText.text = distance.ToString();
        if (GameObject.Find("WaterDrop").transform.position[1] > 0)
        {
            GameObject.Find("WaterDrop").transform.position += new Vector3(0, -5f * Time.deltaTime, 0);
            // Need to change to the real gravity!
        }
        else if (GameObject.Find("Cup").transform.eulerAngles.z > 90)
        {
            GameObject.Find("Cup").transform.eulerAngles -= new Vector3(0, 0, 10);
        }
        else {

            if (Vector3.Distance(GameObject.Find("WaterDrop").transform.position, Target.transform.position) < 0.5f){
                stage = 3;
                GameRuleText.text = "Stage " + stage.ToString() + ": Another water drops";
                Target.transform.localScale += new Vector3(0, 0.3f, 0);
                Target.transform.position += new Vector3(0, 0.15f, 0);

                if (Target.transform.localScale.y > 0.8)
                {
                    stage = 5;
                    GameRuleText.text = "Stage " + stage.ToString() + ": Finish!";
                }
            }
            else
            {
                stage = 3;
                GameRuleText.text = "Stage " + stage.ToString() + ": Try again. Too far! \n(Try to make water to touch the button.) " + distance.ToString();
                GameObject.Find("WaterDrop").transform.position = GameObject.Find("Cup").transform.position;

            }
        }
    }
}
