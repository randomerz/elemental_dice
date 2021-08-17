using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiceItemSlot : ItemSlot
{
    public int slotId = -1;

    public Image image;

    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DiceDragDrop ddDice = eventData.pointerDrag.GetComponent<DiceDragDrop>();
            if (ddDice != null)
            {
                if (PlayerInvUI.DropDice(ddDice, slotId))
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().position =
                        GetComponent<RectTransform>().position;
                }
                else
                {
                    PlayerInvUI.ResetDice(ddDice);
                }
            }

        }
    }

    public void SetColor(Color c)
    {
        image.color = c;
    }
}
