using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData.asset", menuName = "TowerDefense/Enemy Configuration", order = 3)]
public class EnemyData : ScriptableObject
{
    public int startHealth;
    public bool isHaveArmor;
    public int moveSpeed;
    public int rewardCurrency;
    public GameObject shipSplitPrefab;
}
