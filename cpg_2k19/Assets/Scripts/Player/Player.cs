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

    public List<AudioClip> audioClips;

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

    public bool drinking = false;
    public float health;
    public float barrierTime;
    public bool shieldActive;
    public bool swordEquipped;
    public bool staffEquipped;
    public bool isDead;
    public bool isDamaged;
    public int selfMask;
    public int enemyMask;

    public int facingDir; // 0 - Down, 1 - Left, 2 - Up, 3 - Right
    public int facingDir8;
    // 0 - S | 1 - SW | 2 - W | 3 - NW | 4 - N | 5 - NE | 6 - E | 7 - SE

    internal void StopDrinking()
    {
        animator.SetBool("Drink", false);
    }

    internal void SudoStopDrinking()
    {
        animator.SetBool("Drink", false);
        animator.SetBool("Potion", false);
        drinking = false;
    }

    internal void finishSlash()
    {
        animator.SetBool("Slash_Horizontal", false);
        animator.SetBool("Slash_Up", false);
        animator.SetBool("Slash_Down", false);
    }

    internal void finishPunch()
    {
        animator.SetBool("Punch_Horizontal", false);
        animator.SetBool("Punch_Up", false);
        animator.SetBool("Punch_Down", false);
    }

    public void useItem()
    {
        if (!isDead)
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
    }

    public Vector2 getFront()
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

    public Vector2 getFront8()
    {
        if (facingDir == 1)
            return new Vector2(-1.0f, -1.0f);
        else if (facingDir == 2)
            return new Vector2(-1.0f, 0.0f);
        else if (facingDir == 3)
            return new Vector2(-1.0f, 1.0f);
        else if (facingDir == 4)
            return new Vector2(0.0f, 1.0f);
        else if (facingDir == 5)
            return new Vector2(1.0f, 1.0f);
        else if (facingDir == 6)
            return new Vector2(1.0f, 0.0f);
        else if (facingDir == 7)
            return new Vector2(1.0f, -1.0f);
        else
            return new Vector2(0.0f, -1.0f);
    }

    // Punch processing
    public void punch()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource)
        {
            Debug.Log(audioClips);
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }

        animator.SetBool("Punch_Horizontal", true);
        animator.SetBool("Punch_Up", true);
        animator.SetBool("Punch_Down", true);

        // Process RayTracing here
        Vector2 playerForward = getFront();
        RaycastHit2D[] punchHit = Physics2D.RaycastAll(transform.position, playerForward, 1.0f);
        foreach (RaycastHit2D target in punchHit)
        {
            Collider2D targetEval = target.collider;
            if (targetEval.name == "Player2" && this.name == "Player")
            {
                targetEval.GetComponent<Player>().deduceDamage(5.0f, playerForward);
            }
            else if (targetEval.name == "Player" && this.name == "Player2")
            {
                targetEval.GetComponent<Player>().deduceDamage(5.0f, playerForward);
            }
        }
        Debug.DrawRay(transform.position, playerForward, Color.green, 3.0f, true);
    }

    // Damage processing
    public void deduceDamage(float damage, Vector2 direction)
    {
        //gameObject.GetComponent<Rigidbody2D>().AddForce(-direction * 3);
        gameObject.transform.Translate(direction / 2);
        deduceDamage(damage);
    }
    public void deduceDamage(float damage)
    {

        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource && damage > 0)
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }

        if (!isDead)
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
            if (health <= 0)
            {
                isDead = true;
            }
            isDamaged = true;
        }
    }

    // Barrier effects
    public void activateBarrier()
    {
        // g("Shield on!");
        shieldActive = true;
        oldColor = spriteRenderer.color;
        spriteRenderer.color = Color.yellow;
        StartCoroutine(barrierCountdown(barrierTime));
    }

    IEnumerator barrierCountdown(float barrierTime)
    {
        yield return new WaitForSeconds(barrierTime);
        shieldActive = false;
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
        facingDir8 = 0;

        if (gameObject.name.Contains("2"))
            GlobalVariables.player2 = this;
        else
            GlobalVariables.player = this;

        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        inventory = gameObject.GetComponent<Inventory>();
        isDead = false;
        isDamaged = false;
        health = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
