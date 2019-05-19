using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMagic : Item
{
    public Rigidbody2D magicMissile;
    public float magicMissileSpeed = 8f;
    public GameObject magicCaster;

    public override void useItem(GameObject user)
    {
        executeMagicStrike(user);
        // Destroy the item if its health drops to 0
        --itemHealth;
        //Debug.Log("Used a barrier item! Its health is now " + itemHealth);
    }

    public override void dropItem()
    {

    }

    void executeMagicStrike(GameObject user)
    {
        Debug.Log("Usou Mágica");
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
        Rigidbody2D missile = Instantiate(magicMissile, user.transform.position, Quaternion.identity);
        missile.velocity = angle;
        Physics.IgnoreCollision(missile.gameObject.GetComponent<SphereCollider>(), user.GetComponent<BoxCollider>());
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
