using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.ENEMY;

namespace TDLWRP.TOWER
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class BulletMover : MonoBehaviour
    {
        public float speed;
        Vector3 targetDir;

        public GameObject targetObject;
        Vector3 targetPosition;

        void Update()
        {
            if (targetObject != null)
            {
                targetPosition = targetObject.transform.position;
                targetDir = targetPosition - transform.position;

                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
                Debug.DrawRay(transform.position, newDir, Color.red);

                // Move our position a step closer to the target.
                transform.rotation = Quaternion.LookRotation(newDir);
                targetPosition = targetObject.transform.position;
            }
            else
            {
                if (transform.position == targetPosition)
                {
                    Destroy(gameObject);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                }
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "enemy")
            {
                if (targetObject != null)
                {
                    targetObject.GetComponent<Enemy>().GetHit(100);
                    Destroy(this.gameObject);
                }

            }
        }
    }
}