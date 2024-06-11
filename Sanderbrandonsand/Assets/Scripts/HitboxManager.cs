using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour
{
    //the player and its important things
    private GameObject player;
    private Animator playerAnimator;
    private PlayerController hitter;

    //each of the hitbox sets
    public GameObject idleHitboxes; //0
    public GameObject jumpingHitboxes; //1
    public GameObject fallingHitboxes; //2
    public GameObject crouchingHitboxes; //3
    public GameObject moveHitboxes; //4
    public GameObject punchHitboxes; //5
    public GameObject kickHitboxes; //6
    public GameObject funnyHitboxes; //7
    public GameObject slashHitboxes; //8

    [SerializeField]
    private GameObject[,] frameData;
    [SerializeField]
    private GameObject[] hitboxRefrenceKeys;

    // Start is called before the first frame update
    void Start()
    {
        hitter = this.GetComponent<PlayerController>();
        playerAnimator = this.GetComponent<Animator>();

        hitboxRefrenceKeys = new GameObject[9];
        hitboxRefrenceKeys[0] = idleHitboxes;
        hitboxRefrenceKeys[1] = jumpingHitboxes;
        hitboxRefrenceKeys[2] = fallingHitboxes;
        hitboxRefrenceKeys[3] = crouchingHitboxes;
        hitboxRefrenceKeys[4] = moveHitboxes;
        hitboxRefrenceKeys[5] = punchHitboxes;
        hitboxRefrenceKeys[6] = kickHitboxes;
        hitboxRefrenceKeys[7] = funnyHitboxes;
        hitboxRefrenceKeys[8] = slashHitboxes;

        frameData = new GameObject[hitboxRefrenceKeys.Length,3];
        for (int i = 0; i < hitboxRefrenceKeys.Length; i++)
        {
            for (int j = 0; j < frameData.GetLength(1); j++)
            {
                if (j < hitboxRefrenceKeys[i].transform.childCount)
                {
                    frameData[i,j] = hitboxRefrenceKeys[i].transform.GetChild(j).gameObject;
                }
                    
            } 
        }

        disableAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void disableAll()
    {
        for(int i = 0; i < frameData.GetLength(0); i++)
        {
            for (int j = 0; j < frameData.GetLength(1); j++)
            {
                if (frameData[i,j] != null)
                {
                    frameData[i, j].SetActive(false);
                }
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name != this.gameObject.name) {
            if (collision.collider.gameObject.layer == 10) {
                
                if (collision.otherCollider.gameObject.layer == 9) {
                    hitter.attemptHit();
                }
                if (collision.otherCollider.gameObject.layer == 10)
                {
                    //nu uh
                }
            }
        }
    }

    private void enableIdle()
    {
        disableAll();
        frameData[0,0].SetActive(true);
    }

    private void enableJump()
    {
        disableAll();
        frameData[1, 0].SetActive(true);
    }

    private void enableFalling()
    {
        disableAll();
        frameData[2, 0].SetActive(true);
    }

    private void enableCrouch()
    {
        disableAll();
        frameData[3, 0].SetActive(true);
    }

    private void enableMove()
    {
        disableAll();
        frameData[4, 0].SetActive(true);
    }

    private void enablePunch1()
    {
        disableAll();
        frameData[5, 0].SetActive(true);
    }

    private void enablePunch2()
    {
        disableAll();
        frameData[5, 1].SetActive(true);
    }

    private void enablePunch3()
    {
        disableAll();
        frameData[5, 2].SetActive(true);
    }

    private void enableKick1()
    {
        disableAll();
        frameData[6, 0].SetActive(true);
    }

    private void enableKick2()
    {
        disableAll();
        frameData[6, 1].SetActive(true);
    }

    private void enableFunny1()
    {
        disableAll();
        frameData[7, 0].SetActive(true);
    }

    private void enableFunny2()
    {
        disableAll();
        frameData[7, 1].SetActive(true);
    }

    private void enableSlash1()
    {
        disableAll();
        frameData[8, 0].SetActive(true);
    }

    private void enableSlash2()
    {
        disableAll();
        frameData[8, 1].SetActive(true);
    }

}
