using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HealthBar;
    public static Image HealthBarImage;
    public static float health = 100.0f;

    public Text myHealth;
    void Start()
    {
        health = 100.0f;
        if(HealthBar != null)
        {
            HealthBarImage = HealthBar.transform.GetComponent<Image>();
        }
        SetHealthBarValue(health);

        if(myHealth)
        {
            myHealth.text = Player.health.ToString() + "/100";
        }
    }

    public static void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
        if (HealthBarImage.fillAmount < 0.2f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (HealthBarImage.fillAmount < 0.4f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else if (health > 100)
        {
            SetHealthBarColor(Color.blue);
        }
        else 
        {
            SetHealthBarColor(Color.green);
        }
    }

    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthBarValue(health/100);
        if(health == 0){endGame();}
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("enemy"))
        {
            if(Score.mega)
            {
                Debug.Log("Player is Invisible take no damage");
            }
            else
            {
                Debug.Log("Collision with Enemy");
                health -= 20.0f;
                myHealth.text = Player.health.ToString() + "/100";
                if (health<0) health = 0;
            }
            
        }
    }

    void endGame()
    {
        SceneManager.LoadScene("GameOverScreen");
    }
}
