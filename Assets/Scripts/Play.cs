using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : StateMachineBehaviour
{
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneManager.LoadScene(1);
	}
}
