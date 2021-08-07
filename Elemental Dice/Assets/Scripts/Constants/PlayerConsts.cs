using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConsts : MonoBehaviour
{
    public BattleInventory playerDiceInventory;

    public PlayerInvUI UIPlayerInv;

    private static PlayerConsts _instance;

    void Awake()
    {
        if (_instance == null)
            Initialize();
    }

    public void Initialize()
    {
        _instance = this;

        if (UIPlayerInv != null)
        {
            UIPlayerInv.Initialize();
        }
    }

    public static BattleInventory GetPlayerInventory()
    {
        return _instance.playerDiceInventory;
    }
}
