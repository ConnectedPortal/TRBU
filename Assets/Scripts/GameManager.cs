using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isInCutscene = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
