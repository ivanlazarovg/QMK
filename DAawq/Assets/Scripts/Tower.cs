using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Tower : MonoBehaviour
{
    public float charge;
    public int maxCharge;
    public int drainPerShooting;
    public int damage;
    public float timeBetweenShots;
    private float currentTimeBetweenShots;
    public int range;

    public bool isDragging;
    public bool isDisabled;

    public GameObject Bullet;
    

    private void Update()
    {
        Transform target = null;
        if (Physics2D.OverlapCircle(this.transform.position, this.range) != null)
        {
            List<Collider2D> kur = Physics2D.OverlapCircleAll(this.transform.position, this.range).ToList();
            float bestDistance = 0;

            foreach (var hit in kur)
            {
                if (hit.gameObject.tag == "Enemy")
                {
                    float distance = hit.GetComponent<EnemyScript>().distanceTraveled;
                    if (distance > bestDistance)
                    {
                        target = hit.transform;
                    }
                }
            }
        }

        isDragging = gameObject.GetComponent<DragDrop>().isDragging;

        if (!isDragging && !isDisabled && currentTimeBetweenShots <= 0 && target != null && charge > 0)
        {
            Shoot(damage, target);
            charge -= drainPerShooting;
            currentTimeBetweenShots = timeBetweenShots;
        }

        if (currentTimeBetweenShots > 0)
        {
            currentTimeBetweenShots -= 0.1f;
        }

        if (Mathf.FloorToInt(charge) < maxCharge)
        {
            charge += 0.01f;
        }
    }

    void Upgrade(TowerUpgradeData towerUpgradeData)
    {
        charge += towerUpgradeData.charge;
        drainPerShooting += towerUpgradeData.drainPerShooting;
        damage += towerUpgradeData.damage;

        //visual
    }

    void Shoot(int damage, Transform target) 
    {
        GameObject bullet = Instantiate(Bullet, this.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().target = target;
        bullet.GetComponent<Bullet>().damage = damage;

    }
}
