using UnityEngine;

public class Plunger : MonoBehaviour
{
    [HideInInspector]
    public bool isPressed = false;
    [SerializeField]
    private float maxPull = -3.0f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (GameMaster.isPlaying == false)
        {
            return;
        }

        if (Input.GetKey(InputManager.instance.plunger) || isPressed)
        {
            rb.isKinematic = true;

            if (transform.localPosition.y > maxPull)
            {
                transform.Translate(Vector3.up * -1 * Time.deltaTime);
            }
        }
        else
        {
            rb.WakeUp();
            rb.isKinematic = false;
        }      
    }
}