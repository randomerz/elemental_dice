using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiceDragDrop : DragDrop
{
    public GameObject diceGO;
    public Dice dice;

    public int inventoryIndex = -1;

    public override void Awake()
    {
        base.Awake();
        if (diceGO != null)
        {
            dice = diceGO.GetComponent<Dice>();
        }
    }

    public void SetDice(Dice dice)
    {
        this.dice = dice;
        diceGO = dice.gameObject;
    }

    public void SetDiceGO(GameObject diceGO)
    {
        this.diceGO = diceGO;
        dice = diceGO.GetComponent<Dice>();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        PlayerInvUI.BeginDrag(this);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        PlayerInvUI.EndDrag(this);
    }
}
