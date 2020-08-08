using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        animator.GetComponent<Animator>();
        
    }
}
