using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_boy: Character
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        base.Update();
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        direction += Vector2.down;

    }
}
