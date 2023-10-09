using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject controlsMenu;

    //Get buttons to change text according to the key bound to the controls

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        controlsMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }
}
