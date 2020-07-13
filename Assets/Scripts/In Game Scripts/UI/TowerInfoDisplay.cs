using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TDLWRP.TOWER;
using TDLWRP.GAME;

namespace TDLWRP.UI.HUD
{
    public class TowerInfoDisplay : MonoBehaviour
    {
        /// <summary>
        /// The text component for the
        /// </summary>
        public Text rangeCost;

        /// <summary>
        /// The text component for the
        /// </summary>
        public Text DamageCost;

        /// <summary>
        /// The text component for the
        /// </summary>
        public Text SpeedCost;

        /// <summary>
        /// The text component for the
        /// </summary>
        public Text SellPrice;

        Tower my_tower;

        [SerializeField]
        GameUI my_gameUI;

        /*private void Update()
        {
            if (my_gameUI.currentSelectedTower != null)
            {
                my_tower = my_gameUI.currentSelectedTower.GetComponent<Tower>();
                Show(my_tower);
            }
        }*/

        /// <summary>
        /// Draws the tower data on to the canvas, if the relevant text components are populated
        /// </summary>
        /// <param name="tower">
        /// The tower to gain info from
        /// </param>
        public void Show(Tower tower)
        {
            ////////
            my_tower = my_gameUI.currentSelectedTower.GetComponent<Tower>();
            int levelOfTower = my_tower.currentLevel;
            Show(tower, levelOfTower);
        }

        /// <summary>
        /// Draws the tower data on to the canvas, if the relevant text components are populated
        /// </summary>
        /// <param name="tower">The tower to gain info from</param>
        /// <param name="levelOfTower">The level of the tower</param>
        public void Show(Tower tower, int levelOfTower)
        {
            DisplayText(rangeCost, string.Format("{0}", my_tower.my_levelData.generalCost));
            DisplayText(DamageCost, string.Format("{0}", my_tower.my_levelData.generalCost));
            DisplayText(SpeedCost, string.Format("{0}", my_tower.my_levelData.generalCost));
            DisplayText(SellPrice, string.Format("{0}", my_tower.my_levelData.sellPrice));
        }

        /// <summary>
        /// Draws the text if the text component is populated
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="text"></param>
        static void DisplayText(Text textBox, string text)
        {
            if (textBox != null)
            {
                textBox.text = text;
            }
        }
    }
}