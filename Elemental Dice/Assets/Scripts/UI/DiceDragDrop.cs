using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDragDrop : DragDrop
{
    public GameObject diceGO;
    public Dice dice;

    private void Awake()
    {
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
}
