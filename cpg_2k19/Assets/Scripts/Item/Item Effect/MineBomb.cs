using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBomb : MonoBehaviour
{
    bool canMove = false;
    public GameObject caster, target;
    Vector2 originPoint, targetPoint;
    CircleCollider2D missileCollider;
    Rigidbody2D missileBody;
    Vector2 dir;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(target))
        {
            target.GetComponent<Player>().deduceDamage(30f, new Vector2(0f,-1f));
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

    }

    IEnumerator CastingTime()
    {
        yield return new WaitForSeconds(.1f);
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
        Debug.Log(dir);
        float x_a = dir.x;
        float y_b = dir.y;
        canMove = true;
    }
}