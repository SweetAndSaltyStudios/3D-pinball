using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;

public class SettingManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Dropdown antialiasingDropdown;
    public Dropdown vSyncDropdown;
    public Slider masterScrollbar;
    public Slider musicScrollbar;
    public Slider sfxScrollbar;
    public Button applyButton;

    public Resolution[] resolutions;
    public GameSettings gameSettings;

    public AudioMixer audioMixer;

    private void Awake()
    {
        masterScrollbar.value = PlayerPrefs.GetFloat("Master");
        musicScrollbar.value = PlayerPrefs.GetFloat("Music");
        sfxScrollbar.value = PlayerPrefs.GetFloat("Sfx");
    }

    private void Start()
    {
        if(masterScrollbar.value == 0)
        {
            audioMixer.SetFloat("Master", 20f * Mathf.Log10(masterScrollbar.value));
        }
        if (musicScrollbar.value == 0)
        {
            audioMixer.SetFloat("Master", 20f * Mathf.Log10(masterScrollbar.value));
        }
        if (sfxScrollbar.value == 0)
        {
            audioMixer.SetFloat("Master", 20f * Mathf.Log10(sfxScrollbar.value));
        }

        audioMixer.SetFloat("Master", 20f * Mathf.Log10(masterScrollbar.value));
        audioMixer.SetFloat("Music", 20f * Mathf.Log10(musicScrollbar.value));
        audioMixer.SetFloat("Sfx", 20f * Mathf.Log10(sfxScrollbar.value));
    }


    private void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        antialiasingDropdown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { OnVSyncChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolutions = Screen.resolutions;

        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }

    public void OnFullscreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropdown.value;
    }

    public void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
    }

    public void OnAntialiasingChange()
    {
        QualitySettings.antiAliasing = (int)Mathf.Pow(2, antialiasingDropdown.value);
        gameSettings.antialiasing = antialiasingDropdown.value;
    }

    public void OnVSyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

        fullscreenToggle.isOn = gameSettings.fullscreen;
        resolutionDropdown.value = gameSettings.resolutionIndex;
        textureQualityDropdown.value = gameSettings.textureQuality;
        antialiasingDropdown.value = gameSettings.antialiasing;
        vSyncDropdown.value = gameSettings.vSync;

        Screen.fullScreen = gameSettings.fullscreen;

        resolutionDropdown.RefreshShownValue();
    }

    public void Master(float masterVolume)
    {
        audioMixer.SetFloat("Master", 20f * Mathf.Log10(masterVolume));
        PlayerPrefs.SetFloat("Master", masterVolume);
        PlayerPrefs.Save();
    }

    public void MusicSlider(float musicVolume)
    {
        audioMixer.SetFloat("Music", 20f * Mathf.Log10(musicVolume));
        PlayerPrefs.SetFloat("Music", musicVolume);
        PlayerPrefs.Save();
    }

    public void SfxSlider(float sfxVolume)
    {
        audioMixer.SetFloat("Sfx", 20f * Mathf.Log10(sfxVolume));
        PlayerPrefs.SetFloat("Sfx", sfxVolume);
        PlayerPrefs.Save();
    }
}
