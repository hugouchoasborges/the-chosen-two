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
        GlobalVariables.player = this;
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
