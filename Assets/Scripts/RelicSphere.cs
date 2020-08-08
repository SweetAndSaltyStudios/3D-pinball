using UnityEngine;

public class RelicSphere : MonoBehaviour
{
    private int scoreValue = 1000;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            audioSource.Play();

            GameMaster.relicScoreAnimation = true;
            ScoreManager.lives += 1;
            ScoreManager.ballCount -= 1;
            ScoreManager.score += scoreValue * 1000;
        }
    }
}
