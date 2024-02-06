using System.Collections;
using System.Collections.Generic;
using EasyTransition;
using UnityEngine;

public class Button_script : MonoBehaviour
{
    // Button attributes
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float loadDelay;

    public void LoadScene(string _sceneName)
    {
        TransitionManager.Instance().Transition("Scenes/" + _sceneName, transition, loadDelay);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
