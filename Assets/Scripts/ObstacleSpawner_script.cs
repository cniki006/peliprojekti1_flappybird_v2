using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner_script : MonoBehaviour
{
    // Ylempi ja alempi obstacle-objekti
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject obstacle1;
    // spawnRate määrittää kuinka usein "tolppaat" spawnaa
    public float spawnRate;
    // gapSize määrittää raon koon uniteissa (tässä vaiheessa 1 = yksi neliö)
    public float gapSize;
    // gapSpawnBoundaries kertoo heittelyväliin (kannattaa pitää semimatalassa, ettei heittää näytön yli)
    public float gapSpawnBoundaries;
    // speed castataan eri scriptiin, mutta määritään tässä käyttävyyden takia
    public float speed;
    List<Vector2> calculatedOstacleLocations = new List<Vector2>();
    List<Vector2> calculatedOstacleLocations1 = new List<Vector2>();
    Renderer obstacleRenderer, obstacleRenderer1;
    
    float Timer = 0.0f;
    bool check, check1 = false;
    public float gapCenter;
    Vector2 tempVector = new Vector2();

    void Start()
    {

        // Hyödyllistä tietää cameran korkeudeen, kun valitsee gapSpawnBoundaries
        print(Camera.main.orthographicSize);
        // obstacleRenderin avulla ohjelma rakentaa tolpat oikein riipumatta siitä, mitä spriteja käytetään
        obstacleRenderer = obstacle.GetComponent<SpriteRenderer>();
        obstacleRenderer1 = obstacle1.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GameManager_script gameManager_script = GameObject.Find("GameManager").GetComponent<GameManager_script>();
        Timer = Timer - Time.deltaTime;
        if (gameManager_script.gameMenu != true)
        {
            CreateObstacleColumn();
        }
    }

    void CreateObstacleColumn()
    {
        if (Timer <= 0)
        {
            // Tehdään kaksi Vector2 listaa ala- ja yläpalkkia varten.
            check = true;
            check1 = true;
            Timer = 0.0f;
            gapCenter = Random.Range(-gapSpawnBoundaries, gapSpawnBoundaries);
            if (check == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    //Camera.main.aspect * Camera.main.orthographicSize asettaa objektiin aina kuvaruutun oikean reunaan näytön asetuksista huolimatta.
                    tempVector = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, gapCenter + gapSize / 2 + obstacleRenderer.bounds.size.y / 2 + i * obstacleRenderer.bounds.size.y);
                    calculatedOstacleLocations.Add(tempVector);
                    tempVector = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, gapCenter - gapSize / 2 - obstacleRenderer1.bounds.size.y / 2 - i * obstacleRenderer1.bounds.size.y);
                    calculatedOstacleLocations1.Add(tempVector);
                }
                check = false;
            }

            // Spawnataan objektit edellisten ohjeiden mukaan.
            if (check1 == true)
            {
                for (int i = 0; i < calculatedOstacleLocations.Count; i++)
                {
                    Instantiate(obstacle, new Vector3(calculatedOstacleLocations[i].x, calculatedOstacleLocations[i].y, 1), Quaternion.identity);
                    
                }
                for (int i = 0; i < calculatedOstacleLocations1.Count; i++)
                {
                    Instantiate(obstacle1, new Vector3(calculatedOstacleLocations1[i].x, calculatedOstacleLocations1[i].y, 1), Quaternion.identity);
                    
                }
                calculatedOstacleLocations.Clear();
                calculatedOstacleLocations1.Clear();
                check1 = false;
            }
            Timer = spawnRate;
        }
    }
}
