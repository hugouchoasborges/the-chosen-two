﻿using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.Contains("2"))
            GlobalVariables.player2 = this;
        else
            GlobalVariables.player = this;

        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
