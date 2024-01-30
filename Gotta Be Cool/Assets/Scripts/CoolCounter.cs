using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolCounter : MonoBehaviour
{
    public int CoolScore { get; private set; } //Creating a score called cool score
    public int DestroyScore { get; private set; } //Creating a score called destroy score

    //creating public game objects in the scene
    public GameObject SuperCoolObject; 
    public GameObject CoolObject;
    public GameObject NotCoolObject;
    
    // Start is called before the first frame update
    void Start()
    {
        CoolScore = 0; //Establishing that both scores start at 0 and some debug messages 
        Debug.Log("CoolCounter initialized. CoolScore: " + CoolScore);
        DestroyScore = 0;
        Debug.Log(message: "DestroyCounter initialized. DestroyScore:" + DestroyScore);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cool")) //if this object collides with an object tagged Cool the cool 
        //score wil go up and that object will be destroyed and the destroy score will go up
        {
            CoolScore++;
            Debug.Log("Collision with Cool object detected. CoolScore: " + CoolScore);
            
            Destroy(collision.gameObject);
            DestroyScore++;
            Debug.Log("Collision with Cool object detected. DestroyScore: " + DestroyScore);
        }

        if (collision.gameObject.CompareTag("NotCool"))//if this object collides with an object tagged Not Cool the
        //object will be destroyed and the destroy score will go up 
        {
            Destroy(collision.gameObject);
            DestroyScore++;
            Debug.Log("Collision with Cool object detected. DestroyScore: " + DestroyScore);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (DestroyScore == 4 && CoolScore == 4) //If these scores are both at 4 then the super cool object will be visible 
        {
            SuperCoolObject.SetActive(true);
        }
        
        if (DestroyScore == 4 && CoolScore == 3) //If these scores are both at 4 and 3 then the cool object will be visible
        {
            CoolObject.SetActive(true);
        }
        
        if (DestroyScore == 4 && CoolScore == 2) //If these scores are both at 4 and 2 then the not cool object will be visible
        {
            NotCoolObject.SetActive(true);
        }
    }
}
