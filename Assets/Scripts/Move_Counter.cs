using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Move_Counter : MonoBehaviour
{
    // Class attributes
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private Game_Controller _gm;

    // Update is called once per frame
    void Update()
    {
        _score.text = ("Move: " + _gm.getMoveCounter());
    }
}
