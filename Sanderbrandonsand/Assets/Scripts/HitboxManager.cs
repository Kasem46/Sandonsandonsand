using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour
{
    //the player and its important things
    private GameObject player;
    private Animator playerAnimator;

    //each of the hitbox sets
    public GameObject idleHitboxes;
    public GameObject jumpingHitboxes;
    public GameObject fallingHitboxes;
    public GameObject crouchingHitboxes;
    public GameObject forwardMoveHitboxes;
    public GameObject backwardMoveHitboxes;

    // Start is called before the first frame update
    void Awake()
    {
        player = this.transform.parent.gameObject;
        playerAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        setValidHitboxes();
    }

    private void setValidHitboxes() { 
        
    }
}
