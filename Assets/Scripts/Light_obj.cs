using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Light_obj : MonoBehaviour
{
    // Object attributes
    [SerializeField] private string _name;
    [SerializeField] private Light_obj _topNeighbour;
    [SerializeField] private Light_obj _leftNeighbour;
    [SerializeField] private Light_obj _rightNeighbour;
    [SerializeField] private Light_obj _bottomNeighbour;
    [SerializeField] private bool _state;
    private bool isGameFinished;
    private Renderer ren;

    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
        isGameFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameFinished)
        {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.transform.name == _name )
                    {
                        stateToggle();
                        if (_leftNeighbour != null) _leftNeighbour.stateToggle();
                        if (_rightNeighbour != null) _rightNeighbour.stateToggle();

                        Game_Controller gm = GameObject.FindAnyObjectByType<Game_Controller>();
                        if (gm != null)
                        {
                            gm.increaseMoveCounter();
                        }
                    }
                }
            }
        }

        if (_state && ren.material.color == Color.black)
        {
            ren.material.color = Color.white;
        }
        else if (!_state && ren.material.color == Color.white)
        {
            ren.material.color = Color.black;
        }
    }

    public void stateToggle()
    {
        if (_state) _state = false;
        else _state = true;
    }

    public bool getState() { return _state; }

    public void finishLevel() { isGameFinished = true; }
}
