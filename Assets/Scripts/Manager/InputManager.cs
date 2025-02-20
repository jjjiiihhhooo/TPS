using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    [SerializeField] private KeyCode swapKey;

    private void Update()
    {
        if(Input.GetKeyDown(swapKey))
        {
            Player.Instance.ToggleWeapon();
        }
    }

}
