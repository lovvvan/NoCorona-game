using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    private Animator animator;
    protected Vector2 direction;

    [SerializeField]
    private int health;

    // Start is called before the first frame update
    //Getting the animator component for later use
    protected virtual void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame and calling the move function
    protected virtual void Update()
    {
        Move();
    }

    // When the function is called from another class the health decreases
    // If health reaches 0, the player "dies" by activating the die animation, playing death audio and not being able to move
    // The Game over scene is then shown
    public virtual void TakeDamage(int damage)
    {
      health -= damage;
      if(health<=0)
      {
        speed = 0;
        animator.SetTrigger("Die");
        animator.SetLayerWeight(2,1);
        animator.gameObject.GetComponent<AudioSource>().Play();
       Invoke("LoadExitScene",2f);
      }
    }
    private void LoadExitScene()
    {
      SceneManager.LoadScene("GameOver");
    }

    // The character position are calculated and if the direction is not 0 they movement animation is activated
    // Otherwise the idle animation is activated
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
