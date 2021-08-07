using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvUI : MonoBehaviour
{
    private int curDiceTraySize;
    private int curDicePouchSize;

    private bool didInit = false;
    private static PlayerInvUI _instance;

    [Header("References")]
    public PlayerInventory pInv;
    public DiceDragDrop[] diceTraySlots = new DiceDragDrop[8];
    public DiceDragDrop[] dicePouchSlots = new DiceDragDrop[16];

    private void Awake()
    {
        if (!didInit)
        {
            Initialize();
        }
    }

    public void Initialize()
    {
        didInit = true;

        _instance = this;
    }

    public static bool CanAddDice()
    {
        return _instance._CanAddDice();
    }

    private bool _CanAddDice()
    {
        if (curDiceTraySize < pInv.inventorySize || curDicePouchSize < pInv.inventorySize * 2)
            return true;
        return false;
    }

    private bool _CanSetDice(int index)
    {
        if (index < 0)
        {
            return false;
        }
        else if (index < 8)
        {
            if (index < pInv.inventorySize)
                return true;
            return false;
        }
        else if (index < 24)
        {
            index -= 8;
            if (index < pInv.inventorySize * 2)
                return true;
            return false;
        }

        Debug.LogWarning("Error in inventory sizing");
        return false;
    }

    public static void AddDice(DiceDragDrop ddDice)
    {
        _instance._AddDice(ddDice);
    }

    // try to add to pouch first, then to tray
    private void _AddDice(DiceDragDrop ddDice)
    {
        for (int i = 0; i < pInv.inventorySize * 2; i++)
        {
            if (dicePouchSlots[i] == null)
            {
                SetDice(ddDice, i + 8);
                return;
            }
        }

        for (int i = 0; i < pInv.inventorySize; i++)
        {
            if (diceTraySlots[i] == null)
            {
                SetDice(ddDice, i);
                return;
            }
        }
    }

    public static void DropDice(DiceDragDrop awayDDDice, DiceDragDrop homeDDDice, int index)
    {
        _instance._DropDice(awayDDDice, homeDDDice, index);
    }

    private void _DropDice(DiceDragDrop awayDDDice, DiceDragDrop homeDDDice, int index)
    {
        if (awayDDDice == null)
        {
            Debug.LogError("Can't drop null into dice spot!");
            return;
        }

        if (!_CanSetDice(index))
        {
            return;
        }

        if (awayDDDice.inventoryIndex == -1)
        {

        }
        SetDice(homeDDDice, awayDDDice.inventoryIndex);
        SetDice(awayDDDice, index);
    }



    public static void SetDice(DiceDragDrop ddDice, int index)
    {
        if (index < 8)
        {
            ddDice.inventoryIndex = index;

            _instance.diceTraySlots[index] = ddDice;
        }
        else
        {
            ddDice.inventoryIndex = index;

            index -= 8;
            _instance.dicePouchSlots[index] = ddDice;
        }
    }
}
