using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
  //Makes the player a singleton
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

    private Vector3 position;
    static public int score = 0;
    

    // Start is called before the first frame update
    //Uses the character start as a base
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    //Uses the character update as a base
    protected override void Update()
    {
        GetInput();
        base.Update();

        if (hasWon())
        {
            Invoke("LoadWonScene", 1f);
        }
    }

    // Checks if the player has walked to the end of the road
    private bool hasWon()
    {
        position = GameObject.Find("Player").transform.position;
        //Debug.Log("position");
        //Debug.Log(position.x);
        if(position.x > 56)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Loads the Finished scene
    private void LoadWonScene()
    {
        SceneManager.LoadScene("Finished");
    }

    //Uses the character take damage as a base
    public override void TakeDamage(int damage)
    {
        score = (int)position.x -5;
        base.TakeDamage(damage);
    }

    // Calls the sprint method in character class to change speed to run
    public override void sprint()
    {
        base.sprint();
    }
    // Calls the walk method in character class to change speed to walk
    public override void walk()
    {
        base.walk();
    }

    //Moves the character in the direction of the key input, checks for both W,A,S,D and arrow keys
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
        if (Input.GetKey("left shift")||Input.GetKey("right shift"))
        {
            sprint();
        }
        else
        {
            walk();
        }
    }
}
