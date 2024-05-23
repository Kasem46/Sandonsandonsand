using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //this is the multiplier that allows speed to be controlled
    [SerializeField] //this here just means we can see the next variable in the editor
    private float speed = 2f;

    private float gravityAccel = 2f;
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

        moveDirection = clampMovement(moveDirection);
        moveDirection = movementInterpretation(moveDirection);
        inputDirectionNum = checkCorrectSide(inputDirectionNum);
        moveDirection *= speed;

        rb.velocity = moveDirection;
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

    public int checkCorrectSide(int input)
    {
        int[] unaltered = {1,2,3,4,5,6,7,8,9};
        int[] altered = { 3, 2, 1, 6, 5, 4, 9, 8, 7 };
        int temp = 4;
        if (transform.position.x >= otherPlayersTrans.transform.position.x) 
        { 
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
            return input;
        }
    }

    public Vector2 movementInterpretation(Vector2 directionInput)
    {
        float cos8 = Mathf.Cos(Mathf.PI / 8f);
        float sin8 = Mathf.Sin(Mathf.PI / 8f);
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
            return jump(7);
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
            return jump(9);
        }
        if(directionInput == new Vector2(0f, 1f))
        {
            inputDirectionNum = 8;
            Debug.Log("jump");
            return jump(8);
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

    public bool isInAir() {
        if (rb.IsTouchingLayers(7)) {
            return true;
        }
        
        return false;
    }

    public Vector2 jump(int dir) {
        float sin4 = Mathf.Sin(Mathf.PI / 4f);

        if (inAir == false)
        {
            airDir.y -= gravityAccel*Time.deltaTime;
        }
        else {
            if (dir == 7)
            {
                airDir = new Vector2(-sin4,sin4);
            }
            else if (dir == 8)
            {
                airDir = new Vector2(0, 1);
            }
            else if (dir == 9) {
                airDir = new Vector2(sin4, sin4);
            }
        }

        return airDir;
    }
}
