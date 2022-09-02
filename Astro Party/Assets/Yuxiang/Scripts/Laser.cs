using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int id;
    ScoreManager scoreManagerScript;

    public int team;

    // Start is called before the first frame update
    void Start()
    {
        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        StartCoroutine("selfDestruct");
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pilot"))
        {
            //Friendly Fire 
            if (!scoreManagerScript.friendlyFire)
            {
                if (team != collision.gameObject.GetComponent<PilotPlayerController>().team)
                {
                    Destroy(collision.gameObject);
                    earnPoint();
                }
            }
            else
            {
                Destroy(collision.gameObject);
                earnPoint();
            }
        }


        if (collision.gameObject.CompareTag("Ship"))
        {
            //Friendly Fire 
            if (!scoreManagerScript.friendlyFire)
            {
                if (team != collision.gameObject.GetComponent<ID>().team)
                {
                    if (collision.gameObject.GetComponent<PlayerController>() != null)
                    {
                        collision.gameObject.GetComponent<PlayerController>().spawnPilot(scoreManagerScript.shipMode);
                    }
                    else if (collision.gameObject.GetComponent<BotMove>() != null)
                    {
                        collision.gameObject.GetComponent<BotMove>().spawnPilot(scoreManagerScript.shipMode);
                    }

                    earnPoint();
                }
            }
            else
            {
                earnPoint();

                if (collision.gameObject.GetComponent<PlayerController>() != null)
                {
                    collision.gameObject.GetComponent<PlayerController>().spawnPilot(scoreManagerScript.shipMode);
                }
                else if (collision.gameObject.GetComponent<BotMove>() != null)
                {
                    collision.gameObject.GetComponent<BotMove>().spawnPilot(scoreManagerScript.shipMode);
                }
            }
        }
    }

    void earnPoint()
    {
        if (scoreManagerScript.shipMode == "ship")
        {
            if (scoreManagerScript.gameMode == "solo")
            {
                switch (id)
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
                }
            }
        }
    }
}
