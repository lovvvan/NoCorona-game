using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_girl : Character
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        GetInput();
    }

    // Update is called once per frame
    protected override void Update()
    {

        base.Update();
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        direction += Vector2.down;

    }
}
