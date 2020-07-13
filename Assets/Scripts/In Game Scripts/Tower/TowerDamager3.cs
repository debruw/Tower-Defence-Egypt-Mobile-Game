using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.ENEMY;

// Range içindekilerin hızını içeride oldukları sürece azaltıyor.
namespace TDLWRP.TOWER
{
    [RequireComponent(typeof(SphereCollider))]
    public class TowerDamager3 : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "enemy")
            {
                other.gameObject.GetComponent<Enemy>().moveSpeed -= 1;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "enemy")
            {
                other.gameObject.GetComponent<Enemy>().moveSpeed += 1;
            }
        }
    }
}