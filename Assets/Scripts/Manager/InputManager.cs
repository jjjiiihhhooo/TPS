using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    [SerializeField] private KeyCode swapKey;
    [SerializeField] private KeyCode dashKey;

    private void Update()
    {
        if(Input.GetKeyDown(swapKey))
        {
            Player.Instance.ToggleWeapon();
        }

        if(Input.GetKeyDown(dashKey))
        {
            Player.Instance.DashInput();
        }

        if(Input.GetMouseButtonDown(0))
        {

        }
    }

}
