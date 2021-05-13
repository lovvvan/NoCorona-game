using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Animator animator;
    protected Vector2 direction;

    [SerializeField]
    private int health;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    public virtual void TakeDamage(int damage)
    {
      health -= damage;
      if(health<=0)
      {
        animator.SetTrigger("Die");
      }
    }

    public void Move()
    {
        transform.Translate(direction*speed*Time.deltaTime);
        if(direction.x != 0 || direction.y != 0)
        {
            AnimateMovement(direction);
        }
        else
        {
            animator.SetLayerWeight(1,0);
            animator.SetLayerWeight(0,1);
        }
    }

    public void AnimateMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1,1);
        animator.SetLayerWeight(0,0);
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }
}
