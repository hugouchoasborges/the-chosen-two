using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables

    public int playerNumber = 0;

    // Components
    [HideInInspector]
    public Animator animator;
    public PlayerController playerController;
    private Color oldColor;

    public UIInventory uIInventory;

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

    public bool drinking = false;
    [SerializeField]
    private float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = Mathf.Clamp(value, 0f, 100f);
        }
    }
    public float attackCooldown = 0.35f;
    public float barrierTime;
    public bool shieldActive;
    public bool swordEquipped;
    public bool staffEquipped;
    public bool isDead;
    public bool isDamaged;
    public bool isAttacking = false;
    public int selfMask;
    public int enemyMask;

    public int facingDir; // 0 - Down, 1 - Left, 2 - Up, 3 - Right
    public int facingDir8;
    // 0 - S | 1 - SW | 2 - W | 3 - NW | 4 - N | 5 - NE | 6 - E | 7 - SE

    #endregion

    private void Awake()
    {
        uIInventory = GetComponent<UIInventory>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();

        if (gameObject.name.Contains("2"))
        {
            GlobalVariables.player2 = this;
            playerNumber = 2;
        }
        else
        {
            GlobalVariables.player1 = this;
            playerNumber = 1;
        }

        if (playerController && playerController.controllerNumber > 0)
        {
            playerController.SetControllerNumber(playerController.controllerNumber);
        }
        facingDir = 0;
        facingDir8 = 0;

        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        inventory = gameObject.GetComponent<Inventory>();
        isDead = false;
        isDamaged = false;
        Health = 100.0f;
    }

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
        if (!isDead && !isAttacking)
        {
            isAttacking = true;
            StartCoroutine(AttackCooldown(attackCooldown));
            if (GetComponent<Inventory>().currInventorySize > 0)
            {
                GetComponent<Inventory>().useSelectedItem();
            }
            else
            {
                //punch
                Debug.Log("No More PUNCH when there's no ITEMS");
            }
            
        }
    }

    public void sanicMode ()
    {
        speed += 4;
        StartCoroutine(SanicCooldown(4f));
    }

    IEnumerator AttackCooldown (float time)
    {
        yield return new WaitForSeconds(time);
        isAttacking = false;
    }

    IEnumerator SanicCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        speed -= 4;
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
                Health -= damage;
            }
            else if (damage < 0)
            {
                Health -= damage;
            }
            HealthBar.fillAmount = Health / 100f;
            if (Health <= 0)
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

    // Update is called once per frame
    void Update()
    {

    }
}
