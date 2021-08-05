using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiceItemSlot : ItemSlot
{
    public int slotId = -1;

    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
    }
}
