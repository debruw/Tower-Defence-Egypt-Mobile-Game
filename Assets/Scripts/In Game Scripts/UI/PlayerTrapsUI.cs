using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.ENEMY;

namespace TDLWRP.UI.HUD
{
    public class PlayerTrapsUI : MonoBehaviour
    {
        [SerializeField]
        GameUI my_gameUI;
        bool isDamageButtonClicked = false, isMineButtonClicked = false;

        [SerializeField]
        GameObject mine, water;

        public PlayerTrapData damageTrapData, tideTrapData;

        // Update is called once per frame
        void Update()
        {
            if (my_gameUI.state == GameUI.State.SpecialPower)
            {
                if (Input.GetKey(KeyCode.Mouse0) /*|| Input.GetTouch(0).phase == TouchPhase.Began*/)
                {
                    Ray ray;
                    /*if (Application.platform == RuntimePlatform.Android && Application.platform == RuntimePlatform.IPhonePlayer)
                    {
                        ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                    }
                    else
                    {*/
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    //}}
                    RaycastHit hit;

                    if (isMineButtonClicked)
                    {
                        if (Physics.Raycast(ray, out hit, 50.0f, 1 << 10))
                        {
                            if (hit.collider.tag == "Water")
                            {
                                GameObject createdMine = Instantiate(mine, hit.point, new Quaternion(0, 0, 0, 0));
                                createdMine.transform.position = new Vector3(createdMine.transform.position.x, 0, createdMine.transform.position.z);
                                isMineButtonClicked = false;
                                my_gameUI.SetState(GameUI.State.Normal);
                            }
                        }
                    }

                    if (isDamageButtonClicked)
                    {
                        if (Physics.Raycast(ray, out hit, 50.0f))
                        {
                            if (hit.collider.tag == "enemy")
                            {
                                hit.collider.gameObject.GetComponent<Enemy>().GetHit(damageTrapData.damage);
                                isMineButtonClicked = false;
                                my_gameUI.SetState(GameUI.State.Normal);
                            }
                        }
                    }
                }
            }
        }

        public void DamageButtonClick()
        {
            my_gameUI.SetState(GameUI.State.SpecialPower);
            isDamageButtonClicked = true;
        }

        public void MineButtonClick()
        {
            my_gameUI.SetState(GameUI.State.SpecialPower);
            isMineButtonClicked = true;
        }

        public void TideButtonClick()
        {
            water.GetComponent<Animator>().SetBool("WaterGetLow", true);
            Enemy[] enemies;
            enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemyMove in enemies)
            {
                enemyMove.SetTide(true);
            }
            Invoke("GetHigh", 3);
        }

        void GetHigh()
        {
            water.GetComponent<Animator>().SetBool("WaterGetLow", false);
            water.GetComponent<Animator>().SetBool("WaterGetHigh", true);
            Invoke("TideAnimationEnd", 0.1f);
        }

        void TideAnimationEnd()
        {
            water.GetComponent<Animator>().SetBool("WaterGetHigh", false);
            Enemy[] enemies;
            enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemyMove in enemies)
            {
                enemyMove.SetTide(false);
            }
        }
    }
}