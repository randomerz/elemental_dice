using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvUI : MonoBehaviour
{


    [Header("References")]
    public PlayerInventory pInv;
    public ItemSlot[] diceTraySlots = new ItemSlot[8];
    public ItemSlot[] dicePouchSlots = new ItemSlot[16];
}
