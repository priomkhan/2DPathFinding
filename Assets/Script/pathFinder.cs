using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathFinder : MonoBehaviour {

	public GameObject target;
	public string layerName;
	NodeControl2 control;
	List<Vector2> path;

	void Awake(){	
	}

	void Start () {
		control = target.GetComponent<NodeControl2> ();
	}

	void Update(){
		Debug.Log ("Calling Path");
		path = control.Path (gameObject, layerName);
		if (path == null) {
			Debug.Log ("No Path Found");
		} else {
			for (int i = 0; i < path.Count - 1; i++) {
				Debug.Log (path.Count);
				DrawPath (path [i], path [i + 1], Color.blue);
			}
		}
	}


	void DrawPath(Vector2 startPos, Vector2 endPos, Color colorName){
	
		Vector3 start = new Vector3 (startPos.x, startPos.y, 0.0f);
		Vector3 end = new Vector3 (endPos.x, endPos.y, 0.0f);

		Debug.DrawLine (start, end, colorName);


	
	}



}
