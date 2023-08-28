using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
   

public class Player : NetworkBehaviour
{
    
    Rigidbody2D rb;
    float inputX;
    float inputY;
    public float speed = 3;


    [ClientRpc]
    void TalkToAll()
    {
        Debug.Log("Eai Pessoallll !!!!");
    }

    [Command]
    void TalkToServer()
    {
        Debug.Log(" ENTRE NO NOSSO DISCORD ");
    }

    // [client]
    // [TargetRpc]
    // [Server]

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("/discord");
            TalkToServer();
        }


        if(isLocalPlayer)
        {
            inputX = Input.GetAxisRaw("Horizontal");
            inputY = Input.GetAxisRaw("Vertical");

            rb.velocity = new Vector2(inputX,inputY) * speed;
            
        }

    }
}
