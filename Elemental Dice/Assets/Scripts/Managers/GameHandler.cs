using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public PlayerConsts playerConsts;

    void Awake()
    {
        InitGame();
    }
    
    private void InitGame()
    {
        playerConsts.Initialize();
    }
}
