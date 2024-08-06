using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Playerscript : MonoBehaviour
{
    public Button Respawnbutton;
    public Text Text;
    public bool GameOver = false;
    public FixedJoystick Joystick;
    float XInput,YInput;
    public float movespeed;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameOver == false)
        {
            Respawnbutton.gameObject.SetActive(false);
            Text.color = new Color (1F,0F,0F,0F);
            Respawnbutton.interactable = false;
            YInput = Joystick.Vertical * movespeed;
            XInput = Joystick.Horizontal * movespeed;
            if ( transform.position.x < -15)
            {
                XInput = 0;
                
            }
            if ( transform.position.x > 15)
            {
                XInput = 0;
            }
            transform.Translate(XInput,YInput,0);
            

            //Debug.Log(transform.position.x);
            
           
            transform.Translate(YInput,XInput,0);
        }
        else
        {
            Respawnbutton.gameObject.SetActive(true);
            Respawnbutton.interactable = true;
            Text.color = new Color (1F,0F,0F,1F);
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Lazer")
        {
            //GameOver = true;
            
        }
        
    }
    public void ResetGameOver(){
        GameOver = false;

    }
}
