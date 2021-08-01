using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public DiceInventory diceInventory;

    // Start is called before the first frame update
    void Start()
    {
        diceInventory.ResetFightDice();
        diceInventory.PrintInventoryTraits();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRoll()
    {
        List<Dice> diceToRoll = diceInventory.GetNewRoundDice();
        Debug.Log("Rolling " + diceToRoll.Count + " dice...");

        foreach (Dice dice in diceToRoll)
        {
            dice.RollRawValue();
            dice.GetDiceGameObject().RollSprite();
        }

        DiceTraitApplier.ApplyOnRollTraits(diceToRoll, diceInventory);
    }

    public void StartAttack()
    {
        List<Dice> diceToSum = diceInventory.GetCurrentRoundDice();

        DiceTraitApplier.ApplyOnAttackTraits(diceToSum, diceInventory);

        int attackSum = 0;
        foreach (Dice dice in diceToSum)
        {
            attackSum += dice.GetAttackValue();
        }

        Debug.Log("Bam! Did " + attackSum + " damage!");
    }
}
