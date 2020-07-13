using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public RectTransform SettingsPanel;
    public Text UserId;
    public Button MusicBtn, SoundBtn, FacebookBtn, OtherBtn;

    // Start is called before the first frame update
    void Start()
    {
        SettingsPanel.gameObject.SetActive(false);
        //userid yi auth kısmından çek
        UserId.text = "UserID : "; //+ auth.userId;

        if (PlayerPrefs.GetInt("ISFIRSTTIMEOPENING", 1) == 1)
        {
            Debug.Log("First Time Opening");

            //Set first time opening to false
            PlayerPrefs.SetInt("ISFIRSTTIMEOPENING", 0);
            //Do your stuff here
            FirstSetup();
            InitializeScene();
        }
        else
        {
            Debug.Log("NOT First Time Opening");

            //Do your stuff here
            InitializeScene();
        }
    }

    public void PlayBtnClick()
    {
        SceneManager.LoadScene("LevelMenu", LoadSceneMode.Single);
    }

    public void SettingsBtnClick()
    {
        SettingsPanel.gameObject.SetActive(true);
    }

    public void SettingsPanelCloseBtnClick()
    {
        SettingsPanel.gameObject.SetActive(false);
    }

    ////////// SETTİNGS PANEL BUTTON CLİCKS /////////////////

    public void MusicButtonClick()
    {
        if (PlayerPrefs.GetInt("ISMUSICPLAYING") == 0)
        {
            Debug.Log("Make music play");
            PlayerPrefs.SetInt("ISMUSICPLAYING", 1);
            MusicBtn.GetComponent<Image>().color = Color.green;
            MusicBtn.GetComponentInChildren<Text>().text = "ON";
        }
        else
        {
            Debug.Log("Make music mute");
            PlayerPrefs.SetInt("ISMUSICPLAYING", 0);
            MusicBtn.GetComponent<Image>().color = Color.red;
            MusicBtn.GetComponentInChildren<Text>().text = "OFF";
            //Do your stuff here
        }
    }

    public void SoundButtonClick()
    {
        if (PlayerPrefs.GetInt("ISSOUNDON") == 0)
        {
            Debug.Log("Make sound on");
            PlayerPrefs.SetInt("ISSOUNDON", 1);
            SoundBtn.GetComponent<Image>().color = Color.green;
            SoundBtn.GetComponentInChildren<Text>().text = "ON";
        }
        else
        {
            Debug.Log("Make sound off");
            PlayerPrefs.SetInt("ISSOUNDON", 0);
            SoundBtn.GetComponent<Image>().color = Color.red;
            SoundBtn.GetComponentInChildren<Text>().text = "OFF";
            //Do your stuff here
        }
    }

    //////////// END - SETTİNG PANEL BUTTON CLİCKS //////////////////

    void FirstSetup()
    {
        Debug.Log("firstSetup");

        PlayerPrefs.SetInt("ISMUSICPLAYING", 1);
        PlayerPrefs.SetInt("ISSOUNDON", 1);
        //create user auth
    }

    void InitializeScene()
    {
        if(PlayerPrefs.GetInt("ISMUSICPLAYING") == 1)
        {
            MusicBtn.GetComponent<Image>().color = Color.green;
            MusicBtn.GetComponentInChildren<Text>().text = "ON";
        }
        else
        {
            MusicBtn.GetComponent<Image>().color = Color.red;
            MusicBtn.GetComponentInChildren<Text>().text = "OFF";
        }

        if (PlayerPrefs.GetInt("ISSOUNDON") == 1)
        {
            SoundBtn.GetComponent<Image>().color = Color.green;
            SoundBtn.GetComponentInChildren<Text>().text = "ON";
        }
        else
        {
            SoundBtn.GetComponent<Image>().color = Color.red;
            SoundBtn.GetComponentInChildren<Text>().text = "OFF";
        }
    }
}
