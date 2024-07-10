using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeItem : MenuItem
{
    public string Scene;

    private void OnMouseDown()
    {
        if (Scene != null) {
            SceneManager.LoadScene(Scene);
        }
    }
}
