using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazerscript : MonoBehaviour
{
    public BoxCollider2D BoxCollider2D;
    public SpriteRenderer SpriteRenderer;
    float x,y,rotationZ;
    int count = 100;
    public Playerscript Playerscript;
    
    public GameObject Object;
    
    
   

    // Start is called before the first frame update
    void Start()
    {
        Playerscript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playerscript>();
        SpriteRenderer.color = new Color (1F,0.8F,0.8F,1F);
        BoxCollider2D.isTrigger = true;
        x = Random.Range(-10,11);
        y = Random.Range(-20,21);
        rotationZ = Random.Range(0,180);
        transform.position = new Vector2 (x,y);
        transform.rotation = Quaternion.Euler(0,0,rotationZ);
    }

    void FixedUpdate()
    {
        if (count > 0)
        {
            count -= 1;
            SpriteRenderer.color -= new Color (0F,0.008F,0.008F,0F);
        }
        if (count < 30)
        {
           
            
            for (float i = -100; i < 100; i += 5)
            {
                if (Playerscript.transform.position.x + 3.5 > (x + i/2 * Mathf.Sin((rotationZ*Mathf.PI)/180)) && Playerscript.transform.position.x - 3.5 < (x + i/2 * Mathf.Sin((rotationZ*Mathf.PI)/180)))
                {
                    if (Playerscript.transform.position.y + 3.5 > (y + i/2 * -Mathf.Cos((rotationZ*Mathf.PI)/180)) && Playerscript.transform.position.y - 3.5 < (y + i/2 * -Mathf.Cos((rotationZ*Mathf.PI)/180)))
                    {
                        Playerscript.GameOver = true;
                    }
                    
                }
                //Instantiate(Object,new Vector2 (x + i/2 * Mathf.Sin((rotationZ*Mathf.PI)/180),y + i/2 * -Mathf.Cos((rotationZ*Mathf.PI)/180)),Quaternion.Euler(0,0,rotationZ));
                
                
    
                    
                
            
            }
            BoxCollider2D.isTrigger = false;
            SpriteRenderer.color = new Color (0F,0F,0F,1F);
        }
        if (count == 0)
        {
            Destroy(gameObject);
            
           
        }
    }
    
    
}
