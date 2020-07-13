using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public string skillName;
    public Sprite skillSprite;
    public int skillId;

    [TextArea(1, 3)]
    public string skillDesciription;

    public bool isPurchased, isBuyable;

    public int skillCost;

    public Skill conditionSkill;

    SkillController my_skillController;

    private void Start()
    {
        my_skillController = FindObjectOfType<SkillController>();
        GetComponent<Image>().sprite = skillSprite;
        GetComponentInChildren<Text>().text = System.String.Empty + skillCost;
        GetComponent<Outline>().enabled = false;
        if (conditionSkill != null && conditionSkill.isPurchased)
        {
            gameObject.GetComponent<Button>().interactable = true; 
        }
        else if(conditionSkill != null)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    private void Update()
    {
        if(!isBuyable)
        {
            if(conditionSkill != null && conditionSkill.isPurchased)
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        if(my_skillController.CurrentSkill == this)
        {
            GetComponent<Outline>().enabled = true;
        }
        else
        {
            GetComponent<Outline>().enabled = false;
        }
    }

    public void Click()
    {
        Debug.Log("click");
        
        my_skillController.CurrentSkill = GetComponent<Skill>();
        my_skillController.FillBoard();
    }
}
