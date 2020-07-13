using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.UI.HUD;

[RequireComponent(typeof(SphereCollider))]
public class EndPointScript : MonoBehaviour
{
    public GameUI my_gameUI;

    private void OnTriggerEnter (Collider collision)
    {
        if (my_gameUI.lives > 0)
        {
            if (collision.tag == "enemy")
            {
                Debug.Log("endpoint");
                my_gameUI.LoseLife(1);
                Destroy(collision.gameObject);
            } 
        }
    }
}
