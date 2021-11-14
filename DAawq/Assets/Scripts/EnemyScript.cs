using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    Pathfinder pathfinder;

    Transform[] transforms;

    public EnemyScriptableObject enemyTypeStats;

    [SerializeField]
    float distradius;
    int counter;
    PlayerInfo playerInfo;
    [SerializeField]
    public float distanceTraveled;

    public float health;
    float speed;

    private void Start()
    {
        health = enemyTypeStats.health;
        speed = enemyTypeStats.speed;
        pathfinder = GameObject.Find("Pathfinder").GetComponent<Pathfinder>();
        playerInfo = GameObject.Find("PlayerHub").GetComponent<PlayerInfo>();
        transforms = pathfinder.pathtransforms.ToArray();
        counter = 0;

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transforms[counter].position, speed * Time.deltaTime);

        if (Vector2.Distance(transforms[counter].position, transform.position) < distradius)
        {
            counter++;
            if(counter == transforms.Length)
            {
                playerInfo.TakeDamage(enemyTypeStats.damage);
                Destroy(this.gameObject);
            }
            
        }

        distanceTraveled += speed;

        if (this.health <= 0)
        {
            playerInfo.score += enemyTypeStats.scoregiven;
            playerInfo.textObjScore.text = playerInfo.score.ToString();
            Destroy(gameObject);
            
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("KUREC");
        if (collider.CompareTag("Bullet"))
        {
            TakeDamage(collider.gameObject.GetComponent<Bullet>().damage);
            Destroy(collider.gameObject);
            
        }
    }

    public void TakeDamage(int damage) 
    {
        health -= damage;
        Debug.Log("kur0");
    }
}
