using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public float health = 100f;
    public float moveSpeed = 21f;
    public float damage = 10f;
    public float jumpForce = 5f;

   protected bool CheckDeath()
    {
        if (health <= 0)
        {
            return true;
        }
        return false;
    }
}
