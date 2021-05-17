using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: Character
{
    [SerializeField]
    private int damage;
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

    public void DoDamage()
    {
      Player.MyInstance.TakeDamage(10);
    }
  /*  private Transform target;

    public Transform Target
    {
      get
      {
        return target;
      }
      set
      {
        target = value;
      }
    }
*/

    private void GetInput()
    {
        direction = Vector2.zero;
        direction += Vector2.left;

    }
}
