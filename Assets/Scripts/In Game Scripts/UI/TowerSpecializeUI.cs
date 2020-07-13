using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TDLWRP.TOWER;
using TDLWRP.GAME;

namespace TDLWRP.UI.HUD
{
    public class TowerSpecializeUI : MonoBehaviour
    {
        /// <summary>
        /// The text component for the
        /// </summary>
        public Text Specialize1;

        /// <summary>
        /// The text component for the
        /// </summary>
        public Text Specialize2;

        /// <summary>
        /// The text component for the
        /// </summary>
        public Text SellPrice;

        [SerializeField]
        private GameUI my_gameUI;

        [SerializeField]
        Button special1Button, special2Button;

        Tower my_tower;
        GameController my_gameController;
        bool isSelectedTower;

        CurrencyController my_currencyController;

        private void Start()
        {
            my_gameController = FindObjectOfType<GameController>();
            my_currencyController = FindObjectOfType<CurrencyController>();
        }

        private void Update()
        {
            if (my_gameUI.currentSelectedTower != null)
            {
                Show();
                DisableButtons();
            }

        }

        public void Show()
        {
            this.gameObject.SetActive(true);
            my_tower = my_gameUI.currentSelectedTower.GetComponent<Tower>();
            int levelOfTower = my_tower.currentLevel;
            Show(my_tower, levelOfTower);
        }

        public void Hide()
        {
            my_gameUI.radiusVisualizer.Hide();
            this.gameObject.SetActive(false);
        }

        public void Show(Tower tower, int levelOfTower)
        {
            DisplayText(Specialize1, string.Format("{0}", my_tower.my_levelData.special1Cost));
            DisplayText(Specialize2, string.Format("{0}", my_tower.my_levelData.special2Cost));
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

        public void Special1Click()
        {
            if (my_gameController.GetCurrency() > 0)
            {
                if (isSelectedTower)
                {
                    //özel upgrade 1
                    //model değiştir
                }
                else
                {
                    //my_tower.setLevel(1);
                    my_tower.specializeCount = 0;
                    isSelectedTower = true;
                }

                Hide();
            }
        }

        public void Special2Click()
        {
            if (my_gameController.GetCurrency() > 0)
            {
                if (isSelectedTower)
                {
                    //özel upgrade 2
                    //model değiştir
                }
                else
                {
                    //my_tower.setLevel(2);
                    my_tower.specializeCount = 0;
                    isSelectedTower = true;
                }

                Hide();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SellButtonClick()
        {
            my_tower.gameObject.GetComponentInParent<TowerPlaces>().ActivateMe();
            my_currencyController.ChangeCurrency(my_tower.my_levelData.sellPrice);
            Hide();
            Destroy(my_tower.gameObject);
            my_tower.specializeCount = 0;
        }

        void DisableButtons()
        {
            if (my_gameController.GetCurrency() < my_tower.my_levelData.special1Cost)
            {
                special1Button.enabled = false;
            }
            else
            {
                special1Button.enabled = true;
            }
            if (my_gameController.GetCurrency() < my_tower.my_levelData.special2Cost)
            {
                special2Button.enabled = false;
            }
            else
            {
                special2Button.enabled = true;
            }
        }
    }
}