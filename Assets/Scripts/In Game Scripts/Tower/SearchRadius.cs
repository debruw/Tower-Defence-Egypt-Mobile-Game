using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchRadius : MonoBehaviour
{
    public List<GameObject> nearastEnemies;

    private void OnTriggerEnter(Collider other)
    {
        
        if(!nearastEnemies.Contains(other.gameObject) && other.tag == "enemy")
        {
            nearastEnemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (nearastEnemies.Contains(other.gameObject) && other.tag == "enemy")
        {
            nearastEnemies.Remove(other.gameObject);
        }
    }
}
