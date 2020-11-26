using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyScore : MonoBehaviour
{
    public Text myScore;
    // Start is called before the first frame update
    public Text myHealth;
    void Start()
    {
        if(myScore && myHealth)
        {
            myScore.text = "Score = " + Score.score;
            myHealth.text = Player.health.ToString() + "/100";
             
        }

        if(Score.score > Score.endScore){Score.EndGame();}  

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("bullet"))
        {
            if(Score.mega)
            {
                Score.score += 40;
                myScore.text = "Score = " + Score.score.ToString();
                Player.health += 20;
                myHealth.text = Player.health.ToString() + "/100";
                
            }
            else
            {
                Score.score += + 20;
                myScore.text = "Score = " + Score.score.ToString();
                Player.health += 10;
                myHealth.text = Player.health.ToString() + "/100";
            }
            
        }
        else
        {
            return;
        }
       
    }
}
