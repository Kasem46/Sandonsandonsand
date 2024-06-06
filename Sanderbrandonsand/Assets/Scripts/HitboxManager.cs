using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour
{
    //the player and its important things
    private GameObject player;
    private Animator playerAnimator;

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
    private GameObject[,] frameData;
    private GameObject[] hitboxRefrenceKeys;

    // Start is called before the first frame update
    void Awake()
    {
        player = this.transform.parent.gameObject;
        playerAnimator = player.GetComponent<Animator>();

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
    }

    // Update is called once per frame
    void Update()
    {
        setValidHitboxes();
    }

    private void setValidHitboxes() 
    {
        
    }

}
