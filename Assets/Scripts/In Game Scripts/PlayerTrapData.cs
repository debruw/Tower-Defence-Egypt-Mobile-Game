using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrapData.asset", menuName = "TowerDefense/Trap Configuration", order = 2)]
public class PlayerTrapData : ScriptableObject
{
    public float coolDownMax;
    public int damage;
    public float duration;
}
