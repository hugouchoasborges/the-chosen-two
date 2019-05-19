using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMine : Item
{
    public GameObject castMine;
    public float magicMissileSpeed = 8f;
    public GameObject magicCaster;

    public override void useItem(GameObject user)
    {
        layMine(user);
        // Destroy the item if its health drops to 0
        --itemHealth;
        //Debug.Log("Used a barrier item! Its health is now " + itemHealth);
    }

    public override void dropItem()
    {

    }

    void layMine(GameObject user)
    {
        // Debug.Log("Usou Mágica");
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
        GameObject mine = Instantiate(castMine, user.transform.position, Quaternion.identity);
        mine.GetComponent<MagicMissile>().caster = user;
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
