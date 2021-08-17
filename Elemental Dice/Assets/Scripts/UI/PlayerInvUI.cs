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

    private static DiceDragDrop draggedDice;

    private static DiceDragDrop[] ddDiceTrays = new DiceDragDrop[8];
    private static DiceDragDrop[] ddDicePouches = new DiceDragDrop[16];

    [Header("References")]
    public PlayerInventory pInv;

    public DiceItemSlot[] diceItemTraySlots;
    public DiceItemSlot[] diceItemPouchSlots;

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

        UpdateSizeDisplay();
    }

    #region Dice

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
            if (ddDicePouches[i] == null)
            {
                SetDice(ddDice, i + 8);
                return;
            }
        }

        for (int i = 0; i < pInv.inventorySize; i++)
        {
            if (ddDiceTrays[i] == null)
            {
                SetDice(ddDice, i);
                return;
            }
        }
    }

    public static void BeginDrag(DiceDragDrop ddDice)
    {
        draggedDice = ddDice;
    }

    public static void EndDrag(DiceDragDrop ddDice)
    {
        if (draggedDice != null)
        {
            ResetDice(draggedDice);
            draggedDice = null;
        }
    }

    public static bool DropDice(DiceDragDrop awayDDDice, int index)
    {
        return _instance._DropDice(awayDDDice, index);
    }

    private bool _DropDice(DiceDragDrop awayDDDice, int index)
    {
        if (awayDDDice == null)
        {
            Debug.LogError("Can't drop null into dice spot!");
            return false;
        }

        Debug.Log("trying to set " + index + " to " + awayDDDice);
        if (!_CanSetDice(index))
        {
            return false;
        }

        if (awayDDDice.inventoryIndex != -1)
        {
            if (index < 8)
            {
                SetDice(ddDiceTrays[index], awayDDDice.inventoryIndex);
            }
            else
            {
                SetDice(ddDicePouches[index - 8], awayDDDice.inventoryIndex);
            }
        }
        SetDice(awayDDDice, index);

        draggedDice = null;

        return true;
    }



    public static void SetDice(DiceDragDrop ddDice, int index)
    {
        if (ddDice == null)
        {
            if (index < 8)
            {
                ddDiceTrays[index] = ddDice;
            }
            else
            {
                ddDicePouches[index - 8] = ddDice;
            }
        }
        else
        {
            if (index < 8)
            {
                ddDice.inventoryIndex = index;

                ddDiceTrays[index] = ddDice;
                ddDice.GetComponent<RectTransform>().position =
                    _instance.diceItemTraySlots[index].GetComponent<RectTransform>().position;
            }
            else
            {
                ddDice.inventoryIndex = index;

                index -= 8;
                ddDicePouches[index] = ddDice;
                ddDice.GetComponent<RectTransform>().position =
                    _instance.diceItemPouchSlots[index].GetComponent<RectTransform>().position;
            }
        }
    }

    public static void ResetDice(DiceDragDrop ddDice)
    {
        Debug.Log("reseting " + ddDice + (ddDice == null));
        if (!_instance._CanSetDice(ddDice.inventoryIndex))
        {
            Debug.LogError("Dice index is not valid!");
        }
        else
        {
            SetDice(ddDice, ddDice.inventoryIndex);
        }
    }

    #endregion

    public static void UpdateSizeDisplay()
    {
        for (int i = 0; i < _instance.pInv.inventorySize; i++)
        {
            _instance.diceItemTraySlots[i].SetColor(Color.white);
            _instance.diceItemPouchSlots[2 * i].SetColor(Color.white);
            _instance.diceItemPouchSlots[2 * i + 1].SetColor(Color.white);
        }

        for (int i = _instance.pInv.inventorySize; i < _instance.diceItemTraySlots.Length; i++)
        {
            _instance.diceItemTraySlots[i].SetColor(Color.gray);
            _instance.diceItemPouchSlots[2 * i].SetColor(Color.gray);
            _instance.diceItemPouchSlots[2 * i + 1].SetColor(Color.gray);
        }
    }
}
