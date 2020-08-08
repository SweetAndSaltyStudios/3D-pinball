using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private BallSpawner ballSpawner;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private GameMaster gameMaster;

    private LightManager lightManager;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ballSpawner = FindObjectOfType<BallSpawner>();
        gameMaster = FindObjectOfType<GameMaster>();
        lightManager = FindObjectOfType<LightManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            if (ScoreManager.lives > 0 && GameMaster.isPlaying)
            {
                audioSource.Play();
                ScoreManager.lives -= 1;
                ScoreManager.ballCount += 1;
                Destroy(other.gameObject);
                StartCoroutine(ballSpawner.SpawnBall(spawnPoint));

                if(ScoreManager.ballCount >= 3)
                {
                    gameMaster.fire1.Play();
                    gameMaster.fire1Audio.Play();

                    gameMaster.fire2.Play();
                    gameMaster.fire2Audio.Play();
                }
            }
            else
            {
                audioSource.Play();
                ScoreManager.lives = 0;
                Destroy(other.gameObject);
                lightManager.StopLight();
                gameMaster.GameOver();
            }           
        }
    }
}
