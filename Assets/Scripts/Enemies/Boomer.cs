using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Boomer : Enemy
{
    [Header("Boomer")]
    public SphereCollider explosionSphere;
    public GameObject onSelfDestruct;
    public float explosionDelay = 2f;
    
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        SeekToTarget();
        if (CheckDeath())
        {
            SelfDestruct();
        }
    }


    void FixedUpdate()
    {
        // Check if we are target
        if (IsAtTarget())
        {
            StartCoroutine(StartDestruction(explosionDelay));
        }
    }

    IEnumerator StartDestruction(float delay)
    {
        // Ignite the player
        anim.SetTrigger("Explode");

        // Wait for explosionDelay
        yield return new WaitForSeconds(delay);
        // Check if we are still at targer
        if (IsAtTarget())
        {
            SelfDestruct();
        }
        else
        {
            //reset anim
            anim.SetTrigger("Deactivate");
        }
    }

   // bool IsFinished()
  //  {
   //     for (int i = 0; i < ...; i++)
   //     {

     //   }

      
  //  }

    void SelfDestruct()
    {
        PlayExplosion();
        Explode();
        Destroy(gameObject);
    }

    void PlayExplosion()
    {
        GameObject explosion = Instantiate(onSelfDestruct);
        explosion.transform.position = transform.position;
    }

    void Explode()
    {
        // Detect collision with others

        Collider[] hits = Physics.OverlapSphere(explosionSphere.transform.position, explosionSphere.radius * explosionSphere.transform.localScale.magnitude);
        // Loop through all of the objects we have hit
        for (int i = 0; i < hits.Length; i++)
        {
            Collider hit = hits[i];
            Character character = hit.GetComponent<Character>();
            // CheckDeath if we hit a character
            if(character != null)
            {
                // Reduce the health by damage
                character.health -= damage;
            }
        }
    }

}    