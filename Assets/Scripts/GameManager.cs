using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isInCutscene = false;
    public bool focusOnObject = false;
    public GameObject objectTarget = null;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (!isInCutscene) objectTarget = null;
    }
}
