using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region Variables

    public float speed;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.player = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
