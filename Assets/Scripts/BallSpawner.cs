using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    [HideInInspector]
    public Transform spawnPoint;
    [SerializeField]
    private GameObject ballPrefab;
    [SerializeField]
    private AudioSource audioSource1;
    [SerializeField]
    private AudioSource audioSource2;

    private GameMaster gameMaster;

    private void Start()
    {
        gameMaster = FindObjectOfType<GameMaster>();
    }

    public IEnumerator SpawnBall(Transform position)
    {   
        yield return new WaitForSeconds(0.5f);
        audioSource1.Play();
        yield return new WaitForSeconds(1);
        Instantiate(ballPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball" )
        {
            gameMaster.secondMonitorAnimator.SetTrigger("PressToLaunch");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            audioSource2.Play();
            gameMaster.secondMonitorAnimator.SetTrigger("Launched");
        }
    }
}
