using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TDLWRP.TOWER;
using TDLWRP.GAME;
using UnityEngine.EventSystems;

namespace TDLWRP.UI.HUD
{
    public class TowerUI : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        public TowerInfoDisplay towerInfoDisplay;

        /// <summary>
        /// The main game camera
        /// </summary>
        protected Camera my_Camera;

        GameController my_gameController;
        CurrencyController my_currencyController;

        [SerializeField]
        private GameUI my_gameUI;

        [SerializeField]
        Button rangeButton, damageButton, speedButton;

        /// <summary>
        /// 
        /// </summary>
        public TowerSpecializeUI towerSpecializeUI;

        public Tower my_tower;

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Start()
        {
            my_Camera = Camera.main;
            my_gameController = FindObjectOfType<GameController>();
            my_currencyController = FindObjectOfType<CurrencyController>();
        }

        private void Update()
        {
            if (my_gameUI.currentSelectedTower != null)
            {
                my_tower = my_gameUI.currentSelectedTower.GetComponent<Tower>();
                DisableButtons();
            }
        }

        /// <summary>
        /// Draws the tower data on to the canvas
        /// </summary>
        /// <param name="towerToShow">
        /// The tower to gain info from
        /// </param>
        public virtual void Show(Tower towerToShow)
        {
            towerInfoDisplay.Show(towerToShow);
            this.gameObject.SetActive(true);
        }

        /// <summary>
        /// Hides the tower info UI 
        /// </summary>
        public virtual void Hide()
        {
            my_gameUI.radiusVisualizer.Hide();
            gameObject.SetActive(false);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RangeButtonClick()
        {
            if (my_gameController.GetCurrency() > 0)
            {
                my_tower.towerRange += 10;
                my_currencyController.ChangeCurrency(-(my_tower.my_levelData.generalCost));
                my_tower.specializeCount++;
                Hide(); 
            }
        }
         
        /// <summary>
        /// 
        /// </summary>
        public void DamageButtonClick()
        {
            if (my_gameController.GetCurrency() > 0)
            {
                my_tower.towerDamage += 10;
                my_currencyController.ChangeCurrency(-(my_tower.my_levelData.generalCost));
                my_tower.specializeCount++;
                Hide(); 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SpeedButtonClick()
        {
            if (my_gameController.GetCurrency() > 0)
            {
                my_tower.towerSpeed += 10;
                my_currencyController.ChangeCurrency(-(my_tower.my_levelData.generalCost));
                my_tower.specializeCount++;
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
        }

        void DisableButtons()
        {
            if(my_gameController.GetCurrency() < my_tower.my_levelData.generalCost)
            {
                rangeButton.enabled = false;
                damageButton.enabled = false;
                speedButton.enabled = false;
            }
            else
            {
                rangeButton.enabled = true;
                damageButton.enabled = true;
                speedButton.enabled = true;
            }
        }
    }
}