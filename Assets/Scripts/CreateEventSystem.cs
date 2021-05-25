using UnityEngine;
using UnityEngine.EventSystems;

//Event system, is created when UI elements are added
public class CreateEventSystem : MonoBehaviour
{
    void Start()
    {
        if (FindObjectOfType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }
    }
}
