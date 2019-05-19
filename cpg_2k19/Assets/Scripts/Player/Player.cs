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
    
    public int facingDir; // 0 - Down, 1 - Left, 2 - Up, 3 - Right

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

    public Vector2 getFront ()
    {
        Vector2 front = new Vector2(1.0f, 1.0f);
        if (facingDir == 3)
        {
            front.y *= 0.0f;
        }
        else if (facingDir == 2)
        {
            front.x *= 0.0f;
            front.y *= 1.0f;
        }
        else if (facingDir == 1)
        {
            front.x *= -1.0f;
            front.y *= 0.0f;
        }
        else
        {
            front.x *= 0.0f;
            front.y *= -1.0f;
        }
        return front;
    }

    // Punch processing
    public void punch ()
    {
        // Process RayTracing here
        Vector2 playerForward = getFront();
        RaycastHit2D[] punchHit = Physics2D.RaycastAll(transform.position, playerForward, 100.0f);
        foreach (RaycastHit2D target in punchHit)
        {
            Collider2D targetEval = target.collider; 
            if (targetEval.name == "Player2" && this.name == "Player")
            {
                Debug.Log("Blue hits red!");
                targetEval.GetComponent<Player>().deduceDamage(5.0f);
                Debug.Log("HP REMAINING: " + targetEval.GetComponent<Player>().health);
            }
            else if (targetEval.name == "Player" && this.name == "Player2")
            {
                Debug.Log("Red hits blue!");
                targetEval.GetComponent<Player>().deduceDamage(5.0f);
                Debug.Log("HP REMAINING: " + targetEval.GetComponent<Player>().health);
            }
        }
        Debug.DrawRay(transform.position, playerForward, Color.green, 3.0f, true);
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
        HealthBar.fillAmount = health / 100f;
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
        facingDir = 0;
        
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
