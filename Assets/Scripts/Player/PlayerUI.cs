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

        [SerializeField] protected Slider spellBarLeft;
        [SerializeField] protected Image spellbarFillLeft;
        [SerializeField] protected Image longCastMarkerLeft;

        [SerializeField] protected Slider spellBarRight;
        [SerializeField] protected Image spellbarFillRight;
        [SerializeField] protected Image longCastMarkerRight;

        private BaseSpell currentSpell;

        private void Update()
        {

            // Paint the spell bar the correct color.
            if(currentSpell != null)
            {
                spellBarLeft.value = currentSpell.castChargeTime;
                spellBarRight.value = currentSpell.castChargeTime;

                if(!currentSpell.inCooldown)
                {
                    if(currentSpell.castChargeTime < currentSpell.delayShortCast)
                    {
                        spellbarFillLeft.color = Color.blue;
                        spellbarFillRight.color = Color.blue;
                    }
                    else
                    {
                        spellbarFillLeft.color = Color.red;
                        spellbarFillRight.color = Color.red;
                    }
                }
                else
                {
                    spellbarFillLeft.color = Color.gray;
                    spellbarFillRight.color = Color.gray;
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

        public void InitializeSpellBar(BaseSpell spell)
        {

            // Saves the current spell.
            currentSpell = spell;

            // Gets the max value for the bar
            spellBarLeft.maxValue = spell.delayLongCast;
            spellBarRight.maxValue = spell.delayLongCast;

            // Sets the long cast marker on the bars.
            Vector2 t_pos = longCastMarkerLeft.rectTransform.anchoredPosition;
            t_pos.x -= spellBarLeft.GetComponent<RectTransform>().rect.width * (spell.delayShortCast / spell.delayLongCast);
            longCastMarkerLeft.rectTransform.anchoredPosition = t_pos;

            t_pos = longCastMarkerRight.rectTransform.anchoredPosition;
            t_pos.x += spellBarRight.GetComponent<RectTransform>().rect.width * (spell.delayShortCast / spell.delayLongCast);
            longCastMarkerRight.rectTransform.anchoredPosition = t_pos;

        }

    }

}
