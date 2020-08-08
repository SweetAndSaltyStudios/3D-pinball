using UnityEngine;

public class Quit : StateMachineBehaviour
{

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {       
    #if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;
    #else
                Application.Quit();
    #endif    
    }
}
