using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlayerController player1;
    public PlayerController player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.getHealth() <= 0)
        {
            Debug.Log("player 2 wins");
        }

        if (player2.getHealth() <= 0)
        {
            Debug.Log("player 1 wins");
        }
    }
}
