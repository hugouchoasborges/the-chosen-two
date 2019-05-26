using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissile : MonoBehaviour
{
    bool canMove = false;
    public GameObject caster, target;
    Vector2 originPoint, targetPoint;
    CircleCollider2D missileCollider;
    Rigidbody2D missileBody;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(target))
        {
            target.GetComponent<Player>().deduceDamage(30f);
            Destroy(gameObject);
        }
        else if (collision.gameObject.Equals(caster))
        {

        }
        else if (caster != null)
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        missileCollider = GetComponent<CircleCollider2D>();
        missileBody = GetComponent<Rigidbody2D>();
        StartCoroutine(CastingTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, 0.15f);
            if (Vector3.Distance(transform.position, targetPoint) <= 0.01f)
                Destroy(gameObject);
        }
        
    }

    IEnumerator CastingTime()
    {
        yield return new WaitForSeconds(.15f);
        if (caster.name == "Player")
        {
            target = GlobalVariables.player2.gameObject;
        }
        else
        {
            target = GlobalVariables.player1.gameObject;
        }
        originPoint = caster.transform.position;
        targetPoint = target.transform.position;
        canMove = true;
    }
}