using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConsts : MonoBehaviour
{
    public BattleInventory playerDiceInventory;

    private static PlayerConsts _instance;

    void Awake()
    {
        if (_instance == null)
            Initialize();
    }

    public void Initialize()
    {
        _instance = this;
    }

    public static BattleInventory GetPlayerInventory()
    {
        return _instance.playerDiceInventory;
    }
}
