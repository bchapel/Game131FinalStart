using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShowPoints : Editor {

    GameObject robit;
    MoveInstructions instruct;

    [CustomEditor(typeof(MoveInstructions))]
	// Use this for initialization
	void Start () {
        Debug.Log("Showpoints starting up!");
        robit = GameObject.Find("MoveBot");
        instruct = robit.GetComponent<MoveInstructions>();
	}
	
	// Update is called once per frame
	void OnSceneGUI () {
        Debug.Log("ShowPoints says hi!");
        foreach(Vector3 p in instruct.positions)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(p, 5f);
        }

        foreach (Vector3 t in instruct.directions)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(t, 6f);
        }

        foreach (float r in instruct.ranges)
        {

        }
	}
}
