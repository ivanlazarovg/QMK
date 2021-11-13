using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int charge;
    public int drainPerShooting;
    public int damage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Upgrade(TowerUpgradeData towerUpgradeData)
    {
        charge += towerUpgradeData.charge;
        drainPerShooting += towerUpgradeData.drainPerShooting;
        damage += towerUpgradeData.damage;

        //visual
    }
}
