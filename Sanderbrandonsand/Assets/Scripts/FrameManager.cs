using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameManager : MonoBehaviour
{
    //the player and its important things
    private GameObject player;
    private Animator playerAnimator;
    private GameObject[] frames;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent.parent.gameObject;
        playerAnimator = player.GetComponent<Animator>();
        frames = new GameObject[this.transform.childCount];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            frames[i] = this.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
