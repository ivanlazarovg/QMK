using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class HealerEnemy : MonoBehaviour
{
    [SerializeField]
    private int range = 10;
    [SerializeField]
    private int healthReturn = 1;
    private void Update()
    {
        if (Physics2D.OverlapCircle(this.transform.position, this.range) != null)
        {
            List<Collider2D> kur = Physics2D.OverlapCircleAll(this.transform.position, this.range).ToList();

            foreach (var hit in kur)
            {
                if (hit.CompareTag("Enemy"))
                {
                    hit.gameObject.GetComponent<EnemyScript>().health += healthReturn;
                }
            }
        }
    }
}
