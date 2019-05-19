using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMagic : Item
{
    public GameObject castMissile;
    public float magicMissileSpeed = 8f;
    public GameObject magicCaster;

    public override void useItem(GameObject user)
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource)
        {
            audioSource.Play();
        }
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
        GameObject missile = Instantiate(castMissile, user.transform.position, Quaternion.identity);
        missile.GetComponent<MagicMissile>().caster = user;
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
