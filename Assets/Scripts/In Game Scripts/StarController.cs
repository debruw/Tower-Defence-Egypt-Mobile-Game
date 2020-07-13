using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    int currentStarNumber;

    public void ChangeStarNumber(int change)
    {
        currentStarNumber += change;
    }

    public int GetCurrentStarNumber()
    {
        return currentStarNumber;
    }
}
