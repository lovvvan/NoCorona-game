using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: Character
{
    [SerializeField]
    private int damage;
    [SerializeField]
    public int prefabID;
    // Start is called before the first frame update
    // Uses character.start as base
    // calls the getInput() function
    protected override void Start()
    {
        base.Start();
        GetInput();
    }
    // Update is called once per frame
    // Uses character.update as base
    protected override void Update()
    {
        base.Update();
    }

    //Makes the player lose 10 health by calling the TakeDamage() function
    public void DoDamage()
    {
      Player.MyInstance.TakeDamage(10);
    }

    // Makes the enemies constantly move to the left
    private void GetInput()
    {
        direction = Vector2.zero;
        direction += Vector2.left;

    }
}
