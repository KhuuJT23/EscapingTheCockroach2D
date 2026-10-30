using UnityEngine;
using UnityEngine.InputSystem; //Adds in the new input system to add keyboard shit

public class PlayerMovementJK : MonoBehaviour
{
    public float moveSpeed = 7f; // The speed variable
    private Rigidbody2D rb; // The rigidbody variable
    private Vector2 movement; // The main movement dude variable where is store x and y aka side to side and up and down
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent <Rigidbody2D>(); // Movement need that body to move it gang
        
    }

    // Update is called once per frame
    void Update()

    {
        if (!enabled)
        {
            return;
        } 
        movement = Vector2.zero; // Keeping that shit a zero, meaning player doesn't move
        // WASD or Arrow keys, Lets the player move type shit
        if(Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed){
            movement.y = 1;
        }
        if(Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed){
            movement.y = -1;
        }
        if(Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed){
            movement.x = -1;
        }
        if(Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed){
        movement.x = 1;
        }
        movement.Normalize(); // Avoid the player from speeding up when going diagonal 


        
    }
    void FixedUpdate()
    {
       
        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // MovePosition moves the player kinematrics movement(Doesn't rely on gravity like that frfr).
                                                                                   // rb.position tell us where the player is located
                                                                                   // movement is where is should go(left right up down)
                                                                                   // moveSpeed is the speed the player is going
                                                                                   // Time.fixedDeltaTime is so that high FPS doesn't make them Barry Allen all of sudden
    }
}
