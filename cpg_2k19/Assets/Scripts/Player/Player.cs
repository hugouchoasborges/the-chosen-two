using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables

    // Components
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;

    public Inventory inventory;

    public float speed;

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player.cs trigger");
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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
