using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem : MonoBehaviour
{
    private bool hovering = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isHovered() {
        return hovering;
    }

    private void OnMouseEnter()
    {
        hovering = true;
    }

    private void OnMouseExit()
    {
        hovering = false;
    }
}
