using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneManager.LoadScene(0);
    }
}
