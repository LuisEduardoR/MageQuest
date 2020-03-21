using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MageQuest.Entities;

namespace MageQuest.Player
{

    public class PlayerUI : MonoBehaviour
    {

        public Image healthPoolGraphic;
        public Image manaPoolGraphic;

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

    }

}
