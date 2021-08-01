using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrait : DiceTrait
{
    public override void ProcessTraitOnAttack(List<Dice> dice, int numTribe)
    {
        base.ProcessTraitOnAttack(dice, numTribe);

        // set damage bonus
        int bonus = 0;

        if (numTribe >= 20)
        {
            bonus = 6;
        }
        else if (numTribe >= 12)
        {
            bonus = 4;
        }
        else if (numTribe >= 9)
        {
            bonus = 3;
        }
        else if (numTribe >= 6)
        {
            bonus = 2;
        }
        else if (numTribe >= 3)
        {
            bonus = 1;
        }

        // apply to Fire dice
        foreach (Dice d in dice)
        {
            if (d.HasTrait(traitName))
            {
                d.AddAttackBonus(bonus);
            }
        }
    }
}
