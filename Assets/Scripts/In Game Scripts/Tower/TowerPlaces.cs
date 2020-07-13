using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.GAME;

namespace TDLWRP.TOWER
{
    [RequireComponent(typeof(BoxCollider))]
    public class TowerPlaces : MonoBehaviour
    {
        GameController my_gameController;
        public bool isOccupied;

        public int towerLvl = 0;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            isOccupied = false;
            my_gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }

        public void BuildTower(GameObject Tower)
        {
            Debug.Log("created tower");
            GameObject towerCreated = Instantiate(Tower, transform);
            isOccupied = true;
            towerCreated.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            towerCreated.transform.parent = this.gameObject.transform;

        }

        public void ActivateMe()
        {
            isOccupied = false;
            this.gameObject.SetActive(true);
        }

        public bool GetisOccupied()
        {
            return isOccupied;
        }
    }
}