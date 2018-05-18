using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Raycaster : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hello world!");
        DetectAction();
    }

    public void DetectAction()
    {

        Event currentEvent = Event.current;
        Debug.Log(currentEvent);

        switch (currentEvent.type)
        {

            case EventType.KeyDown:

                break;

            case EventType.KeyUp:

                if (Event.current.keyCode == (KeyCode.T))
                {
                    Debug.Log("Pressed T");
                    Ray ray = Camera.current.ScreenPointToRay(Event.current.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log(hit.point);
                    }
                }

                break;


        }
    }

    private void OnEnable()
    {
        ArrayList sceneViews = SceneView.sceneViews;
        if (sceneViews.Count > 0) (sceneViews[0] as SceneView).Focus();
    }
}
