using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerUpgrade", menuName = "ScriptableObjects/TowerUpgrade", order = 1)]
public class TowerUpgradeData : ScriptableObject
{
    public string upgradeName;
    public int charge;
    public int drainPerShooting;
    public int damage;
    public int waitTime;
}
