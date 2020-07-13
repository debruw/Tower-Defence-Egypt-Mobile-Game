using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.ENEMY;

public class Poisoned : MonoBehaviour
{
    float poisonCooldown = 1.2f;
    float poisonCooldownMax = 1.2f;
    float damage = 10;

    // Update is called once per frame
    void Update()
    {
        if (poisonCooldown > 0)
        {
            poisonCooldown -= Time.deltaTime;
        }
        else
        {
            GetComponent<Enemy>().GetHit(10);
            poisonCooldown = poisonCooldownMax;
        }
    }
}
