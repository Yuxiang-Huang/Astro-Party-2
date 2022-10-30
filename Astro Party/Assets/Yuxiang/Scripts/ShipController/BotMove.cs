using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMove : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;

    float botReloadTime;

    GameManager gameManagerScript;

    float traceTime;

    public bool disable;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!disable)
        {
            GameObject target = this.gameObject;
            float minDistance = 10000;

            foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
            {
                foreach (GameObject ship in shipList)
                {
                    bool trace = true;

                    //don't trace teammates

                    if (ship.GetComponent<MutualShip>() != null)
                    {
                        if (ship.GetComponent<MutualShip>().team == GetComponent<MutualShip>().team)
                        {
                            trace = false;
                        }
                    }

                    if (ship.GetComponent<BotPilotMove>() != null)
                    {
                        if (ship.GetComponent<BotPilotMove>().team == GetComponent<MutualShip>().team)
                        {
                            trace = false;
                        }
                    }

                    if (ship.GetComponent<PilotPlayerController>() != null)
                    {
                        if (ship.GetComponent<PilotPlayerController>().team == GetComponent<MutualShip>().team)
                        {
                            trace = false;
                        }
                    }

                    if (trace)
                    {
                        target = ship;
                        minDistance = distance(ship, this.gameObject);
                    }
                }
                
            }

            //shooting
            botReloadTime += Time.deltaTime;

            if (botReloadTime >= 1)
            {
                botReloadTime = 0;
                GetComponent<MutualShip>().shoot();
            }

            //Can't trace too frequently
            if (traceTime <= 0)
            {
                agent.SetDestination(target.transform.position);
                traceTime = 1f;
            }
            if (traceTime > 0)
            {
                traceTime -= Time.deltaTime;
            }
        }
    }

    float distance(GameObject ship1, GameObject ship2)
    {
        return Mathf.Sqrt(Mathf.Pow((ship1.transform.position.x - ship2.transform.position.x), 2) +
            Mathf.Pow((ship1.transform.position.z - ship2.transform.position.z), 2));
    }
}