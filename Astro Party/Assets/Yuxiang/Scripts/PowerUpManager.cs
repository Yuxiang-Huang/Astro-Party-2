using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public List<GameObject> indicators = new List<GameObject>();

    public GameObject bullet;

    public Text P1CurrText;
    public Text P2CurrText;
    public Text P3CurrText;
    public Text P4CurrText;

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

    public GameObject tripleShotIndicator;
    public Text tripleText;
    public Text P1TripleText;
    public Text P2TripleText;
    public Text P3TripleText;
    public Text P4TripleText;

    public GameObject freezer;
    public GameObject freezerIndicator;
    public Text freezerText;
    public Text P1FreezerText;
    public Text P2FreezerText;
    public Text P3FreezerText;
    public Text P4FreezerText;

    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        indicators.Add(laserIndicator);
        indicators.Add(scatterIndicator);
        indicators.Add(tripleShotIndicator);
        indicators.Add(freezerIndicator);

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

    public void setTripleShot()
    {
        if (indicators.Contains(tripleShotIndicator))
        {
            indicators.Remove(tripleShotIndicator);
            tripleText.text = "Triple Shot: Off";
        }
        else
        {
            indicators.Add(tripleShotIndicator);
            tripleText.text = "Triple Shot: On";
        }
    }

    public void setFreezer()
    {
        if (indicators.Contains(freezerIndicator))
        {
            indicators.Remove(freezerIndicator);
            freezerText.text = "Freezer: Off";
        }
        else
        {
            indicators.Add(freezerIndicator);
            freezerText.text = "Freezer: On";
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
                case "Scatter Shot":
                    GameObject toAdd1 = Instantiate(scatterIndicator, transform.position, scatterIndicator.transform.rotation);
                    gameManagerScript.inGameIndicators.Add(toAdd1);
                    break;
                case "Freezer":
                    GameObject toAdd2 = Instantiate(freezerIndicator, transform.position, freezerIndicator.transform.rotation);
                    gameManagerScript.inGameIndicators.Add(toAdd2);
                    break;
            }
        }
    }

    //Players
    //Laser Beam
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

    //Scatter Shot

    public void setScatterP1()
    {
        setHelper("Scatter Shot", P1scatterText, 1);
    }

    public void setScatterP2()
    {
        setHelper("Scatter Shot", P2scatterText, 2);
    }

    public void setScatterP3()
    {
        setHelper("Scatter Shot", P3scatterText, 3);
    }

    public void setScatterP4()
    {
        setHelper("Scatter Shot", P4scatterText, 4);
    }

    //Freezer

    public void setFreezerP1()
    {
        setHelper("Freezer", P1FreezerText, 1);
    }

    public void setFreezerP2()
    {
        setHelper("Freezer", P2FreezerText, 2);
    }

    public void setFreezerP3()
    {
        setHelper("Freezer", P3FreezerText, 3);
    }

    public void setFreezerP4()
    {
        setHelper("Freezer", P4FreezerText, 4);
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
                        switch (id)
                        {
                            case 1:
                                P1CurrText = null;
                                break;
                            case 2:
                                P2CurrText = null;
                                break;
                            case 3:
                                P3CurrText = null;
                                break;
                            case 4:
                                P4CurrText = null;
                                break;
                        }
                    }
                    else
                    { 
                        switch (id)
                        {
                            case 1:
                                if (P1CurrText != null)
                                    P1CurrText.text = script.shootMode + ": Off";
                                break;
                            case 2:
                                if (P2CurrText != null)
                                    P2CurrText.text = script.shootMode + ": Off";
                                break;
                            case 3:
                                if (P3CurrText != null)
                                    P3CurrText.text = script.shootMode + ": Off";
                                break;
                            case 4:
                                if (P4CurrText != null)
                                    P4CurrText.text = script.shootMode + ": Off";
                                break;
                        }

                        script.shootMode = modeString;
                        modeText.text = modeString + ": On";

                        switch (id)
                        {
                            case 1: P1CurrText = modeText; break;
                            case 2: P2CurrText = modeText; break;
                            case 3: P3CurrText = modeText; break;
                            case 4: P4CurrText = modeText; break;
                        }
                    }
                }
            }
        }
    }

    //Triple Shot

    public void setTripleP1()
    {
        setTripleHelper(1, P1TripleText);
    }

    public void setTripleP2()
    {
        setTripleHelper(2, P2TripleText);
    }

    public void setTripleP3()
    {
        setTripleHelper(3, P3TripleText);
    }

    public void setTripleP4()
    {
        setTripleHelper(4, P4TripleText);
    }

    void setTripleHelper(int id, Text modeText)
    {
        foreach (List<GameObject> shipList in gameManagerScript.ships)
        {
            foreach (GameObject ship in shipList)
            {
                MutualShip script = ship.GetComponent<MutualShip>();
                if (script.id == id)
                {
                    if (script.tripleShot)
                    {
                        script.tripleShot = false;
                        modeText.text = "Triple Shot: Off";
                    }
                    else
                    {
                        script.tripleShot = true;
                        modeText.text = "Triple Shot: On";
                    }
                }
            }
        }
    }
}
