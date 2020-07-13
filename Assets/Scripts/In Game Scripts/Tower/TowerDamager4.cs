using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Range içine girenleri zehirliyor.
namespace TDLWRP.TOWER
{
    [RequireComponent(typeof(SphereCollider))]
    public class TowerDamager4 : MonoBehaviour
    {
        float attackCooldown = 1.2f;
        float attackCooldownMax = 1.2f;
        GameObject targetObject;

        // Update is called once per frame
        void Update()
        {
            if (attackCooldown > 0)
            {
                attackCooldown -= Time.deltaTime;
            }
            else
            {
                if (targetObject != null)
                {
                    targetObject.AddComponent<Poisoned>();
                    attackCooldown = attackCooldownMax;
                }
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "enemy")
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