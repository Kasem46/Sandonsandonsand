using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int numItems;
    public MenuItem[] items;

    // Start is called before the first frame update
    void Start()
    {
        items = new MenuItem[numItems];
        for (int i = 0; i < items.Length; i++) {
            items[i] = this.transform.GetChild(i).gameObject.GetComponent<MenuItem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < items.Length; i++) {
            if (items[i].isHovered())
            {
                items[i].gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
            else {
                items[i].gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            }
        }
    }
}
