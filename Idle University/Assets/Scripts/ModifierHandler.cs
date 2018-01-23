using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifierHandler : MonoBehaviour {

    private float sOutPrice = 1;
    private float sOutModifier = 2;
    public Text sOutText;

	public void SchoolsOut()
    {
        if (Stats.money >= sOutPrice)
        {
            Stats.extraStudentsPerSecondChance+=2;
            Stats.money -= sOutPrice;
            sOutPrice *= sOutModifier;
            sOutModifier *= 1.1f;
            sOutText.text = "£"+sOutPrice;
        }
    }

}
