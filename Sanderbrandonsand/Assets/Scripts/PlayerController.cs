using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //this is the multiplier that allows speed to be controlled
    [SerializeField] //this here just means we can see the next variable in the editor
    private float speed = 2f;
    [SerializeField]
    private float jumpPower = 2f;
    private Vector2 airDir = Vector2.zero;

    //this is some back end stuff that lets us have 2 players, it is basically just to keep track of which one is which
    [SerializeField]
    private int playerIndex = 0;

    //our rigidbody2d
    private Rigidbody2D rb;

    //player variables
    [SerializeField]
    private GameObject otherPlayer;

    private Transform otherPlayersTrans;
   
    //the input direction gotten from the inputHandler
    private Vector2 inputDirection = Vector2.zero;

    [SerializeField]
    private int inputDirectionNum = 0;


    private Vector3 moveDirection = Vector3.zero;

    //check if in the air
    [SerializeField]
    private bool inAir = false;

    void Awake() { 
        rb = GetComponent<Rigidbody2D>();
        otherPlayersTrans = otherPlayer.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(inputDirection.x, inputDirection.y, 0f);
        moveDirection = transform.TransformDirection(moveDirection);

        inAir = isInAir();
        //clap analong movement to one of the directions
        moveDirection = clampMovement(moveDirection);
        //classify that dirrection
        moveDirection = movementInterpretation(moveDirection);
        //set up jump if are jumping
        if (inputDirectionNum == 7 || inputDirectionNum == 8 || inputDirectionNum == 9) {
            moveDirection = jump(inputDirectionNum);
        }
        //dont get stuck on top of player
        if (rb.IsTouchingLayers(LayerMask.GetMask("Player")) && inAir == true) {
            rb.velocity = jump(checkCorrectSide(7)) * (1f / jumpPower);
        }
        //correct L/R dirrection for command input attacks
        inputDirectionNum = checkCorrectSide(inputDirectionNum);
        //scale movement with speed
        moveDirection *= speed;
        //move as inputed, unless in the air
        if (inAir == false){
            rb.velocity = moveDirection;
        }
    }

    public Vector2 clampMovement(Vector2 input)
    {
        float cos8 = Mathf.Cos(Mathf.PI / 8f);
        float sin8 = Mathf.Sin(Mathf.PI / 8f);
        float sin4 = Mathf.Sin(Mathf.PI / 4f);
        //Zones are numbered from (0,-1) clockwise use this for future reference https://www.desmos.com/calculator/fmscfnkp8d

        if (input.y == 0 && input.x == 0) {
            return new Vector2(0f, 0f);
        }

        //Zone 1
        if (input.x <= -cos8 && (input.y >= -sin8 && input.y <= sin8)) {
            return new Vector2(-1f, 0f);
        }

        //Zone 2
        if ((input.x > -cos8 && input.x < -sin8) && (input.y > sin8 && input.y < cos8)) {
            return new Vector2(-sin4, sin4);
        }

        //Zone 3
        if ((input.x >= -sin8 && input.x <= sin8) && input.y >= cos8) {
            return new Vector2(0, 1f);
        }

        //Zone 4
        if ((input.x > sin8 && input.x < cos8) && (input.y < cos8 && input.y > sin8)) {
            return new Vector2(sin4, sin4);
        }

        //Zone 5
        if (input.x >= cos8 && (input.y <= sin8 && input.y >= -sin8)) {
            return new Vector2(1f, 0);
        }

        //Zone 6
        if ((input.x < cos8 && input.x > sin8) && (input.y > -cos8 && input.y < -sin8)) {
            return new Vector2(sin4, -sin4);
        }

        //Zone 7 
        if ((input.x <= sin8 && input.x >= -sin8) && input.y <= -cos8) {
            return new Vector2(0, -1f);
        }

        //Zone 8
        if ((input.x < -sin8 && input.x > -cos8) && (input.y > -cos8 && input.y < -sin8)) {
            return new Vector2(-sin4, -sin4);
        }

        //default return nothing
        return new Vector2(0f, 0f);

    }

    //checks to see what side the players are facing and what numbers will do each thing
    public int checkCorrectSide(int input)
    {
        //first array default, numbers arranged in a 3x3 cube representing directions 4 being move left, 5 being idle six move right, 2 jump, 8 crouch ect
        int[] unaltered = {1,2,3,4,5,6,7,8,9};
        //swaed the first and third collums of the array, these are inputs when the characters have switched sides 
        int[] altered = { 3, 2, 1, 6, 5, 4, 9, 8, 7 };

        //default not moving value
        int temp = 4;

        //checks if player's x position is greater than the other players x position
        if (transform.position.x >= otherPlayersTrans.transform.position.x) 
        { 
            //traverse array and find what input needs to be swapped
            for(int i = 0; 0 < 9; i++)
            {
                if (unaltered[i] == inputDirectionNum)
                {
                    temp = i;
                    break;
                }
            }
            return altered[temp];
        }
        else
        {
            //if players are facing eachother in default position return default number corresponding to movement
            return input;
        }
    }

    //interprets which way player is moving as in game direction and returns a vector in the direction of movement
    public Vector2 movementInterpretation(Vector2 directionInput)
    {
        float sin4 = Mathf.Sin(Mathf.PI / 4f);

        if (directionInput == new Vector2(-1f, 0f))
        {
            inputDirectionNum = 4;
            Debug.Log("left");
            return new Vector2(-1f, 0f);
        }
        if (directionInput == new Vector2(-sin4, sin4))
        {
            inputDirectionNum = 7;
            Debug.Log("up left");
            return new Vector2(-sin4, sin4);
        }
        if (directionInput == new Vector2(sin4, -sin4))
        {
            inputDirectionNum = 3;
            Debug.Log("crouch right");
            return new Vector2(0f, 0f);
        }
        if(directionInput == new Vector2(0f, -1f))
        {
            inputDirectionNum = 2;
            Debug.Log("crouch");
            return new Vector2(0f, 0f);
        }
        if(directionInput == new Vector2(-sin4, -sin4))
        {
            inputDirectionNum = 1;
            Debug.Log("crouch wrong");
            return new Vector2(0f, 0f);
        }
        if (directionInput == new Vector2(1f, 0f)){
            inputDirectionNum = 6;
            Debug.Log("right");
            return new Vector2(1f, 0f);
        }
        if(directionInput == new Vector2(sin4, sin4))
        {
            inputDirectionNum = 9;
            Debug.Log("up right");
            return new Vector2(sin4, sin4);
        }
        if(directionInput == new Vector2(0f, 1f))
        {
            inputDirectionNum = 8;
            Debug.Log("jump");
            return new Vector2(0, 1f);
        }
        inputDirectionNum = 5;
        return new Vector2(0, 0);
    }

    public void setInputDirection(Vector2 inputDirection) { 
        this.inputDirection = inputDirection;
    }

    public int getPlayerIndex() {
        return playerIndex;
    }

    //checks if player is in air
    public bool isInAir() {
        if (rb.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            return false;
        }
        
        return true;
    }

    public Vector2 jump(int dir) {
        float sin4 = Mathf.Sin(Mathf.PI / 4f);
        float sin8 = Mathf.Sin(Mathf.PI / 8f);

        airDir = new Vector2(0, 0);
        if (dir == 7)
        {
            airDir = new Vector2(-sin8,1f);
        }
        else if (dir == 8)
        {
            airDir = new Vector2(0, 1f);
        }
        else if (dir == 9) {
            airDir = new Vector2(sin8, 1f);
        }
        

        return airDir * jumpPower;
    }
}
