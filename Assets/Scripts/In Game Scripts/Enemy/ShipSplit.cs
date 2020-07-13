using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDLWRP.ENEMY
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class ShipSplit : MonoBehaviour
    {
        Rigidbody[] rigidbodies;
        BoxCollider[] colliders;

        [SerializeField]
        Transform explosion;

        private void Start()
        {
            rigidbodies = this.gameObject.GetComponentsInChildren<Rigidbody>();
            colliders = this.gameObject.GetComponentsInChildren<BoxCollider>();
            foreach (Rigidbody rigid in rigidbodies)
            {
                rigid.AddExplosionForce(40f, explosion.position, 10f);
            }
            foreach (BoxCollider boxc in colliders)
            {
                boxc.enabled = false;
            }
        }

        private void Update()
        {
            Destroy(this.gameObject, 2f);
        }
    }
}