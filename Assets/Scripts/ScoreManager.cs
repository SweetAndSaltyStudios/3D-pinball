using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int lives;
    public static int ballCount;

    [SerializeField]
    private TextMesh scoreDisplay;
    [SerializeField]
    private TextMesh liveDisplay;
    [SerializeField]
    private TextMesh gameOverText;
    [SerializeField]
    private TextMesh restartText;
    [HideInInspector]
    public Animator scoreboardAnimator;

    private void Update()
    {
        scoreDisplay.text = score.ToString("D8");
        liveDisplay.text = "BALLS : " + lives.ToString();
    }

    public void SetNewGameScore()
    {
        scoreboardAnimator.SetTrigger("StopBlink");
        scoreDisplay.gameObject.SetActive(true);
        liveDisplay.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);

        score = 0;
        lives = 3;
        ballCount = 0;
    }

    public void SetEndGameScore()
    {
        scoreboardAnimator.SetTrigger("StartBlink");
        scoreDisplay.gameObject.SetActive(false);
        liveDisplay.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);

        lives = 0;
        ballCount = 0;
    }
}