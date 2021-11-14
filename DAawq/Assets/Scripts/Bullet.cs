using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    private Transform caps;
    public int damage = 2;
    public float speed = 400;

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
        }
        this.transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed* Time.deltaTime);

        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = q;
    }
}
