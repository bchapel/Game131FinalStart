using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(MoveInstructions))]
public class MoveEditor : Editor
{

    private Vector3 pos;
    private float dis;
    private Vector3 tar;
    private GameObject robit;
    private MoveInstructions instruct;
    private int i = 0;
    GameObject empty;


    private void DetectAction()
    {
        robit = GameObject.Find("MoveBot");
        instruct = robit.GetComponent<MoveInstructions>();
        Event currentEvent = Event.current;



        switch (currentEvent.type)
        {
            case EventType.MouseDown:
                Ray ray = Camera.current.ScreenPointToRay(Event.current.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    i++;
                    Vector3 temp = hit.point;

                    //temp.y = robit.transform.position.y;
                    Debug.Log(hit.point);
                    instruct.positions.Add(temp);
                    instruct.directions.Add(temp);
                    instruct.ranges.Add(0.5f);
                }
                break;
            case EventType.KeyDown:
                if (currentEvent.keyCode == KeyCode.Backspace || currentEvent.keyCode == KeyCode.Delete)
                {
                    if (i > 0)
                        i--;
                }

                break;
        }
    }

    private void OnSceneGUI()
    {
        DetectAction();
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < instruct.positions.Count; i++)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawSphere(instruct.positions[i], 0.3f);
        }

    }

    //void OnGUI()
    //{
    //    GUILayout.Button("Create Target")
    //        {
    //        i++;
    //        empty = new GameObject("empty");
    //        empty.name = i.ToString();
    //    }


        
    //}

}
