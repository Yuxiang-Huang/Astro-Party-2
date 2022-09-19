using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotPilotMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    GameManager gameManagerScript;
    ScoreManager scoreManagerScript;
    SEManager SEManagerScript;

    public int id;
    public int team;

    public Renderer bodyRend;
    public Renderer headRend;
    public Material blue1;
    public Material red2;
    public Material yellow3;
    public Material cyan4;
    public Material green5;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        SEManagerScript = GameObject.Find("SoundEffect Manager").GetComponent<SEManager>();

        switch (id)
        {
            case 1:
                bodyRend.material = blue1;
                headRend.material = blue1;
                break;
            case 2:
                bodyRend.material = red2;
                headRend.material = red2;
                break;
            case 3:
                bodyRend.material = yellow3;
                headRend.material = yellow3;
                break;
            case 4:
                bodyRend.material = cyan4;
                headRend.material = cyan4;
                break;
            case 5:
                bodyRend.material = green5;
                headRend.material = green5;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int[] corners = new int[4];

        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            if (!shipList.Contains(this.gameObject))
            {
                foreach (GameObject ship in shipList)
                {
                    if (ship != this.gameObject)
                    {
                        if (ship.transform.position.x > 0)
                        {
                            if (ship.transform.position.z > 0)
                            {
                                corners[0]++;
                            }
                            else
                            {
                                corners[3]++;
                            }
                        }
                        else
                        {
                            if (ship.transform.position.x > 0)
                            {
                                if (ship.transform.position.z > 0)
                                {
                                    corners[1]++;
                                }
                                else
                                {
                                    corners[2]++;
                                }
                            }
                        }
                    }
                }
            }
        }

        Vector3 target = transform.position;

        if (corners[0] == 0)
        {
            target = new Vector3(gameManagerScript.spawnX, transform.position.y, gameManagerScript.spawnZ);
        }

        if (corners[1] == 0)
        {
            target = new Vector3(-gameManagerScript.spawnX, transform.position.y, gameManagerScript.spawnZ);
        }

        if (corners[2] == 0)
        {
            target = new Vector3(-gameManagerScript.spawnX, transform.position.y, -gameManagerScript.spawnZ);
        }

        if (corners[3] == 0)
        {
            target = new Vector3(gameManagerScript.spawnX, transform.position.y, -gameManagerScript.spawnZ);
        }

        //Debug.Log(target);
        transform.rotation = Quaternion.Euler(90, 0, 0);

        agent.SetDestination(target);
    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(7f);

        GameObject targetShip = null;

        foreach (List<GameObject> shipList in gameManagerScript.ships)
        {
            foreach (GameObject ship in shipList)
            {
                if (ship.GetComponent<MutualShip>().id == id)
                {
                    targetShip = ship;
                }
            }
        }

        GameObject myShip = Instantiate(targetShip, transform.position, transform.rotation);
        myShip.SetActive(true);
        myShip.transform.Rotate(-90, 0, 0);
        myShip.GetComponent<MutualShip>().team = team;
        myShip.GetComponent<MutualShip>().id = id;

        gameManagerScript.inGameShips[team].Add(myShip);
        gameManagerScript.inGameShips[team].Remove(this.gameObject);

        Destroy(this.gameObject);
    }

    public void kill(int otherID, int otherTeam)
    {
        bool toKill = true;
        //Friendly Fire 
        if (!scoreManagerScript.friendlyFire)
        {
            if (team == otherTeam)
            {
                toKill = false;
            }
        }
        if (toKill)
        {
            //sound effect
            SEManagerScript.generalAudio.PlayOneShot(SEManagerScript.pilotDeath);

            Destroy(this.gameObject);

            if (scoreManagerScript.shipMode == "pilot")
            {
                earnPoint(otherID);
            }
        }
    }

    void earnPoint(int ID)
    {
        if (scoreManagerScript.gameMode == "solo")
        {
            switch (ID)
            {
                case 1:
                    scoreManagerScript.P1Score++;
                    break;
                case 2:
                    scoreManagerScript.P2Score++;
                    break;
                case 3:
                    scoreManagerScript.P3Score++;
                    break;
                case 4:
                    scoreManagerScript.P4Score++;
                    break;
                case 5:
                    scoreManagerScript.P5Score++;
                    break;
            }
        }
    }
}