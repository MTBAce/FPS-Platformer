using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public float health = 100f;
    GameObject toKill;

    public void TakeDamage (float amount)
    {
        toKill = this.gameObject;
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
        Debug.Log(gameObject);
    }

    void Die ()
    {
        Destroy(toKill);
    }
}
