using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwordSwing : Projectiles
{
    public Player attacker;

    public void setAttacker (Player user)
    {
        attacker = user;
        Debug.Log("Attacker:" + attacker);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collided = collision.gameObject;
        Debug.Log("Collision:" + collision);
        // Checks if the collisor is a Player type object and if it isn't the attacker (to avoid self-harm)
        if (collided.GetComponent<Player>())
        {
            Player receiver = collided.GetComponent<Player>();
            receiver.deduceDamage(25.0f);
            Debug.Log("Ouch! " + receiver.health + " HP");
        }
        gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, 2.0f));
        Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        RaycastHit2D hitRange = Physics2D.Raycast(transform.position, Vector2.zero, 5.0f);
        if (hitRange != null)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
