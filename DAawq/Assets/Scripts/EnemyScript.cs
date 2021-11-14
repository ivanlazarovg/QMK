using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public GameObject slider;
    public Transform sprite;    

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
        Vector3 targ = transforms[counter].transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        sprite.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        slider.SetActive(true);
        slider.GetComponent<Slider>().value = health / enemyTypeStats.health;

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
