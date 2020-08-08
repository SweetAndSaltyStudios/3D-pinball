using UnityEngine;
using System.Collections;

public class RoundBumper : MonoBehaviour
{
    private int scoreValue = 100;
    [SerializeField]
    private int force = 250;
    [SerializeField]
    private float forceRadius = 1.0f;
    [SerializeField]
    private Light bumperLight;
    [SerializeField]
    private AudioSource audioSource;

    private void Start()
    {
        bumperLight = GetComponentInChildren<Light>();
        bumperLight.enabled = false;
    }

    private void OnCollisionEnter()
    {
        foreach (Collider col in Physics.OverlapSphere(transform.position, forceRadius))
        {
            if (col.tag == "Ball")
            {
                col.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, forceRadius);
                StartCoroutine("FlashingLights");
            }
        }
    }

    private IEnumerator FlashingLights()
    {
        audioSource.Play();
        ScoreManager.score += scoreValue;
        bumperLight.enabled = true;
        yield return new WaitForSeconds(0.1f);
        bumperLight.enabled = false;
    }
}
