using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissile : MonoBehaviour
{
    SphereCollider missileCollider;
    Rigidbody2D missileBody;

    // Start is called before the first frame update
    void Start()
    {
        missileCollider.GetComponent<SphereCollider>();
        missileBody.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
