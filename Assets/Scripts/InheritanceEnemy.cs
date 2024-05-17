using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class InheritanceEnemy : MonoBehaviour
{
    // Inheritance 
    [Header("Variables of Enemy")]
    public int lifes = 3;
    public float speed = 2f;
    public int attackDamage = 2;

    // Encapsulation. Speed can't be equal 0 or negative number
    protected float speedOfUse
    {
        get { 
            if (speed > 0)
            {
                return speed;
            }
            else
            {
                print("Speed <= 0");
                return 1f;
            }
        }
        set {
            if (speed > 0)
            {
                speedOfUse = speed;
            }
            else
            {
                print("Speed <= 0");
                speedOfUse = 1f;
            }
        }
    }

    protected Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Move();
        Attack();
    }

    private void Update()
    {
        Move();
    }

    // Abstracrion function
    protected virtual void Move()
    {
        print($"This method need for move enemy. Use speed = {speedOfUse} for move.");
        rb.velocity = Vector2.right * speedOfUse;
    }

    // Abstracrion function
    protected virtual void Attack()
    {
        print($"This method need for use attack of enemy. Use attackDamage = {attackDamage}");
    }

    // Abstracrion function
    private void TakeDamage(int damage)
    {
        print($"This method need for get damage. Use life = {lifes}");
        lifes -= damage;
        if(lifes <= 0)
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(1);
            Attack();
        }
    }
}
