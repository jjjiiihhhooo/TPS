using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private bool isMouse = true;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            MouseToggle();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void MouseToggle()
    {
        isMouse = !isMouse;

        if (isMouse) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = isMouse;
    }
}
