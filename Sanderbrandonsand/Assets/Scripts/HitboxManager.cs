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
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base.Idle") == true)
        {
            idleHitboxes.SetActive(true);
        }
        else {
            idleHitboxes.SetActive(false);
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base.Jumping") == true)
        {
            jumpingHitboxes.SetActive(true);
        }
        else
        {
            jumpingHitboxes.SetActive(false);
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base.Falling") == true)
        {
            fallingHitboxes.SetActive(true);
        }
        else
        {
            fallingHitboxes.SetActive(false);
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base.Crouching") == true)
        {
            crouchingHitboxes.SetActive(true);
        }
        else
        {
            crouchingHitboxes.SetActive(false);
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base.Walking Forward") == true)
        {
            forwardMoveHitboxes.SetActive(true);
        }
        else
        {
            forwardMoveHitboxes.SetActive(false);
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base.Walking Backwards") == true)
        {
            backwardMoveHitboxes.SetActive(true);
        }
        else
        {
            backwardMoveHitboxes.SetActive(false);
        }
    }

}
