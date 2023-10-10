using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    [Header("Input System")]
    private PlayerControls playerControls;

    [Header("UI")]
    private GameManager gameManager;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject controlsMenu;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    //Get buttons to change text according to the key bound to the controls

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        controlsMenu.SetActive(false);
    }

    private void Update()
    {
        if (playerControls.Gameplay.Menu.triggered)
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
