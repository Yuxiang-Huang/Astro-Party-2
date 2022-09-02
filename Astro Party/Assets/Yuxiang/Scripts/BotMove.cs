using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    public float botReloadTime;

    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = this.gameObject;
        float minDistance = 10000;

        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            if (!shipList.Contains(this.gameObject))
            {
                foreach (GameObject ship in shipList)
                {
                    if (ship != this.gameObject)
                    {
                        if (distance(ship, this.gameObject) < minDistance)
                        {
                            target = ship;
                        }
                    }
                }
            }
        }

        agent.SetDestination(target.transform.position);

        if (botReloadTime > 0)
        {
            botReloadTime -= Time.deltaTime;
            botReloadTime = Mathf.Max(botReloadTime, 0);
        }

        if (botReloadTime == 0)
        {
            botReloadTime = 1;
            GetComponent<MutualShip>().shoot();
        }
    }

    float distance(GameObject ship1, GameObject ship2)
    {
        return Mathf.Sqrt(Mathf.Pow((ship1.transform.position.x - ship2.transform.position.x), 2) +
            Mathf.Pow((ship1.transform.position.z - ship2.transform.position.z), 2));
    }
}
