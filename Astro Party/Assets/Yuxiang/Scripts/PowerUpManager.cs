using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public List<GameObject> indicators = new List<GameObject>();

    public GameObject bullet;

    public GameObject laser;
    public GameObject laserIndicator;
    public Text laserText;
    public Text P1LaserText;
    public Text P2LaserText;
    public Text P3LaserText;
    public Text P4LaserText;

    public GameObject scatterIndicator;
    public Text scatterText;
    public Text P1scatterText;
    public Text P2scatterText;
    public Text P3scatterText;
    public Text P4scatterText;

    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        indicators.Add(laserIndicator);
        indicators.Add(scatterIndicator);

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLaser()
    {
        if (indicators.Contains(laserIndicator))
        {
            indicators.Remove(laserIndicator);
            laserText.text = "Laser Beam: Off";
        }
        else
        {
            indicators.Add(laserIndicator);
            laserText.text = "Laser Beam: On";
        }
    }

    public void setScatterShot()
    {
        if (indicators.Contains(scatterIndicator))
        {
            indicators.Remove(scatterIndicator);
            scatterText.text = "Scatter Shot: Off";
        }
        else
        {
            indicators.Add(scatterIndicator);
            scatterText.text = "Scatter Shot: On";
        }
    }

    public void dropItem(MutualShip script)
    {
        if (script.shootMode != "normal")
        {
            switch (script.shootMode)
            {
                case "Laser Beam":
                    GameObject toAdd = Instantiate(laserIndicator, transform.position, laserIndicator.transform.rotation);
                    gameManagerScript.inGameIndicators.Add(toAdd);
                    break;
            }
        }
    }

    //Players

    public void setLaserP1()
    {
        setHelper("Laser Beam", P1LaserText, 1);
    }

    public void setLaserP2()
    {
        setHelper("Laser Beam", P2LaserText, 2);
    }

    public void setLaserP3()
    {
        setHelper("Laser Beam", P3LaserText, 3);
    }

    public void setLaserP4()
    {
        setHelper("Laser Beam", P4LaserText, 4);
    }

    void setHelper(string modeString, Text modeText, int id)
    {
        foreach (List<GameObject> shipList in gameManagerScript.ships)
        {
            foreach (GameObject ship in shipList)
            {
                MutualShip script = ship.GetComponent<MutualShip>();
                if (script.id == id)
                {
                    if (script.shootMode == modeString)
                    {
                        script.shootMode = "normal";
                        modeText.text = modeString + ": Off";
                    }
                    else
                    {
                        script.shootMode = modeString;
                        modeText.text = modeString + ": On";
                    }
                }
            }
        }
    }
}
