using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TDLWRP.UI.HUD;

namespace TDLWRP.GAME
{
    public class GameController : MonoBehaviour
    {
        public GameObject currentSelectedTrap;

        public CurrencyController my_Currency;
        
        public Text waveText;
        
        [SerializeField]
        GameUI my_gameUI;

        float alphaValue = 0;

        float updateTimer = 0f;
        float updateTimerMax = 0.1f;

        bool startDeathCheck = false;

        float deathCheckTimer = 0f;
        float deathCheckTimerMax = 0.1f;
     
        int wave;

        List<GameObject> enemies = new List<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            UpdateText();
        }

        public void Update()
        {
            if (startDeathCheck)
            {
                if (deathCheckTimer > 0)
                {
                    deathCheckTimer -= Time.deltaTime;
                }
                else
                {
                    bool isAllDead = true;
                    foreach (GameObject e in enemies)
                    {
                        if (e != null)
                        {
                            isAllDead = false;
                        }
                    }

                    if (isAllDead)
                    {
                        Debug.Log("--------------------------------WIN------------------------------------");
                        my_gameUI.finalText.text = "YOU WIN";
                        Time.timeScale = 0;
                    }

                    deathCheckTimer = deathCheckTimerMax;
                }
            }
        }

        public void SetWave(int newWave)
        {
            wave = newWave;
        }

        void UpdateText()
        {
            waveText.text = "Wave: " + wave;
        }

        public void StartCheckingWin()
        {
            Debug.Log("    START CHECKING FOR WIN CONDITION     ");
            startDeathCheck = true;
        }

        public int GetCurrency()
        {
            return my_Currency.GetCurrency();
        }

        public void AddEnemy(GameObject e)
        {
            enemies.Add(e);
        }
    }
}