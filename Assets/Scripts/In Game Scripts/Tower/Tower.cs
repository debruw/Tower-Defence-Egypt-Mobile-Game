using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.GAME;
using UnityEngine.UI;

namespace TDLWRP.TOWER
{
    public class Tower : MonoBehaviour
    {
        /// <summary>
        /// The tower levels associated with this tower
        /// </summary>
        public GameObject[] TowerUpgradeModels;

        /// <summary>
        /// Reference to scriptable object with level data on it
        /// </summary>
        public TowerLevelData my_levelData;

        /// <summary>
        /// Tower name
        /// </summary>
        public string towerName;

        /// <summary>
        /// Tower range
        /// </summary>
        public int towerRange;

        /// <summary>
        /// 
        /// </summary>
        public int towerDamage;

        /// <summary>
        /// 
        /// </summary>
        public int towerSpeed;

        /// <summary>
        /// Tower build cost
        /// </summary>
        public int buildCost;

        /// <summary>
        /// The current level of the tower
        /// </summary>
        public int currentLevel { get; protected set; }

        public GameObject targetObject;

        GameController my_gameController;

        public int specializeCount;

        private void Start()
        {
            my_gameController = FindObjectOfType<GameController>();
            currentLevel = 0;
        }

        /// <summary>
        /// Cache and update oftenly used data
        /// </summary>
        public void setLevel(int level)
        {
            /*if (level < 0 || level > levels.Length)
            {
                return;
            }
            if (this.gameObject.transform.parent.gameObject.GetComponent<TowerPlaces>().isOccupied)
            {
                Destroy(this.gameObject);
            }

            this.gameObject.transform.parent.GetComponent<TowerPlaces>().BuildTower(levels[level].gameObject);
            my_gameController.DisableMenus();*/
        }

        /// <summary>
        /// Gets whether the tower can level up anymore
        /// </summary>
        public bool isAtMaxLevel
        {
            get { return currentLevel == /*levels.Length -*/ 1; }
        }

        /// <summary>
        /// Provides information on the cost to upgrade
        /// </summary>
        /// <returns>Returns -1 if the towers is already at max level, other returns the cost to upgrade</returns>
        public int GetCostForNextLevel()
        {
            if (isAtMaxLevel)
            {
                return -1;
            }
            //return levels[currentLevel + 1].cost;
            //TO DO
            return 0;
        }

        /// <summary>
        /// Used to (try to) upgrade the tower data
        /// </summary>
        public virtual bool UpgradeTower()
        {
            if (isAtMaxLevel)
            {
                return false;
            }
            setLevel(currentLevel + 1);
            return true;
        }

        /// <summary>
        /// Provides the value recived for selling this tower
        /// </summary>
        /// <returns>A sell value of the tower</returns>
        public int GetSellLevel()
        {
            return GetSellLevel(currentLevel);
        }

        /// <summary>
        /// Provides the value recived for selling this tower of a particular level
        /// </summary>
        /// <param name="level">Level of tower</param>
        /// <returns>A sell value of the tower</returns>
        public int GetSellLevel(int level)
        {
            // sell for full price if waves haven't started yet
            return 0;
            //TO DO levels[currentLevel].sell;
        }

        public void Sell()
        {
            Destroy(gameObject);
        }
    }
}