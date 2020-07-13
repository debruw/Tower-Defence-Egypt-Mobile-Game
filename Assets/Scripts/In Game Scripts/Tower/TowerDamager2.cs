using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.ENEMY;

// Range içindekilerin hepsine hasar veriyor.
namespace TDLWRP.TOWER
{
    [RequireComponent(typeof(SphereCollider))]
    public class TowerDamager2 : MonoBehaviour
    {
        /// <summary>
        /// The current targetables in the collider
        /// </summary>
        protected List<GameObject> m_TargetsInRange = new List<GameObject>();
        float attackCooldown = 5.0f;
        float attackCooldownMax = 5.0f;
        float damage;

        private void Start()
        {
            damage = GetComponentInParent<Tower>().towerDamage;
        }

        private void Update()
        {
            if (attackCooldown > 0)
            {
                attackCooldown -= Time.deltaTime;
            }
            else
            {
                if (m_TargetsInRange.Count != 0)
                {
                    HitAll();
                    attackCooldown = attackCooldownMax;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "enemy")
            {
                var targetable = other.gameObject;
                m_TargetsInRange.Add(targetable);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "enemy")
            {
                var targetable = other.gameObject;
                m_TargetsInRange.Remove(targetable);
            }
        }

        void HitAll()
        {
            foreach (GameObject obj in m_TargetsInRange)
            {
                obj.GetComponentInParent<Enemy>().GetHit(damage);
            }
        }
    }
}