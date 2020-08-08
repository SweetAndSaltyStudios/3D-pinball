using UnityEngine;

public class FlipperR : MonoBehaviour
{
    private bool isActive = false;
    private HingeJoint myHingeJoint;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myHingeJoint = GetComponent<HingeJoint>();
        GetComponent<Rigidbody>().maxAngularVelocity = Mathf.Infinity;
    }

    private void FixedUpdate()
    {
        if (GameMaster.isPlaying == false)
        {
            return;
        }

        if (Input.GetKey(InputManager.instance.rightFlipper) && !isActive)
        {
            isActive = true;
            audioSource.Play();

            JointSpring spring = myHingeJoint.spring;
            spring.targetPosition = -25;

            myHingeJoint.spring = spring;
        }
        else if (!Input.GetKey(InputManager.instance.rightFlipper) && isActive)
        {
            isActive = false;
            JointSpring spring = myHingeJoint.spring;
            spring.targetPosition = 15;

            myHingeJoint.spring = spring;
        }

    }     
}
