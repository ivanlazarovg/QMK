using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Pathfinder pathfinder;

    Transform[] transforms;

    public EnemyScriptableObject enemyTypeStats;

    [SerializeField]
    float distradius;
    int counter;
    PlayerInfo playerInfo;


    private void Start()
    {
        pathfinder = GameObject.Find("Pathfinder").GetComponent<Pathfinder>();
        playerInfo = GameObject.Find("PlayerHub").GetComponent<PlayerInfo>();
        transforms = pathfinder.pathtransforms.ToArray();
        counter = 0;

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transforms[counter].position, enemyTypeStats.speed * Time.deltaTime);

        if (Vector2.Distance(transforms[counter].position, transform.position) < distradius)
        {
            counter++;
            if(counter == transforms.Length)
            {
                playerInfo.TakeDamage(enemyTypeStats.damage);
                Destroy(this.gameObject);
            }
            
        }


        print(counter);
        
    }

    
}
