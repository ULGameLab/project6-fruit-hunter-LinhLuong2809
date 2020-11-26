using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Score : MonoBehaviour
{
    public static int score = 0;
    public static int endScore = 300;

    public Text healthText;
    public Text countText;
    public static bool mega = false;
    public static int bonus = 20;

    public static AudioSource myAudio;
    
    float seconds;
    // Start is called before the first frame update
    void Start()
    {
        countText.text = "Score = " + score.ToString();
        myAudio = GetComponent<AudioSource>();
        healthText.text = Player.health.ToString() + "/100";
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("check mega: "+ mega);
        

        if(score >= endScore || Player.health == 0)
        {
            EndGame();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("banana"))
        {
            if(mega)
            {
                score = score + 30 + bonus;
                countText.text = "Score = " + score.ToString();
                Player.health += 20;
                healthText.text = Player.health.ToString() + "/100";
            }
            else
            {
                score += 30;
                countText.text = "Score = " + score.ToString();
                Player.health += 10;
                healthText.text = Player.health.ToString() + "/100";
            }
        }
        else if(col.gameObject.CompareTag("lemon"))
        {
            if(mega)
            {
                score = score + bonus + 10;
                countText.text = "Score = " + score.ToString();
                Player.health += 10;
                healthText.text = Player.health.ToString() + "/100";
            }
            else
            {
                score += 10;
                countText.text = "Score = " + score.ToString();
                Player.health += 5;
                healthText.text = Player.health.ToString() + "/100";
            }
        }
        else if(col.gameObject.CompareTag("pizza"))
        {
            if(mega)
            {
                score += 0;
                countText.text = "Score = " + score.ToString();
            }
            else
            {
                score -= 20;
                countText.text = "Score = " + score.ToString();
                Player.health -= 10;
                healthText.text = Player.health.ToString() + "/100";
                if (Player.health<0) 
                {Player.health = 0;
                }
            }   
        }
        

        else if(col.gameObject.CompareTag("pear"))
        {
            if(mega)
            {
                score = score + bonus + 20 ;
                countText.text = "Score = " + score.ToString();
                Player.health += 10;
                healthText.text = Player.health.ToString() + "/100";
            }
            else
            {
                score += 20;
                countText.text = "Score = " + score.ToString();
                Player.health += 10;
                healthText.text = Player.health.ToString() + "/100";
            }
            
        }
        else if(col.gameObject.CompareTag("sandwich"))
        {
            if(mega)
            {
                score += 0;
                countText.text = "Score = " + score.ToString();
            }
            else
            {
                score -= 10;
                countText.text = "Score = " + score.ToString();
                Player.health -= 10;
                healthText.text = Player.health.ToString() + "/100";
                if (Player.health<0) 
                {Player.health = 0;
                }
            }
        }

        else if(col.gameObject.CompareTag("megafruit"))
        {   
            
            mega = !mega;
            score = score + 30 + bonus;
            countText.text = "Score = " + score.ToString();
            Player.health += 30;
            healthText.text = Player.health.ToString() + "/100";
            StartCoroutine(Mega(9));

                    
        }
        else
        {
            return;
        }
        

       

    }

    public static IEnumerator Mega(float waitTime)
    {   myAudio.Play();
        yield return new WaitForSeconds(waitTime);
        mega = !mega;
        Debug.Log("check mega : "+ mega);
    }

    public static void SetMegafalse(bool mega){ mega = false;}

    public static void EndGame()
    {
        SceneManager.LoadScene("EndScreen");
    }

}
