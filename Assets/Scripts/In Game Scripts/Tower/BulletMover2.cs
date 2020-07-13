using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.ENEMY;

[RequireComponent(typeof(CapsuleCollider))]
public class BulletMover2 : MonoBehaviour
{
    public float speed;
    Vector3 targetDir;

    public GameObject targetObject;
    Vector3 targetPosition;

    int targetCount = 0;
    public int maxTargetNumber;

    List<GameObject> nearestEnemies;

    private void Update()
    {
        nearestEnemies = GetComponentInChildren<SearchRadius>().nearastEnemies;
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
                targetCount++;
                targetObject = null;
                FindNewTarget();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }

    void FindNewTarget()
    {
        //Debug.Log("FIND NEW TARGET");
        if (targetCount < maxTargetNumber)
        {
            GetClosestObject();
        }
        else
        {
            targetObject = null;
            Destroy(gameObject);
        }
    }

    public void GetClosestObject()
    {
        //Debug.Log("GET CLOSEST");
        if (nearestEnemies.Count > 1)
        {
            int rand = Random.Range(0, nearestEnemies.Count);

            if (targetObject == nearestEnemies[rand])
            {
                GetClosestObject();
                return;
            }

            targetObject = nearestEnemies[rand];
        }
        if(nearestEnemies.Count == 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
      
            if (targetObject != null)
            {
                targetObject.GetComponent<Enemy>().GetHit(100);
                targetObject = null;
            }
        }
    }
}
