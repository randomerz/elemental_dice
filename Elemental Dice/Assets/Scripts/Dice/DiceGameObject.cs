using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceGameObject : MonoBehaviour
{
    public int initDiceNumberType = 6;
    public TraitName[] initDiceTraits = { TraitName.Base };

    private Dice myDice;

    // TODO move
    public SpriteRenderer spriteRenderer;
    public Sprite[] d6Sprites;

    void Awake()
    {
        // temporarily here, TODO make a dice factory
        myDice = new Dice(initDiceNumberType, initDiceTraits, this);
        PlayerConsts.GetPlayerInventory().AddBattleDice(myDice);
    }
    
    void Update()
    {
        
    }

    public void RollSprite()
    {
        spriteRenderer.sprite = d6Sprites[myDice.GetRawValue() - 1];
    }
}
