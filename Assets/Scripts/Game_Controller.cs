using System.Collections;
using System.Collections.Generic;
using EasyTransition;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    // Class attribute
    [SerializeField] private Light_obj[] _level;
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float loadDelay;

    private int moveCounter;

    // Start is called before the first frame update
    void Start()
    {
        moveCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;

        for (int i = 0; i < _level.Length; i++)
        {
            if (_level[i].getState()) count++;
        }

        if (count == 0)
        { 
            Debug.Log("Game Finished!");

            for (int i = 0; i < _level.Length; i++)
            {
                _level[i].finishLevel();
            }

            StartCoroutine(levelComplete());
        }
    }

    public int getMoveCounter() { return moveCounter; }

    public void increaseMoveCounter() { moveCounter++; }

    IEnumerator levelComplete()
    {
        yield return new WaitForSeconds(1);

        TransitionManager.Instance().Transition("Scenes/Level_selector", transition, loadDelay);
    }
}
