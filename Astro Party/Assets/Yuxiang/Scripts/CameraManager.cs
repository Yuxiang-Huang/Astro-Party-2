using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera myCamera;
    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void LateUpdate()
    {
        float minX = gameManagerScript.spawnX;
        float maxX = -gameManagerScript.spawnX;
        float minZ = gameManagerScript.spawnZ;
        float maxZ = -gameManagerScript.spawnZ;

        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            foreach (GameObject ship in shipList)
            {
                if (ship != null)
                {
                    minX = Mathf.Min(minX, ship.transform.position.x);
                    maxX = Mathf.Max(maxX, ship.transform.position.x);
                    minZ = Mathf.Min(minZ, ship.transform.position.z);
                    maxZ = Mathf.Max(maxZ, ship.transform.position.z);
                }
            }
        }

        float lenX = (maxX - minX) / 2;

        float lenZ = (maxZ - minZ) / 2;

        //Debug.Log("minX before: " + minX);

        minX = Mathf.Max(minX - lenX, -gameManagerScript.spawnX - 100);
        maxX = Mathf.Min(maxX + lenX, gameManagerScript.spawnX + 100);

        minZ = Mathf.Max(minZ - lenZ, -gameManagerScript.spawnZ - 100);
        maxZ = Mathf.Min(maxZ + lenZ, gameManagerScript.spawnZ + 100);

        myCamera.orthographicSize = Mathf.Max(500, Mathf.Max((maxX - minX) / 2, (maxZ - minZ))) / 2;

        transform.position = new Vector3((minX + maxX) / 2, transform.position.y, (minZ + maxZ) / 2);

        //Debug.Log("minX after: " + minX);
        //Debug.Log("minZ: " + minZ);
        //Debug.Log("maxX: " + maxX);
        //Debug.Log("maxZ: " + maxZ);
    }
}
