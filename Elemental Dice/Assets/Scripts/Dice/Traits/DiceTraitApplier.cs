using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTraitApplier : MonoBehaviour
{
    private static DiceTraitApplier _instance;
    
    public DiceTrait[] diceTraits;

    private void Awake()
    {
        _instance = this;
    }

    public static void ApplyOnRollTraits(List<Dice> dice, BattleInventory diceInventory)
    {
        foreach (DiceTrait trait in _instance.diceTraits)
        {
            trait.ProcessTraitOnRoll(dice, diceInventory.GetBattleTraitCount(trait.traitName));
        }
    }

    public static void ApplyOnAttackTraits(List<Dice> dice, BattleInventory diceInventory)
    {
        foreach (DiceTrait trait in _instance.diceTraits)
        {
            trait.ProcessTraitOnAttack(dice, diceInventory.GetBattleTraitCount(trait.traitName));
        }
    }
}
