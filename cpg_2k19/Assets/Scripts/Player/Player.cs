using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables

    // Components
    [HideInInspector]
    public Animator animator;
    private Color oldColor;

    internal void activatedShield()
    {
        throw new NotImplementedException();
    }

    [HideInInspector]
    public SpriteRenderer spriteRenderer;

    public Inventory inventory;

    [Header("Unity Stuff")]
    public Image HealthBar;

    public float speed;

    #endregion

    public float health;
    public float barrierTime;
    public bool shieldActive;
    public bool swordEquipped;
    public bool staffEquipped;
    public int selfMask;
    public int enemyMask;
    

    internal void finishSlash()
    {
        animator.SetBool("Slash_Horizontal", false);
        animator.SetBool("Slash_Up", false);
        animator.SetBool("Slash_Down", false);
    }

    public void useItem ()
    {
        if (GetComponent<Inventory>().currInventorySize > 0)
        {
            GetComponent<Inventory>().useFirstItem();
        }
        else
        {
            punch();
        }
    }

    // Punch processing
    public void punch ()
    {
        // Process RayTracing here
        RaycastHit2D[] punchHit = Physics2D.RaycastAll(transform.position, (transform.position + transform.forward), 5.0f);
        foreach (RaycastHit2D target in punchHit)
        {
            Collider2D targetEval = target.collider; 
            if (targetEval.name == "Player2")
            {
                Debug.Log("Hit player 2");
                Debug.Log("My name is " + this.name);
            }
        }
        Debug.DrawRay(transform.position, (transform.position + transform.forward), Color.green, 10.0f, true);
        //if (!target)
        //{
        //    return;
        //}
        //if ((target.gameObject.GetType() == this.GetType()) && (!(target.gameObject.Equals(this))))
        //{
        //    target.gameObject.GetComponent<Player>().deduceDamage(5.0f);
        //    Debug.Log("Nice hit ya wanker!!");
        //}
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
            if (health > 100.0f)
            {
                health = 100.0f;
            }
        }
    }

    // Barrier effects
    public void activateBarrier ()
    {
        Debug.Log("Shield on!");
        shieldActive = true;
        oldColor = spriteRenderer.color;
        spriteRenderer.color = Color.yellow;
        StartCoroutine(barrierCountdown(barrierTime));
    }

    IEnumerator barrierCountdown (float barrierTime)
    {
        yield return new WaitForSeconds(barrierTime);
        shieldActive = false;
        Debug.Log("Shield off!");
        spriteRenderer.color = oldColor;
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
