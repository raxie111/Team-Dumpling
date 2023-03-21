using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour

{

    Collider2D swordCollider;
    Vector2 rightAttackOffset;
    public enum AttackDirection
    {
        left, right
    }

    public AttackDirection attackDirection;

    // Start is called before the first frame update

    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();
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
        swordCollider.enabled = true;
        transform.position = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.position = rightAttackOffset;
    }

    public void stopAttack()
    {
        swordCollider.enabled = false; 
    }
}
