using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DiceTrait : MonoBehaviour
{
    public TraitName traitName;
    public int[] traitActivationReqs;

    // Generally affect dice's raw values
    public virtual void ProcessTraitOnRoll(List<Dice> dice, int numTribe)
    {
        if (CheckMinActivationReq(numTribe))
            return;
    }

    // Generally affects dice's bonuses
    public virtual void ProcessTraitOnAttack(List<Dice> dice, int numTribe)
    {
        if (CheckMinActivationReq(numTribe))
            return;
    }

    private bool CheckMinActivationReq(int numTribe)
    {
        // returns false if number of TRAIT dice are less than first activation
        return !(traitActivationReqs == null || numTribe < traitActivationReqs[0]);
    }
}
