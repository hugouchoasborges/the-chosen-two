using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwordSwing : Projectiles
{
    public Player attacker;

    public void setAttacker (Player user)
    {
        attacker = user;
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameObject collided = collision.gameObject;
        //// Checks if the collisor is a Player type object and if it isn't the attacker (to avoid self-harm)
        //if ((collided.GetType() == attacker.GetType()) && (!collided.Equals(attacker)))
        //{
        //    Player receiver = collided.GetComponent<Player>();
        //    receiver.deduceDamage(25.0f);
        //}
        //gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, 2.0f));
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
