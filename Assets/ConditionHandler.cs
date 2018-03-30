using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionHandler : MonoBehaviour
{

    public List<GameObject> conditions = new List<GameObject>();
    private ModifierDrawCard modifierDrawCard;

    private void Start()
    {
        modifierDrawCard = GameObject.FindGameObjectWithTag("Combat Modifier").GetComponent<ModifierDrawCard>();
    }

    public void ConditionUpdate()
    {
        if (gameObject.transform.GetChild(4).GetComponent<Toggle>().isOn == true)
        {
            foreach (GameObject condition in conditions)
            {
                if (condition.name == "Poisoned")
                {
                    //POISON – If a figure is poisoned, all enemies add +1 Attack to all of their attacks targeting the figure. If a Heal ability is used on a poisoned figure, the POISON token is removed, and the Heal has no other effect.
                    //Add modifier to ActivateCalcPop.cs
                }
                if (condition.name == "Muddled")
                {
                    //MUDDLE – If a figure is muddled, it gains Disadvantage on all of its attacks. At the end of its next turn, the MUDDLE token is removed.
                    modifierDrawCard.drawTwo = true;
                    //condition.SetActive(false);

                }
                if (condition.name == "Wounded")
                {
                    //WOUND – If a figure is wounded, it suffers one point of damage at the start of each of its turns. If a Heal ability is used on a wounded figure, the WOUND token is removed and the Heal continues normally. If a figure is both poisoned and wounded, a Heal ability would remove both conditions but have no other effect.

                }
                if (condition.name == "Dazed")
                {
                    //STUN – If a figure is stunned, it cannot perform any abilities or use items on its turn except to perform a long rest(in the case of characters). At the end of its next turn, the STUN token is removed.

                }
                if (condition.name == "Crippled")
                {
                    //IMMOBILIZE – If a figure is immobilized, it cannot perform any move abilities on its turn. At the end of its next turn, the IMMOBILIZE token is removed.

                }
                if (condition.name == "Disarmed")
                {
                    //DISARM – If a figure is disarmed, it cannot perform any attack abilities on its turn. At the end of its next turn, the DISARM token is removed.

                }
                if (condition.name == "Cursed")
                {
                    //CURSE – If a figure is cursed, it must shuffle a CURSE card into its remaining attack modifier deck.When this card is revealed through one of the figure’s attacks, it is removed from the deck instead of being placed into the attack modifier discard pile. A maximum of 10 curse cards can be placed into the modifier deck.

                }
                if (condition.name == "Blessed")
                {
                    //BLESS - See Curse.

                }
                if (condition.name == "Strengthend")
                {
                    //STRENGTHEN – If a figure is strengthened, it gains Advantage on all of its attacks. At the end of its next turn, the STRENGTHEN token is removed.
                    modifierDrawCard.drawTwo = true;
                    //condition.SetActive(false);
                }
                if (condition.name == "Invisible")
                {
                    //INVISIBLE – If a figure is invisible, it cannot be focused on or targeted by an enemy. At the end of its next turn, the INVISIBLE token is removed.

                }
            }
        }
    }

}
