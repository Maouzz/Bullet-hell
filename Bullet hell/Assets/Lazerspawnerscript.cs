using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lazerspawnerscript : MonoBehaviour
{
    public Text Score;
    public Playerscript Playerscript;
    public GameObject Lazer;
    int count;
    int timer = 30;
    int setTime = 1;
    int setcount = 0;
    int ScorePoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        Playerscript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playerscript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if (Playerscript.GameOver == false)
        {
            if (count > 0)
            {
                count -= 1;
            }
            if (count == 0)
            {
            
                Score.text = (ScorePoints += 1).ToString();
                setcount += 1;
                Instantiate(Lazer,transform.position,transform.rotation);
                count = timer - setTime;
                
                if (setTime < 20 && setcount == 6)
                {
                    setcount = 0;
                    setTime += 1;
                    
                }
            }
        }
        else
        {
            setTime = 1;
            setcount = 1;
            ScorePoints = 0;
            Score.text = ScorePoints.ToString();

        }

    }
    
}
