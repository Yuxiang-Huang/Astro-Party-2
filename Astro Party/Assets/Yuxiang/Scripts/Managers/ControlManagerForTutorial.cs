using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlManagerForTutorial : MonoBehaviour
{
    public int id;

    public GameObject shipPlayer;
    public Button PButton;
    public Button setRotateButton;
    public Button setShootButton;

    Tutorial tutorialScript;

    public Text PText;
    public Text rotateText;
    public Text shootText;

    // Start is called before the first frame update
    void Start()
    {
        //Creating ships
        shipPlayer = Instantiate(tutorialScript.playerShip, new Vector3(0, 0, 0),
            tutorialScript.playerShip.transform.rotation);
        shipPlayer.GetComponent<MutualShip>().id = id;
        shipPlayer.SetActive(false);

        tutorialScript.ships.Add(shipPlayer);

        setRotateButton.gameObject.SetActive(false);
        setShootButton.gameObject.SetActive(false);

        //set control
        PlayerController script = shipPlayer.GetComponent<PlayerController>();
        script.turn = KeyCode.A;
        script.shoot = KeyCode.D;
      
        rotateText.text = script.turn.ToString();
        shootText.text = script.shoot.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void buttonColorChange()
    {
        //button color
        Color c = new Color(0, 0, 255);

        switch (id)
        {
            case 1: c = new Color(0, 0, 255); break;
            case 2: c = new Color(255, 0, 0); break;
            case 3: c = new Color(255, 255, 0); break;
            case 4: c = new Color(0, 255, 255); break;
            case 5: c = new Color(0, 255, 0); break;
        }

        ColorBlock colors = PButton.colors;
        colors.normalColor = c;
        colors.selectedColor = c;
        colors.pressedColor = c;
        PButton.colors = colors;

        colors = setRotateButton.colors;
        colors.normalColor = c;
        colors.selectedColor = c;
        colors.pressedColor = c;
        setRotateButton.colors = colors;

        colors = setShootButton.colors;
        colors.normalColor = c;
        colors.selectedColor = c;
        colors.pressedColor = c;
        setShootButton.colors = colors;
    }

    public void shipButton()
    {
        id++;
        tutorialScript.ships[0].GetComponent<MutualShip>().id = id;
        buttonColorChange();
    }

    public void setRotate()
    {
        KeyCode now = KeyCode.None;

        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(kcode))
                now = kcode;
        }

        shipPlayer.GetComponent<PlayerController>().turn = now;
        rotateText.text = now.ToString();
    }

    public void setShoot()
    {
        KeyCode now = KeyCode.None;

        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(kcode))
                now = kcode;
        }

        shipPlayer.GetComponent<PlayerController>().shoot = now;
        shootText.text = now.ToString();
    }
}
