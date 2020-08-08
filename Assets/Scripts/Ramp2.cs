using UnityEngine;

public class Ramp2 : MonoBehaviour
{
    [SerializeField]
    private int scoreValue = 50;

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

            GameMaster.mediumScoreAnimation = true;
            ScoreManager.score += scoreValue * 100;
        }
    }
}
