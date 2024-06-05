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
    public GameObject funnyHitBoxes; //7
    public GameObject slashHitBoxes; //8
    private GameObject[][] frameData;
    private GameObject[] hitboxRefrenceKeys;

    // Start is called before the first frame update
    void Awake()
    {
        player = this.transform.parent.gameObject;
        playerAnimator = player.GetComponent<Animator>();
        hitboxRefrenceKeys = {idleHitboxes, jumpingHitboxes, fallingHitboxes,crouchingHitboxes, moveHitboxes, punchHitboxes, kickHitboxes, funnyHitBoxes, slashHitBoxes};
        frameData = new GameObject[hitboxRefrenceKeys.Length][3];
        for (int i = 0; i < frameData.Length; i++)
        {
            for (int j = 0; j < frameData[i].Length; j++)
            {
                if (j < hitboxRefrenceKeys[i].childCount())
                {
                    frameData[i][j] = hitboxRefrenceKeys[i].GetChild(j);
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
