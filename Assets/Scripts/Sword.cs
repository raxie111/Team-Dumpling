using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour

{
    public Collider2D swordCollider;
    public float damage = 3;

    
    Vector2 rightAttackOffset;
    public enum AttackDirection
    {
        left, right
    }

    public AttackDirection attackDirection;

    // Start is called before the first frame update

    private void Start()
    {

        rightAttackOffset = transform.position;
    }

    public void Attack()
    {
        switch (attackDirection)
        {
            case AttackDirection.left:
                Attackleft();
                break;
            case AttackDirection.right:
                AttackRight();
                break;
        }
    }
    public void Attackleft()
    {
        print("Attack Left");
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void AttackRight()
    {
        print("Attack Right");
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void stopAttack()
    {
        swordCollider.enabled = false; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Deal damage
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Health -= damage;
            }
        }

    }
}
