using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public PlayerController player1;
    public PlayerController player2;

    public GameObject squrHealth;
    public GameObject trungHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        squrHealth.transform.localScale = new Vector3((float)player1.getHealth()/(50f/3f),0.5f,1);
        squrHealth.transform.position = new Vector3(-5f +(100- (float)player1.getHealth())/(100f/3f), 3.75f, -2f);
        trungHealth.transform.localScale = new Vector3((float)player2.getHealth() / (50f / 3f), 0.5f, 1);
        trungHealth.transform.position = new Vector3(5f - (100 - (float)player2.getHealth()) / (100f / 3f), 3.75f, -2f);


        if (player1.getHealth() <= 0)
        {
            Debug.Log("player 2 wins");
            SceneManager.LoadScene("Player2Win");
        }

        if (player2.getHealth() <= 0)
        {
            Debug.Log("player 1 wins");
            SceneManager.LoadScene("Player1Win");
        }     
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
}
