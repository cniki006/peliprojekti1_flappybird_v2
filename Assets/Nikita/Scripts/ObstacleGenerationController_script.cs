using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerationController_script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject obstacle;
    public float spawnRate;
    public float gapSize;
    public float gapSpawnBoundaries;
    float Timer;
    float gapCenter;
    Vector2 spawnPoint;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gapCenter = Random.Range(0.0f, gapSpawnBoundaries);
        spawnPoint.x = Screen.width / 2;
        spawnPoint.y = gapCenter + gapSize / 2 + obstacle.transform.localScale.y;
    }
}
