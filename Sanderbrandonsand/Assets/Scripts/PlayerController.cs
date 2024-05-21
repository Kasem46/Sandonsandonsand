using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //this is the multiplier that allows speed to be controlled
    [SerializeField] //this here just means we can see the next variable in the editor
    private float speed = 2f;

    //this is some back end stuff that lets us have 2 players, it is basically just to keep track of which one is which
    [SerializeField]
    private int playerIndex = 0; 

   
    //the input direction gotten from the inputHandler
    private Vector2 inputDirection = Vector2.zero;


    private Vector3 moveDirection = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(inputDirection.x, inputDirection.y, 0f);
        moveDirection = transform.TransformDirection(moveDirection);

        


        moveDirection *= speed;
        transform.Translate(moveDirection*Time.deltaTime);
    }

    public Vector2 clampMovement(Vector2 input)
    {
        float cos8 = Mathf.Cos(Mathf.PI / 8f);
        float sin8 = Mathf.Sin(Mathf.PI / 8f);
        float cos4 = Mathf.Cos(Mathf.PI / 4f);
        float sin4 = Mathf.Sin(Mathf.PI / 4f);

        switch (input){
            case ((input.x >= -1f && input.x <= -cos8) && (input.y >= 0f && input.y <= sin8)):
                return new Vector2(-1f, 0f);
        }
    }


    public void setInputDirection(Vector2 inputDirection) { 
        this.inputDirection = inputDirection;
    }

    public int getPlayerIndex() {
        return playerIndex;
    }
}
