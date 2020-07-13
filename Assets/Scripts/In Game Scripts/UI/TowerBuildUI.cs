using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TDLWRP.INPUT;
using TDLWRP.TOWER;
using TDLWRP.GAME;

namespace TDLWRP.UI.HUD
{
    public class TowerBuildUI : MonoBehaviour
    {
        /// <summary>
        /// The attached Game UI object
        /// </summary>
        public GameUI my_GameUI;

        public Text text1, text2, text3, text4;

        public InputController my_inputController;
        GameController my_gameController;
        CurrencyController my_currencyController;

        public TowerPlaces activeTowerPlace;

        /// <summary>
        /// GameObject list for avaiable towers
        /// </summary>
        public GameObject Tower1, Tower2, Tower3, Tower4;

        [SerializeField]
        Button button1, button2, button3, button4;

        string buttonName;

        private void Start()
        {
            my_gameController = FindObjectOfType<GameController>();
            my_currencyController = FindObjectOfType<CurrencyController>();
            ShowText();
            DisableButtons();
        }

        /// <summary>
        /// Build fuction for tower.
        /// Attached TowerBuildUI's buttons.
        /// </summary>
        public void BuildTower()
        {
            if (my_gameController.GetCurrency() > 0)
            {
                buttonName = EventSystem.current.currentSelectedGameObject.name;
                Debug.Log("create: " + buttonName);
                switch (buttonName)
                {
                    case "Tower1":
                        my_GameUI.BuyTower(Tower1, my_inputController.buildPosition, new Quaternion(0, 0, 0, 0));
                        my_currencyController.ChangeCurrency(-Tower1.GetComponent<Tower>().buildCost);
                        activeTowerPlace.isOccupied = true;

                        break;
                    case "Tower2":
                        my_GameUI.BuyTower(Tower2, my_inputController.buildPosition, new Quaternion(0, 0, 0, 0));
                        my_currencyController.ChangeCurrency(-Tower2.GetComponent<Tower>().buildCost);
                        activeTowerPlace.isOccupied = true;
                        break;
                    case "Tower3":
                        my_GameUI.BuyTower(Tower3, my_inputController.buildPosition, new Quaternion(0, 0, 0, 0));
                        my_currencyController.ChangeCurrency(-Tower3.GetComponent<Tower>().buildCost);
                        activeTowerPlace.isOccupied = true;
                        break;
                    case "Tower4":
                        my_GameUI.BuyTower(Tower4, my_inputController.buildPosition, new Quaternion(0, 0, 0, 0));
                        my_currencyController.ChangeCurrency(-Tower4.GetComponent<Tower>().buildCost);
                        activeTowerPlace.isOccupied = true;
                        break;
                    default:
                        break;
                }
                this.gameObject.SetActive(false);
            }
        }

        void ShowText()
        {
            text1.text = string.Format("{0}", Tower1.GetComponent<Tower>().buildCost);
            // açılacak
            /*text2.text = string.Format("{0}", Tower2.GetComponent<tower>().buildCost);
            text3.text = string.Format("{0}", Tower3.GetComponent<tower>().buildCost);
            text4.text = string.Format("{0}", Tower4.GetComponent<tower>().buildCost);*/
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        void DisableButtons()
        {
            if (my_gameController.GetCurrency() < Tower1.GetComponent<Tower>().buildCost)
            {
                button1.enabled = false;
            }
            else
            {
                button1.enabled = true;
            }
            // açılacak
            /*if (gameControl.getCurrency() < Tower2.GetComponent<tower>().buildCost)
            {
                button2.enabled = false;
            }
            else
            {
                button2.enabled = true;
            }
            if (gameControl.getCurrency() < Tower3.GetComponent<tower>().buildCost)
            {
                button3.enabled = false;
            }
            else
            {
                button3.enabled = true;
            }
            if (gameControl.getCurrency() < Tower4.GetComponent<tower>().buildCost)
            {
                button4.enabled = false;
            }
            else
            {
                button4.enabled = true;
            }*/
        }
    }
}