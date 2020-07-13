using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    StarController my_starController;

    public Image SkillIcon;
    public Text SkillName, SkillDescription, SkillCost;

    public Skill CurrentSkill;

    public RectTransform panelTower, panelSpecial;

    private void Start()
    {
        my_starController = FindObjectOfType<StarController>();
        panelTower.gameObject.SetActive(true);
        panelSpecial.gameObject.SetActive(false);
        FillBoard();
    }

    public void FillBoard()
    {
        if (CurrentSkill != null)
        {
            SkillIcon.sprite = CurrentSkill.skillSprite;
            SkillName.text = CurrentSkill.skillName;
            SkillDescription.text = CurrentSkill.skillDesciription;
            SkillCost.text = System.String.Empty + CurrentSkill.skillCost; 
        }
    }

    public void ShowTowersPanel()
    {
        panelTower.gameObject.SetActive(true);
        panelSpecial.gameObject.SetActive(false);
    }

    public void ShowSpecialsPanel()
    {
        panelSpecial.gameObject.SetActive(true);
        panelTower.gameObject.SetActive(false);
    }


    public void BuyUpgradeButtonClick()
    {
        CurrentSkill.isPurchased = true;
        my_starController.ChangeStarNumber(-CurrentSkill.skillCost);
    }

    public void ResetButtonClick()
    {
        //hepsini resetle
    }

    public void BackButtonClick()
    {
        //ana menüye döndür
    }
}
