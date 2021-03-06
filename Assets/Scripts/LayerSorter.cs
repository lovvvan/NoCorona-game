using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorter : MonoBehaviour
{

    private SpriteRenderer parentRenderer;

    private List<Obstacle> obstacles = new List<Obstacle>();

    // Start is called before the first frame update
    //TODO: What is parentRenderer?
    void Start()
    {
        parentRenderer = transform.parent.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //TODO: what does this function do?
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            Obstacle o = collision.GetComponent<Obstacle>();
            o.FadeOut();

            if (obstacles.Count == 0 || o.MySpriteRenderer.sortingOrder -1 < parentRenderer.sortingOrder)
            {
                parentRenderer.sortingOrder = o.MySpriteRenderer.sortingOrder - 1;
            }

            obstacles.Add(o);
        }

    }

    //TODO: what does this function do?
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Obstacle o = collision.GetComponent<Obstacle>();
            o.FadeIn();
            obstacles.Remove(o);
            if (obstacles.Count == 0)
            {
                parentRenderer.sortingOrder = 200;
            }
            else
            {
                obstacles.Sort();
                parentRenderer.sortingOrder = obstacles[0].MySpriteRenderer.sortingOrder - 1;
            }
        }

    }
}
