using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables

    // Components
    [HideInInspector]
    public Animator animator;

    internal void activatedShield()
    {
        throw new NotImplementedException();
    }

    [HideInInspector]
    public SpriteRenderer spriteRenderer;

    public Inventory inventory;

    public float speed;

    #endregion

    public float health;
    public float barrierTime;
    bool shieldActive;
    bool swordEquipped;
    bool staffEquipped;
    

    public void useItem ()
    {
        if (GetComponent<Inventory>().currInventorySize > 0)
        {
            GetComponent<Inventory>().useFirstItem();
        }
    }

    // Damage processing
    public void deduceDamage (float damage)
    {
        if (!shieldActive)
        {
            health -= damage;
        }
        else if (damage < 0)
        {
            health -= damage;
        }
    }

    // Barrier effects
    public void activateBarrier ()
    {
        shieldActive = true;
        StartCoroutine(barrierCountdown(barrierTime));
    }

    IEnumerator barrierCountdown (float barrierTime)
    {
        yield return new WaitForSeconds(barrierTime);
        shieldActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.tag == "Item")
        {
            GetComponent<Inventory>().acquireItem(collided);
            collided.GetComponent<Item>().getAbsorbed();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.Contains("2"))
            GlobalVariables.player2 = this;
        else
            GlobalVariables.player = this;

        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        inventory = gameObject.GetComponent<Inventory>();

        health = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
