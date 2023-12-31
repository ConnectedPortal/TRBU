using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Input System")]
    private PlayerControls playerControls;

    [Header("UI")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject controlsMenu;
    private GameManager gameManager;

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

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (playerControls.Gameplay.Menu.triggered)
        {
            if (!gameManager.isPaused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                gameManager.isPaused = true;
            }
            else if (!controlsMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                gameManager.isPaused = false;
            }
        }
    }

    public void ControlsMenu()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }
}
