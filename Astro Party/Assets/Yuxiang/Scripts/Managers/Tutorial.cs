using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject prepScreen;
    public GameObject directionScreen;
    public GameObject endScreen;

    public GameObject endScreenText;

    public GameObject playerShip;

    public GameObject tutorialMap;

    public List<GameObject> directions;
    int directionId = 0;
    public GameObject endButton;
    public GameObject lastDirectionButton;
    public GameObject nextDirectionButton;

    bool started;
    int spawnRadius = 700;

    public int shipId;
    public KeyCode shipRotate;
    public KeyCode shipShoot;

    public GameObject cube0;
    public GameObject cube1;
    public List<GameObject> threeBody;
    public List<GameObject> asteroids;
    public GameObject laserIndicator;
    public GameObject bot;
    public GameObject bot2;

    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        shipRotate = KeyCode.A;
        shipShoot = KeyCode.S;

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        end();
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (distance(playerShip.transform.position, new Vector3(0, 0, 0)) > spawnRadius)
            {
                float angle = Mathf.Atan2(playerShip.transform.position.x, playerShip.transform.position.z);

                playerShip.transform.position =
                    new Vector3(spawnRadius * Mathf.Sin(angle), 10, spawnRadius * Mathf.Cos(angle));
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (endScreen.activeSelf)
                {
                    endScreen.SetActive(false);
                    Time.timeScale = 1;
                }
                else
                {
                    endScreen.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }

        if (started && gameManagerScript.inGameShips[0][0] == null)
        {
            endScreen.SetActive(true);
            endScreenText.SetActive(true);
        }
    }

    public void prep()
    {
        startScreen.SetActive(false);
        prepScreen.SetActive(true);
    }

    public void backToStart()
    {
        prepScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void startTutorial()
    {
        prepScreen.SetActive(false);
        tutorialMap.SetActive(true);

        GameObject shipPlayer = Instantiate(playerShip, new Vector3(0, 10, 0),
playerShip.transform.rotation);
        shipPlayer.GetComponent<MutualShip>().id = shipId;
        shipPlayer.GetComponent<PlayerController>().turn = shipRotate;
        shipPlayer.GetComponent<PlayerController>().shoot = shipShoot;
        gameManagerScript.inGameShips[0].Add(shipPlayer);

        directionScreen.SetActive(true);
        directions[0].gameObject.SetActive(true);
        started = true;
    }

    public void nextDirection()
    {
        if (directionId == 0)
        {
            lastDirectionButton.SetActive(true);
        }

        directions[directionId].SetActive(false);
        directionId++;
        directions[directionId].SetActive(true);

        if (directionId == directions.Count - 1)
        {
            nextDirectionButton.SetActive(false);
        }

        //special directions
        if (directionId == 3)
        {
            foreach (GameObject asteroid in asteroids)
            {
                GameObject curr = Instantiate(asteroid, generateRanPos(), asteroid.transform.rotation);
                gameManagerScript.inGameAsteroids.Add(curr);
            }
        }

        if (directionId == 5)
        {
            GameObject curr = Instantiate(laserIndicator, generateRanPos(), laserIndicator.transform.rotation);
            gameManagerScript.inGameIndicators.Add(curr);

            //GameObject bot = Instantiate(bot, generateRanPos(), laserIndicator.transform.rotation);
            //curr.GetComponent<Asteroid>().powerUp = laserIndicator;
            //gameManagerScript.inGameIndicators.Add(curr);
        }

        if (directionId == 6)
        {
            cube0.transform.position = generateRanPos();
            cube1.transform.position = generateRanPos();
            cube0.SetActive(true);
            cube1.SetActive(true);
        }

        if (directionId == 7)
        {
            foreach (GameObject body in threeBody)
            {
                spawnBody(body);
            }
            endButton.SetActive(true);
        }
    }

    void spawnBody(GameObject body)
    {
        body.transform.position = generateRanPos();

        body.GetComponent<Rigidbody>().velocity =
            new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));

        body.SetActive(true);
    }

    Vector3 generateRanPos()
    {
        Vector3 ranPos = new Vector3(Random.Range(-spawnRadius, spawnRadius), -10,
          Random.Range(-spawnRadius, spawnRadius));

        while (distance(ranPos, new Vector3(0, 0, 0)) > spawnRadius ||
            distance(playerShip.transform.position, ranPos) < 100)
        {
            ranPos = new Vector3(Random.Range(-spawnRadius, spawnRadius), -10,
Random.Range(-spawnRadius, spawnRadius));
        }

        return ranPos;
    }

    float distance(Vector3 ship1, Vector3 ship2)
    {
        return Mathf.Sqrt(Mathf.Pow((ship1.x - ship2.x), 2) + Mathf.Pow((ship1.z - ship2.z), 2));
    }

    public void lastDirection()
    {
        if (directionId == directions.Count - 1)
        {
            nextDirectionButton.SetActive(true);
        }

        directions[directionId].SetActive(false);
        directionId--;
        directions[directionId].SetActive(true);

        if (directionId == 0)
        {
            lastDirectionButton.SetActive(false);
        }
    }

    public void end()
    {
        //screens and maps
        prepScreen.SetActive(false);
        directionScreen.SetActive(false);
        endScreen.SetActive(false);
        startScreen.SetActive(true);
        tutorialMap.SetActive(false);

        //directions
        directionId = 0;
        nextDirectionButton.SetActive(true);
        lastDirectionButton.SetActive(false);
        endButton.SetActive(false);
        foreach (GameObject direction in directions)
        {
            direction.SetActive(false);
        }

        cube0.SetActive(false);
        cube1.SetActive(false);
        foreach (GameObject body in threeBody)
        {
            body.SetActive(false);
        }

        gameManagerScript.endRound();

        //others
        started = false;
        endScreenText.SetActive(false);
        Time.timeScale = 1;
    }
}
