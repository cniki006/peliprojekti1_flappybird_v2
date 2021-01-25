using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_script : MonoBehaviour
{
    // Start is called before the first frame update
    public float AIjumpMin, AIjumpMax;
    public bool gameMenu;
    public float jumpTimer = 0.0f;
    GameObject obstacleSpawner;
    GameObject player;
    PlayerController player_script;

    void Start()
    {
        player_script = GameObject.Find("Lander").GetComponent<PlayerController>();
        player = GameObject.Find("Lander");
        obstacleSpawner = GameObject.Find("ObstacleSpawner");
        gameMenu = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMenu == true)
        {

            AIjump();
        } else
        {

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameMenu = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0; ;
            }
        }
    }

    void AIjump()
    {
        if (player.transform.position.y < -Camera.main.orthographicSize + Camera.main.orthographicSize / 2)
        {
            player_script.Jump();
        }

        if (player.transform.position.y > Camera.main.orthographicSize - Camera.main.orthographicSize / 2)
        {
            jumpTimer += 0.5f;
        }
        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0)
        {
            player_script.Jump();
            jumpTimer = Random.Range(AIjumpMin, AIjumpMax);
        }
    }
}
