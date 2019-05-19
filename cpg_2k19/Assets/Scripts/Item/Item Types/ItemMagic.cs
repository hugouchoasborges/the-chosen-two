using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMagic : Item
{
    public Rigidbody2D magicMissile;
    RaycastHit2D[] hits;
    public float magicMissileSpeed = 8f;
    public GameObject magicCaster;

    public override void useItem(GameObject user)
    {
        executeMagicStrike(user);
        // Destroy the item if its health drops to 0
        --itemHealth;
    }

    public override void dropItem()
    {

    }

    void executeMagicStrike(GameObject user)
    {
        GameObject enemy;
        // Instantiate the missle pointed towards the hostile

        if (user.name == "Player")
        {
            enemy = GameObject.Find("Player2");
        }
        else
        {
            enemy = GameObject.Find("Player");
        }        
        Vector2 enemyPos = enemy.transform.position;
        Vector2 userPos = user.transform.position;
        Vector2 angle = enemyPos - userPos;
        Rigidbody2D missile = Instantiate(magicMissile, user.transform.position, Quaternion.identity, user.transform);
        missile.velocity = angle * magicMissileSpeed * 0.25f;
    }

    // Start is called before the first frame update
    void Start()
    {
        hits = new RaycastHit2D[100];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
