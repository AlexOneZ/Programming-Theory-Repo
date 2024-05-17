using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class InheritanceSquareEnemy : InheritanceEnemy
{
    protected override void Attack()
    {
        print($"Use double attck. Attack to player = {attackDamage * 2}");
    }

    protected override void Move()
    {
        print("Use speed for jump of enemy");
        rb.velocity = Vector2.up * speed;
    }
}
