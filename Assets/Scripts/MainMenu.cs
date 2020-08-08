using System.Collections;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        Time.timeScale = 1;

        animator.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        animator.SetTrigger("MainMenuOpen");
    }

    public void Play()
    {
        StartCoroutine(MusicFadeOut(audioSource, 1f));
        animator.SetTrigger("MainMenuClose");
        animator.SetTrigger("FadeOut");
        animator.SetTrigger("Play");
    }

    public void OpenOptions()
    {
        animator.SetTrigger("MainMenuClose");
        animator.SetTrigger("OptionsOpen");
    }

    public void CloseOptions()
    {
        animator.SetTrigger("OptionsClose");
        animator.SetTrigger("MainMenuOpen");
    }

    public void OpenAudio()
    {
        animator.SetTrigger("OptionsClose");
        animator.SetTrigger("AudioOpen");
    }

    public void CloseAudio()
    {
        animator.SetTrigger("AudioClose");
        animator.SetTrigger("OptionsOpen");
    }

    public void OpenControls()
    {
        animator.SetTrigger("OptionsClose");
        animator.SetTrigger("ControlsOpen");
    }

    public void CloseControls()
    {
        animator.SetTrigger("ControlsClose");
        animator.SetTrigger("OptionsOpen");
    }

    public void OpenDisplay()
    {
        animator.SetTrigger("OptionsClose");
        animator.SetTrigger("DisplayOpen");
    }

    public void CloseDisplay()
    {
        animator.SetTrigger("DisplayClose");
        animator.SetTrigger("OptionsOpen");
    }

    public void Quit()
    {
        animator.SetTrigger("MainMenuClose");
        animator.SetTrigger("FadeOut");
        animator.SetTrigger("Quit");
    }

    private IEnumerator MusicFadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
