using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MageQuest.Spells;
using MageQuest.Entities;

namespace MageQuest.Player
{

    public class PlayerUI : MonoBehaviour
    {

        [SerializeField] protected Image healthPoolGraphic;
        [SerializeField] protected Image manaPoolGraphic;

        [SerializeField] protected Slider castingBarLeft;
        [SerializeField] protected Image castingBarFillLeft;
        [SerializeField] protected Image longCastMarkerLeft;

        [SerializeField] protected Slider castingBarRight;
        [SerializeField] protected Image castingBarFillRight;
        [SerializeField] protected Image longCastMarkerRight;

        [SerializeField] protected Image[] spellActiveIcons;

        private BaseSpell currentSpell;

        private void Update()
        {

            // Paint the spell bar the correct color.
            if(currentSpell != null)
            {
                castingBarLeft.value = currentSpell.castChargeTime;
                castingBarRight.value = currentSpell.castChargeTime;

                if(!currentSpell.inCooldown)
                {
                    if(currentSpell.castChargeTime < currentSpell.delayShortCast)
                    {
                        castingBarFillLeft.color = Color.blue;
                        castingBarFillRight.color = Color.blue;
                    }
                    else
                    {
                        castingBarFillLeft.color = Color.red;
                        castingBarFillRight.color = Color.red;
                    }
                }
                else
                {
                    castingBarFillLeft.color = Color.gray;
                    castingBarFillRight.color = Color.gray;
                }


            }

        }

        public void UpdateUIStats(int health, int maxHealth, int mana, int maxMana)
        {

            Vector2 t_anchor;

            // Calculates where to place the health graphic.
            t_anchor = healthPoolGraphic.rectTransform.anchoredPosition;
            t_anchor.y = -healthPoolGraphic.rectTransform.rect.height * (1.0f - ((float)health / (float)maxHealth));
            healthPoolGraphic.rectTransform.anchoredPosition = t_anchor;

            // Calculates where to place the mana graphic.
            t_anchor = manaPoolGraphic.rectTransform.anchoredPosition;
            t_anchor.y = -manaPoolGraphic.rectTransform.rect.height * (1.0f - ((float)mana / (float)maxMana));
            manaPoolGraphic.rectTransform.anchoredPosition = t_anchor;

        }

        public void UpdateAvaliableSpell(PlayerSpell[] spells)
        {

            for(int i = 0; i < spells.Length; i++)
                spellActiveIcons[i].enabled = spells[i].spellEnabled;

        }

        public void UpdateCastingBar(BaseSpell spell)
        {

            // Saves the current spell.
            currentSpell = spell;

            // Gets the max value for the bar
            castingBarLeft.maxValue = spell.delayLongCast;
            castingBarRight.maxValue = spell.delayLongCast;

            // Sets the long cast marker on the bars.
            Vector2 t_pos = longCastMarkerLeft.rectTransform.anchoredPosition;
            t_pos.x = -castingBarLeft.GetComponent<RectTransform>().rect.width * (spell.delayShortCast / spell.delayLongCast);
            longCastMarkerLeft.rectTransform.anchoredPosition = t_pos;

            t_pos = longCastMarkerRight.rectTransform.anchoredPosition;
            t_pos.x = castingBarRight.GetComponent<RectTransform>().rect.width * (spell.delayShortCast / spell.delayLongCast);
            longCastMarkerRight.rectTransform.anchoredPosition = t_pos;

        }

    }

}
