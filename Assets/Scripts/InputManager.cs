using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public KeyCode plunger { get; set; }

    public KeyCode leftFlipper { get; set; }
    public KeyCode rightFlipper { get; set; }

    public KeyCode restart { get; set; }
    public KeyCode pause { get; set; }
    public KeyCode exit { get; set; }

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        plunger = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("plungerKey", "Space"));

        leftFlipper = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftFlipperKey", "Z"));
        rightFlipper = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightFlipperKey", "X"));

        restart = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("restartKey", "R"));
        pause = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pauseKey", "Escape"));
        exit = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("exitKey", "E"));
    }
}
