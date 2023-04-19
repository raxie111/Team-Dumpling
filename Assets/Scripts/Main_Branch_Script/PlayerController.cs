using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Vector2 movementInput;
    Rigidbody2D rb;
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Animator animator;
    SpriteRenderer SpriteRenderer;

    public Sword swordAttack;

    public int health;
    public int maxHealth = 3;
    public HealthBar healthBar;

    public int maxSta = 20;

    public float collisionOffset = 0.05f;
        
  



    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        SpriteRenderer = GetComponent<SpriteRenderer>();

      
    }

    // Update is called once per frame
    public void FixedUpdate()
    {   
            if(movementInput != Vector2.zero)
            {

            bool success = TryMove(movementInput);
                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));

                    if (!success)
                    {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                }

                animator.SetBool("isMoving", success);

            }else {
                animator.SetBool("isMoving", false);
            }

            if(movementInput.x < 0){
                SpriteRenderer.flipX = true;
            swordAttack.attackDirection = Sword.AttackDirection.left;
            }else if(movementInput.x > 0){
                SpriteRenderer.flipX = false;
             swordAttack.attackDirection = Sword.AttackDirection.right;
        }               
     }
    

    private bool TryMove(Vector2 direction)
    {
        if(direction != Vector2.zero){
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);
            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }else {
            return false;
        }
    }


    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();

    }

    void OnFire(){
        animator.SetTrigger("swordAttack");
    }

    public void SwordAttack()
    {

        if(SpriteRenderer.flipX == true)
        {
            swordAttack.Attackleft();
        }
        else
        {
            swordAttack.AttackRight();
        }
    }

    public void EndSwordAttack()
    {
        swordAttack.stopAttack();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        healthBar.SetHealth(health);
        if(health == 0)
        {
            Destroy(gameObject);

            SceneManager.LoadScene("GameOver");
            
        }
    }
}
