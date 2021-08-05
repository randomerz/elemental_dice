using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public BattleInventory battleInventory;

    // Start is called before the first frame update
    void Start()
    {
        //battleInventory.ResetFightDice();
        battleInventory.PrintInventoryTraits();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRoll()
    {
        List<Dice> diceToRoll = battleInventory.GetNewRoundDice();
        Debug.Log("Rolling " + diceToRoll.Count + " dice...");

        foreach (Dice dice in diceToRoll)
        {
            dice.RollRawValue();
            dice.GetDiceGameObject().RollSprite();
        }

        DiceTraitApplier.ApplyOnRollTraits(diceToRoll, battleInventory);
    }

    public void StartAttack()
    {
        List<Dice> diceToSum = battleInventory.GetCurrentRoundDice();

        DiceTraitApplier.ApplyOnAttackTraits(diceToSum, battleInventory);

        int attackSum = 0;
        foreach (Dice dice in diceToSum)
        {
            attackSum += dice.GetAttackValue();
        }

        Debug.Log("Bam! Did " + attackSum + " damage!");
    }
}
