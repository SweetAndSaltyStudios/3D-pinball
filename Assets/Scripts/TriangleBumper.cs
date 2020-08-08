using UnityEngine;
using System.Collections;

public class TriangleBumper : MonoBehaviour
{
    private int scoreValue = 50;

    [SerializeField]
    private float force;

    private Light triangleBumperLight;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        triangleBumperLight = GetComponentInChildren<Light>();
        triangleBumperLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(transform.right * force);
        ScoreManager.score += scoreValue;
        audioSource.Play();
        StartCoroutine("FlahingLights");
        
    }

    private IEnumerator FlahingLights()
    {
        triangleBumperLight.enabled = true;
        yield return new WaitForSeconds(0.1f);
        triangleBumperLight.enabled = false;
    }   
}
