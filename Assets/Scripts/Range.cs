using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
  private Enemy parent;

  //Sets enemy variable to the Enemy parent component
  private void Start()
  {
    parent = GetComponentInParent<Enemy>();
  }

  //If the enemy collides with something with tag "Player" it calls the DoDamage function in the Enemy class
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Player")
    {
      parent.DoDamage();
      //parent.Target = collision.transform;
    }
  }
}
