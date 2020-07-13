using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.TOWER;
using UnityEngine.UI;
using TDLWRP.GAME;

namespace TDLWRP.UI.HUD
{
    public class GameUI : MonoBehaviour
    {
        /// <summary>
        /// The states the UI can be in
        /// </summary>
        public enum State
        {
            /// <summary>
            /// The game is in its normal state. Here the player can pan the camera, select units and towers
            /// </summary>
            Normal,

            /// <summary>
            /// The game is Paused. Here, the player can restart the level, or quit to the main menu
            /// </summary>
            Paused,

            /// <summary>
            /// The game is over and the level was failed/completed
            /// </summary>
            GameOver,

            /// <summary>
            /// 
            /// </summary>
            SpecialPower
        }

        /// <summary>
        /// Gets the current UI state
        /// </summary>
        public State state { get; private set; }

        /// <summary>
        /// The UI controller for displaying individual tower data
        /// </summary>
        public TowerUI towerUI;

        /// <summary>
        /// The UI controller for building tower
        /// </summary>
        public TowerBuildUI towerbuildUI;

        /// <summary>
        /// The UI controller for specialize tower
        /// </summary>
        public TowerSpecializeUI towerSpecializeUI;

        /// <summary>
        /// Radius visualizer for towers
        /// </summary>
        public RadiusVisualizer radiusVisualizer;

        /// <summary>
        /// Our cached camera reference
        /// </summary>
        Camera my_Camera;

        /// <summary>
        /// Gets the current selected tower
        /// </summary>
        public GameObject currentSelectedTower { get; private set; }

        /// <summary>
        ///  Gets the current selected GameObject
        /// </summary>
        public GameObject currentGameObject;

        /// <summary>
        /// Our game controller reference
        /// </summary>
        GameController my_gameController;

        public int lives { get; private set; }

        public Text finalText;
        public Text livesText;

        private void Start()
        {
            SetState(State.Normal);
            towerUI.gameObject.SetActive(false);
            towerbuildUI.gameObject.SetActive(false);
            towerSpecializeUI.gameObject.SetActive(false);
            radiusVisualizer.Hide();
            lives = 10;
            livesText.text = "Life: " + lives;
            my_gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetState(State.Paused);
                Time.timeScale = 0f;
            }
            if (state == State.Normal)
            {
                if (lives == 0)
                {
                    GameOver();
                    Debug.Log("------------GAME OVER--------------");
                    finalText.text = "GAME OVER";
                    Time.timeScale = 0f;
                }
                if (currentSelectedTower == null)
                {
                    towerbuildUI.gameObject.SetActive(false);
                    towerUI.gameObject.SetActive(false);
                    towerSpecializeUI.gameObject.SetActive(false);
                    radiusVisualizer.Hide();
                }
            }
            else if (state == State.Paused)
            {
                towerbuildUI.gameObject.SetActive(false);
                towerUI.gameObject.SetActive(false);
                towerSpecializeUI.gameObject.SetActive(false);
                radiusVisualizer.Hide();
            }
            else if(state == State.GameOver)
            {

            }
        }

        public void LoseLife(int l)
        {
            lives -= l;
            livesText.text = "live:" + lives;
        }

        /// <summary>
        /// Changes the state and fires <see cref="stateChanged"/>
        /// </summary>
        /// <param name="newState">The state to change to</param>
        /// <exception cref="ArgumentOutOfRangeException">thrown on an invalid state</exception>
        public void SetState(State newState)
        {
            if (state == newState)
            {
                return;
            }
            State oldState = state;
            if (oldState == State.Paused || oldState == State.GameOver)
            {
                Time.timeScale = 1f;
            }

            switch (newState)
            {
                case State.Normal:
                    break;
                case State.Paused:
                    // paused UI açılacak
                    break;
                case State.GameOver:
                    Time.timeScale = 0f;
                    break;
                case State.SpecialPower:
                    // building trap
                    break;
                default:
                    throw new ArgumentOutOfRangeException("newState", newState, null);
            }
            state = newState;
        }

        /// <summary>
        /// Called when the game is over
        /// </summary>
        public void GameOver()
        {
            SetState(State.GameOver);
        }

        /// <summary>
        /// Pause the game and display the pause menu
        /// </summary>
        public void Pause()
        {
            SetState(State.Paused);
        }

        /// <summary>
        /// Resume the game and close the pause menu
        /// </summary>
        public void Unpause()
        {
            SetState(State.Normal);
        }

        /// <summary>
        /// Activates the tower controller UI with the specific information
        /// </summary>
        /// <param name="tower">
        /// The tower controller information to use
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Throws exception when selecting tower when <see cref="State" /> does not equal <see cref="State.Normal" />
        /// </exception>
        public void SelectTower(GameObject Tower)
        {
            if (state != State.Normal)
            {
                throw new InvalidOperationException("Trying to select whilst not in a normal state");
            }
            DeselectTower();
            currentSelectedTower = Tower;
        }

        /// <summary>
        /// Upgrades <see cref="currentSelectedTower" />, if possible
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Throws exception when selecting tower when <see cref="State" /> does not equal <see cref="State.Normal" />
        /// or <see cref="currentSelectedTower" /> is null
        /// </exception>
        public void UpgradeSelectedTower()
        {
            if (state != State.Normal)
            {
                throw new InvalidOperationException("Trying to upgrade whilst not in Normal state");
            }
            if (currentSelectedTower == null)
            {
                throw new InvalidOperationException("Selected Tower is null");
            }
            /*if (currentSelectedTower.isAtMaxLevel)
            {
                return;
            
            int upgradeCost = currentSelectedTower.GetCostForNextLevel();
            bool successfulUpgrade = true;// = LevelManager.instance.currency.TryPurchase(upgradeCost);
            if (successfulUpgrade)
            {
                currentSelectedTower.UpgradeTower();
            }*/
            towerUI.Hide();
            DeselectTower();
        }

        /// <summary>
        /// Buys the tower and places it in the place that it currently is
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Throws exception if trying to buy towers in Build Mode
        /// </exception>
        public void BuyTower(GameObject Tower, Vector3 Position, Quaternion Rotation)
        {
            Debug.Log("created tower.");
            GameObject towerCreated = Instantiate(Tower, Position, Rotation, currentSelectedTower.transform);
        }

        /// <summary>
        /// Deselect the current tower and hides the UI
        /// </summary>
        public void DeselectTower()
        {
            if (state != State.Normal)
            {
                throw new InvalidOperationException("Trying to deselect tower whilst not in Normal state");
            }
            currentSelectedTower = null;
        }

        /// <summary>
        /// Set initial values, cache attached components
        /// and configure the controls
        /// </summary>
        protected void Awake()
        {
            state = State.Normal;
            my_Camera = GetComponent<Camera>();
        }

        /// <summary>
        /// Closes the Tower UI on death of tower
        /// </summary>
        protected void OnTowerDied()
        {
            towerUI.enabled = false;
            DeselectTower();
        }

    }
}