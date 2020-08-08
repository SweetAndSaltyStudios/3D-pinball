using UnityEngine;

public class BallEngine : MonoBehaviour
{
    private Rigidbody rb;

	private void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = Mathf.Infinity;
	}

    private void FixedUpdate()
    {
       rb.WakeUp();
    }
}
