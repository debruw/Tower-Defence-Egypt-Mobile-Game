using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDLWRP.ENEMY
{
    public class Enemy : MonoBehaviour
    {
        List<Transform> waypoints;

        [SerializeField]
        Canvas healthCanvas;

        int currentNode;
        bool waypointsDefined = false;

        public float moveSpeed;
        float maxMoveSpeed;
        bool isTide;

        // ////////////////////////////////////////////
        CurrencyController my_currencyController;
        public EnemyData my_enemyData;
        private float currentHealth;

        public bool isHaveArmor;

        public Image healthBar;
        // /////////////////////////////////////////

        private void Start()
        {
            currentNode = 0;
            maxMoveSpeed = moveSpeed;
            currentHealth = my_enemyData.startHealth;
            my_currencyController = FindObjectOfType<CurrencyController>();
        }
        
        private void Update()
        {
            if (waypoints != null)
            {
                if (currentNode < waypoints.Count && waypointsDefined)
                {
                    Move();
                    healthCanvas.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }

        void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentNode].position, moveSpeed * Time.deltaTime);
            Vector3 posEnemy = transform.position;
            Vector3 posWaypoint = waypoints[currentNode].position;

            if (currentNode >= 1)
            {
                Vector3 posPreviousWaypoint = waypoints[currentNode - 1].position;
                transform.forward = Vector3.Slerp(transform.forward, (posWaypoint - posPreviousWaypoint), Time.deltaTime * moveSpeed);
            }
            else
            {
                transform.forward = Vector3.Slerp(transform.forward, (posWaypoint - posEnemy), Time.deltaTime * moveSpeed);
            }

            if (posEnemy == posWaypoint)
            {
                currentNode++;
            }

        }

        public void SetWaypoints(Transform[] wyps)
        {
            waypoints = new List<Transform>(wyps);
            waypointsDefined = true;
        }

        public void ChangeMovespeed(float ms)
        {
            moveSpeed = ms;
        }

        public float GetMaxMovespeed()
        {
            return maxMoveSpeed;
        }

        public float GetMovespeed()
        {
            return moveSpeed;
        }

        public void SetTide(bool b)
        {
            isTide = b;
            GameObject nodes = GameObject.Find("pathNodes");
            if (isTide)
            {
                moveSpeed = 0.5f;
                nodes.transform.position = new Vector3(nodes.transform.position.x, 0.2f, nodes.transform.position.z);
            }
            else
            {
                nodes.transform.position = new Vector3(nodes.transform.position.x, 0.5f, nodes.transform.position.z);
                moveSpeed = 2f;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "enemy")
            {
                Physics.IgnoreCollision(this.GetComponent<CapsuleCollider>(), collision.gameObject.GetComponent<CapsuleCollider>());
            }
        }

        public void GetHit(float dmg)
        {
            currentHealth -= dmg;

            healthBar.fillAmount = currentHealth / my_enemyData.startHealth;

            if (currentHealth <= 0)
            {
                my_currencyController.ChangeCurrency(my_enemyData.rewardCurrency);
                Destroy(gameObject);
                Instantiate(my_enemyData.shipSplitPrefab, this.transform.position, this.transform.rotation);
            }
        }
    }
}
