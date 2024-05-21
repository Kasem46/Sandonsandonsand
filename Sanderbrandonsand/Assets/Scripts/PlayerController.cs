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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setInputDirection(Vector2 inputDirection) { 
        this.inputDirection = inputDirection;
    }

    public int getPlayerIndex() {
        return playerIndex;
    }
}
