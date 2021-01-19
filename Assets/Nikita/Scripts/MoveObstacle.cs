using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    float speed;
    Vector3 pointToMove = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        pointToMove = new Vector3(-Camera.main.aspect * Camera.main.orthographicSize - 1, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleSpawner_script spawnerScript = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner_script>();
        speed = spawnerScript.speed;
        transform.position = Vector3.MoveTowards(transform.position, pointToMove, speed * Time.deltaTime);
        if (transform.position == pointToMove)
        {
            Destroy(this.gameObject);
        }
    }
}
