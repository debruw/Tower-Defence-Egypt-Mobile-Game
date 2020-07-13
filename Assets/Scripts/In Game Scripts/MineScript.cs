using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.ENEMY;

[RequireComponent(typeof(BoxCollider))]
public class MineScript : MonoBehaviour
{
    public PlayerTrapData my_playerTrapData;
    int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            if (count < my_playerTrapData.duration)
            {
                other.gameObject.GetComponent<Enemy>().GetHit(my_playerTrapData.damage);
                count++;
                if (count == my_playerTrapData.duration)
                {
                    Destroy(this.gameObject);
                }
            } 
        }
    }
}
