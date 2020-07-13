using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDLWRP.TOWER
{
    /// <summary>
    /// Data container for settings per tower level
    /// </summary>
    [CreateAssetMenu(fileName = "TowerData.asset", menuName = "TowerDefense/Tower Configuration", order = 1)]
    public class TowerLevelData : ScriptableObject
    {
        /// <summary>
        /// 
        /// </summary>
        ///
        public int generalCost;

        /// <summary>
        /// 
        /// </summary>
        public int special1Cost;

        /// <summary>
        /// 
        /// </summary>
        public int special2Cost;

        /// <summary>
        /// 
        /// </summary>
        public int sellPrice;

        /// <summary>
        /// 
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

        public int GeneralCost
        {
            get
            {
                return generalCost;
            }
        }

        public int Special1Cost
        {
            get
            {
                return special1Cost;
            }
        }

        public int Special2Cost
        {
            get
            {
                return special2Cost;
            }
        }

        public int SellPrice
        {
            get
            {
                return sellPrice;
            }
        }

        public int TowerRange
        {
            get
            {
                return towerRange;
            }
        }

        public int TowerDamage
        {
            get
            {
                return towerDamage;
            }
        }

        public int TowerSpeed
        {
            get
            {
                return towerSpeed;
            }
        }
    }
}