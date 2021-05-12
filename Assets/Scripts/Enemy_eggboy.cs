using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_eggboy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.down);
    }
}
