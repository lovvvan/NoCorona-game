using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private static Player myInstance;
    public static Player MyInstance
    {
      get
      {
        if(myInstance == null)
        {
          myInstance = FindObjectOfType<Player>();
        }
        return myInstance;
      }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        GetInput();
        base.Update();
    }

    public override void TakeDamage(int damage)
    {
      base.TakeDamage(damage);
    }

    private void GetInput()
    {
        direction=Vector2.zero;
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
        {
            direction+=Vector2.up;
        }
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            direction+=Vector2.left;
        }
        if(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
        {
            direction+=Vector2.down;
        }
        if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            direction+=Vector2.right;
        }
    }
}
