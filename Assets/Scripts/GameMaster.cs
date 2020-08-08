using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
    public static bool isPlaying = false;
    public static bool highScoreAnimation = false;
    public static bool mediumScoreAnimation = false;
    public static bool relicScoreAnimation = false;

    private bool paused = false;

    private BallSpawner ballSpawner;
    private ScoreManager scoreManager;
    private LightManager lightManager;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip backgroundMusic;
    [SerializeField]
    private AudioClip spotLightSound;
    [SerializeField]
    private AudioClip gameOverSound;

    public GameObject pausedTexts, pressToLaunchText, ballInRamp, relic;
    [HideInInspector]
    public Animator canvasAnimator;
    [HideInInspector]
    public Animator secondMonitorAnimator;
    [HideInInspector]
    public ParticleSystem fire1;
    [HideInInspector]
    public ParticleSystem fire2;
    [HideInInspector]
    public AudioSource fire1Audio;
    [HideInInspector]
    public AudioSource fire2Audio;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        pausedTexts.SetActive(false);
        canvasAnimator.SetTrigger("FadeIn");
        ballSpawner = FindObjectOfType<BallSpawner>();
        scoreManager = FindObjectOfType<ScoreManager>();
        lightManager = FindObjectOfType<LightManager>();

        GameOver();
    }
    private void Update()
    {
        ScoreAnimation();

        if (Input.GetKey(InputManager.instance.restart) && !isPlaying && !paused)
        {
            NewGame();
        }

        if (Input.GetKeyDown(InputManager.instance.pause) && !paused)
        {
            canvasAnimator.SetTrigger("Pause");
            secondMonitorAnimator.SetTrigger("Start2ndBlink");
            Time.timeScale = 0;
            paused = true;
            pausedTexts.SetActive(true);
            pressToLaunchText.SetActive(false);
            ballInRamp.SetActive(false);
        }
        else if(Input.GetKeyDown(InputManager.instance.pause) && paused)
        {
            canvasAnimator.SetTrigger("UnPause");
            secondMonitorAnimator.SetTrigger("Stop2ndBlink");
            Time.timeScale = 1;
            paused = false;
            pausedTexts.SetActive(false);
            pressToLaunchText.SetActive(true);
            ballInRamp.SetActive(true);
        }
        else if(Input.GetKeyDown(InputManager.instance.exit) && paused)
        {
            canvasAnimator.SetTrigger("FadeOut");
        }
    }

    public void NewGame()
    {
        relic.SetActive(true);
        StartCoroutine("NewGameSounds");
        isPlaying = true;
        scoreManager.SetNewGameScore();
        lightManager.StartLight();
        ballSpawner.StartCoroutine(ballSpawner.SpawnBall(ballSpawner.spawnPoint));
    }

    public void GameOver()
    {
        relic.SetActive(false);
        audioSource.Stop();
        isPlaying = false;
        scoreManager.SetEndGameScore();
        lightManager.StopLight();
        fire1.Stop();
        fire2.Stop();
    }

    public void ScoreAnimation()
    {
        if (mediumScoreAnimation)
        {
            secondMonitorAnimator.SetTrigger("MediumScore");
            mediumScoreAnimation = false;
        }
        else if (highScoreAnimation)
        {
            secondMonitorAnimator.SetTrigger("HighScore");
            highScoreAnimation = false;
        }
        else if (relicScoreAnimation)
        {
            secondMonitorAnimator.SetTrigger("RelicScore");
            relicScoreAnimation = false;
        }
    }

    private IEnumerator NewGameSounds()
    {
        audioSource.loop = false;
        audioSource.volume = 1f;
        audioSource.clip = spotLightSound;
        audioSource.Play();

        yield return new WaitForSeconds(3f);

        audioSource.loop = true;
        audioSource.volume = 0.3f;
        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }
}
