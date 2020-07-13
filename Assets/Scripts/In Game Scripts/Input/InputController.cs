using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.UI.HUD;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TDLWRP.TOWER;

namespace TDLWRP.INPUT
{
    public class InputController : MonoBehaviour
    {
        public GameUI my_gameUI;
        public Camera my_gameCamera;
        public Vector3 point, buildPosition;
        GraphicRaycaster raycaster;
        PointerEventData pointerEventData;
        EventSystem eventSystem;
        bool isInteractingWithUI = false;

        // Start is called before the first frame update
        void Start()
        {
            raycaster = FindObjectOfType<GraphicRaycaster>();
            eventSystem = FindObjectOfType<EventSystem>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) /*|| Input.GetTouch(0).phase == TouchPhase.Began*/)
            {
                Debug.Log("state:" + my_gameUI.state);
                if (my_gameUI.state == GameUI.State.Normal)
                {
                    CheckİsGui();
                    if (GetIsInteractingWithUI())
                    {
                        Debug.Log("its ui!");
                        //its ui element
                    }
                    else
                    {
                        CheckMouseInput();
                    }
                }
            }

        }

        void CheckİsGui()
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);

            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            isInteractingWithUI = results.Count > 0;
        }

        public bool GetIsInteractingWithUI()
        {
            return isInteractingWithUI;
        }

        void CheckMouseInput()
        {

            Ray ray;
            /*if (Application.platform == RuntimePlatform.Android && Application.platform == RuntimePlatform.IPhonePlayer)
            {
                ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            }
            else
            {*/
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //}

            RaycastHit[] hits = Physics.RaycastAll(ray, 100.0f);

            if (hits != null)
            {
                foreach (RaycastHit hit in hits)
                {
                    point = my_gameCamera.WorldToScreenPoint(hit.collider.gameObject.transform.position);
                    point.z = 0;

                    Debug.Log("HIT :" + hit.collider.tag);
                    if (hit.collider.tag == "towerPlace")
                    {
                        if (!hit.collider.gameObject.GetComponent<TowerPlaces>().GetisOccupied())
                        {
                            my_gameUI.towerbuildUI.activeTowerPlace = hit.collider.gameObject.GetComponent<TowerPlaces>();
                            my_gameUI.towerbuildUI.gameObject.transform.position = point;
                            buildPosition = hit.collider.gameObject.transform.position;
                            my_gameUI.SelectTower(hit.collider.gameObject);
                            my_gameUI.towerbuildUI.gameObject.SetActive(true);
                            my_gameUI.towerSpecializeUI.Hide();
                            my_gameUI.towerUI.Hide();
                            return;
                        }
                    }
                    else if (hit.collider.tag == "tower")
                    {
                        my_gameUI.SelectTower(hit.collider.gameObject);
                        if (my_gameUI.currentSelectedTower.GetComponent<Tower>().specializeCount == 2)
                        {
                            my_gameUI.towerSpecializeUI.gameObject.transform.position = point;
                            my_gameUI.towerSpecializeUI.Show();
                            my_gameUI.radiusVisualizer.SetVisualizer(hit.collider.gameObject);
                            my_gameUI.radiusVisualizer.Show();
                        }
                        else
                        {
                            my_gameUI.towerUI.gameObject.transform.position = point;
                            my_gameUI.towerUI.Show(hit.collider.gameObject.GetComponent<Tower>());

                            my_gameUI.radiusVisualizer.SetVisualizer(hit.collider.gameObject);
                            my_gameUI.radiusVisualizer.Show();
                        }

                        return;
                    }
                    else if (hit.collider.tag == "trapSlot")
                    {
                        /*if (m_gameController.currentSelectedTower != null || m_gameController.currentSelectedTrap != null)
                        {
                            m_gameController.disableMenus();
                        }
                        m_gameController.currentSelectedTrap = hit.collider.gameObject;

                        if (!m_gameController.currentSelectedTrap.GetComponent<trapController>().getisOccupied())
                        {
                            hit.collider.gameObject.GetComponent<trapController>().enableBuildMenu();
                        }
                        else
                        {

                            hit.collider.gameObject.GetComponent<trapController>().enableUpgradeMenu();

                        }
                        return;*/

                    }
                    else if (hit.collider.tag == "trapSlowTrap")
                    {/*
                        m_gameController.currentSelectedTrap.GetComponent<trapController>().buildSlowingTrap();
                        m_gameController.disableMenus();
                        return;*/
                    }
                    else if (hit.collider.tag == "trapExplosiveTrap")
                    {/*
                        m_gameController.currentSelectedTrap.GetComponent<trapController>().buildExplosiveTrap();
                        m_gameController.disableMenus();
                        return;*/
                    }
                    else
                    {
                        my_gameUI.towerbuildUI.gameObject.SetActive(false);
                        //m_gameUI.towerUI.gameObject.SetActive(false);
                        my_gameUI.towerSpecializeUI.gameObject.SetActive(false);
                        my_gameUI.radiusVisualizer.Hide();
                        my_gameUI.DeselectTower();
                    }
                }
            }
            else
            {
                my_gameUI.towerbuildUI.gameObject.SetActive(false);
                //m_gameUI.towerUI.gameObject.SetActive(false);
                my_gameUI.towerSpecializeUI.gameObject.SetActive(false);
                my_gameUI.radiusVisualizer.Hide();
                my_gameUI.DeselectTower();
            }
        }
    }

}