using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritanceEnemy : MonoBehaviour
{
    // Inheritance 
    [Header("Variables of Enemy")]
    public int lifes = 3;
    public float speed = 2f;
    public int attackDamage = 2;

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

    protected virtual void Move()
    {
        print($"This method need for move enemy. Use speed = {speed} for move.");
        rb.velocity = Vector2.right * speed;
    }

    protected virtual void Attack()
    {
        print($"This method need for use attack of enemy. Use attackDamage = {attackDamage}");
    }

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
