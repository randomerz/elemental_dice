using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvUI : MonoBehaviour
{
    private int curDiceTraySize;
    private int curDicePouchSize;

    [Header("References")]
    public PlayerInventory pInv;
    public DiceDragDrop[] diceTraySlots = new DiceDragDrop[8];
    public DiceDragDrop[] dicePouchSlots = new DiceDragDrop[16];

    public bool CanAddDice()
    {
        if (curDiceTraySize < pInv.inventorySize || curDicePouchSize < pInv.inventorySize * 2)
            return true;
        return false;
    }

    public void AddDice(DiceDragDrop diceDragDrop)
    {
        for (int i = 0; i < pInv.inventorySize; i++)
        {
            if (diceTraySlots[i] == null)
            {
                diceTraySlots[i] = diceDragDrop;
                return;
            }
        }

        for (int i = 0; i < pInv.inventorySize * 2; i++)
        {
            if (dicePouchSlots[i] == null)
            {
                dicePouchSlots[i] = diceDragDrop;
                return;
            }
        }
    }

    public void SetDiceTray(DiceDragDrop diceDragDrop, int index)
    {
        diceTraySlots[index] = diceDragDrop;
    }

    public void SetDicePouch(DiceDragDrop diceDragDrop, int index)
    {
        dicePouchSlots[index] = diceDragDrop;
    }
}
