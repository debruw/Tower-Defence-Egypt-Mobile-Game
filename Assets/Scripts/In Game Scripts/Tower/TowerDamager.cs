using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.ENEMY;

namespace TDLWRP.TOWER
{
    public class TowerDamager : MonoBehaviour
    {
        public GameObject bullet;
        public Transform bulletSpawn;

        float attackCooldown = 1f;
        public float attackCooldownMax;

        GameObject targetObject;

        bool canShoot = false;

        Tower my_tower;

        /// <summary>
        /// The transform to point at the target
        /// </summary>
        public Transform turret;

        private void Start()
        {
            my_tower = GetComponentInParent<Tower>();
        }

       /* private void FixedUpdate()
        {
            if (attackCooldown > 0)
            {
                attackCooldown -= Time.deltaTime;
            }
            else
            {
                if (targetObject != null)
                {
                    Shoot(targetObject);
                    attackCooldown = attackCooldownMax;
                }
            }
        }*/

        private void Update()
        {
            if (targetObject != null)
            {
                // Turning turret rotation to target enemy
                AimTurret();
            }
            if (attackCooldown > 0)
            {
                attackCooldown -= Time.deltaTime;
            }
            else
            {
                if (targetObject != null)
                {
                    Shoot(targetObject);
                    attackCooldown = attackCooldownMax;
                }
            }
        }

        protected void AimTurret()
        {
            Vector3 targetPosition = targetObject.transform.position - turret.position;
            targetPosition.y = 0;
            Vector3 newDir = Vector3.RotateTowards(turret.forward, targetPosition, 3 * Time.deltaTime, 0.0f);
            //Debug.DrawRay(transform.position, newDir, Color.red);

            turret.rotation = Quaternion.LookRotation(newDir);
        }

        void Shoot(GameObject target)
        {
            if (target.GetComponent<Enemy>() != null)
            {
             
                GameObject bulletCreated = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation, transform);
                bulletCreated.GetComponent<BulletMover>().targetObject = targetObject;
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "enemy")
            {
                if (targetObject == null)
                {
                    targetObject = collision.gameObject;
                }
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.gameObject == targetObject)
            {
                targetObject = null;
            }
        }
    }
}