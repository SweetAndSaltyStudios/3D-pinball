using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinds : MonoBehaviour
{
    private bool waitingForKey = false;

    private Transform keyBinds;
    private Event keyEvent;
    private Text buttonText;
    private KeyCode newKey;

    private void Start ()
    {
        keyBinds = this.transform;
        SetKeys();
    }

    private void OnGUI()
    {
        keyEvent = Event.current;

        if (keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    private void SetKeys()
    {
        for (int i = 0; i < 6; i++)
        {
            if (keyBinds.GetChild(i).name == "PlungerKey")
            {
                keyBinds.GetChild(i).GetComponentInChildren<Text>().text = InputManager.instance.plunger.ToString();
            }
            else if (keyBinds.GetChild(i).name == "LeftFlipperKey")
            {
                keyBinds.GetChild(i).GetComponentInChildren<Text>().text = InputManager.instance.leftFlipper.ToString();
            }
            else if (keyBinds.GetChild(i).name == "RightFlipperKey")
            {
                keyBinds.GetChild(i).GetComponentInChildren<Text>().text = InputManager.instance.rightFlipper.ToString();
            }
            else if (keyBinds.GetChild(i).name == "RestartKey")
            {
                keyBinds.GetChild(i).GetComponentInChildren<Text>().text = InputManager.instance.restart.ToString();
            }
            else if (keyBinds.GetChild(i).name == "PauseKey")
            {
                keyBinds.GetChild(i).GetComponentInChildren<Text>().text = InputManager.instance.pause.ToString();
            }
            else if (keyBinds.GetChild(i).name == "ExitKey")
            {
                keyBinds.GetChild(i).GetComponentInChildren<Text>().text = InputManager.instance.exit.ToString();
            }
        }
    }

    public void StartAssignment(string keyName)
    {
        if (!waitingForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }
    }

    public void SendText(Text text)
    {
        buttonText = text;
    }

    private IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
        {
            yield return null;
        }
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;

        yield return WaitForKey();

        switch (keyName)
        {
            case "plunger":
                InputManager.instance.plunger = newKey;
                buttonText.text = InputManager.instance.plunger.ToString();
                PlayerPrefs.SetString("plungerKey", InputManager.instance.plunger.ToString());
                break;
            case "leftFlipper":
                InputManager.instance.leftFlipper = newKey;
                buttonText.text = InputManager.instance.leftFlipper.ToString();
                PlayerPrefs.SetString("leftFlipperKey", InputManager.instance.leftFlipper.ToString());
                break;
            case "rightFlipper":
                InputManager.instance.rightFlipper = newKey;
                buttonText.text = InputManager.instance.rightFlipper.ToString();
                PlayerPrefs.SetString("rightFlipperKey", InputManager.instance.rightFlipper.ToString());
                break;
            case "restart":
                InputManager.instance.restart = newKey;
                buttonText.text = InputManager.instance.restart.ToString();
                PlayerPrefs.SetString("restartKey", InputManager.instance.restart.ToString());
                break;
            case "pause":
                InputManager.instance.pause = newKey;
                buttonText.text = InputManager.instance.pause.ToString();
                PlayerPrefs.SetString("pauseKey", InputManager.instance.pause.ToString());
                break;
            case "exit":
                InputManager.instance.exit = newKey;
                buttonText.text = InputManager.instance.exit.ToString();
                PlayerPrefs.SetString("exitKey", InputManager.instance.exit.ToString());
                break;
        }

        yield return null;
    }
}
