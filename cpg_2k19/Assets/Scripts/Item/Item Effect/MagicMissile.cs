using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissile : MonoBehaviour
{
    GameObject caster, target;
    CircleCollider2D missileCollider;
    BoxCollider2D parentCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        target = collision.gameObject;
        caster = transform.parent.gameObject;
        if (target.name != caster.name)
        {
            if (target.GetComponent<Player>() != null)
            { 
                collision.gameObject.GetComponent<Player>().deduceDamage(30f);
                Destroy(gameObject);
            }
            else if (target.name.Contains("Colisor"))
                Destroy(gameObject);
       }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
