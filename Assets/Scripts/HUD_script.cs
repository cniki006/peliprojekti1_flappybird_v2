using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUD_script : MonoBehaviour
{
    GameManager_script gameManager_script;
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        gameManager_script = GameObject.Find("GameManager").GetComponent<GameManager_script>();
        canvas = this.gameObject.GetComponentInChildren<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager_script.gameMenu == false)
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
