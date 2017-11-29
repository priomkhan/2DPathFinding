using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathFinder : MonoBehaviour {

	public Rigidbody2D finder;
	public Rigidbody2D target;
	public string layerName;
	private RaycastHit2D[] hits;
	private RaycastHit2D hit;
	private LayerMask layerMask;
	Vector2 finderBound;
	// Use this for initialization
	void Start () {
		finder = this.GetComponent<Rigidbody2D>();

		target = GameObject.FindGameObjectWithTag ("Target").GetComponent<Rigidbody2D> ();

		finderBound = new Vector2 (finder.GetComponent<BoxCollider2D> ().bounds.extents.x+0.1f, finder.GetComponent<BoxCollider2D> ().bounds.extents.y+0.1f);

		layerMask = 1 << LayerMask.NameToLayer (layerName);
		//Debug.Log (layerMask.value);
	}



	
	// Update is called once per frame
//	void Update () {
//
//		//finder.velocity = Vector2.right;
//		hits = Physics2D.LinecastAll (finder.position, target.position,layerMask);
//
//		if(hits.Length>0){
//			Debug.Log (hits.Length);
//			for (int i = 0; i < hits.Length; i++) {
//				Debug.Log (hits [i].transform.name);
//				if (hits [i].transform.name != target.name) {
//					
//				}
//			}
//		}
//
//		
//	}



	void Update () {

		//finder.velocity = Vector2.right;
		hit = Physics2D.Linecast (finder.position+finderBound, target.position,layerMask);

		if(hit){
			//Debug.Log (hit.transform.name);
			if (hit.transform.name == target.name) {
				
				Debug.DrawLine (transform.position, hit.transform.position,Color.blue);
			} else {


				
				Debug.DrawLine (transform.position, hit.transform.position,Color.red);
				Transform[] childs = hit.transform.gameObject.GetComponentsInChildren<Transform>();
				for (int i = 0; i < childs.Length; i++) {
					//if(childs[i].tag.Equals("Node")){
					Vector2 nodePos= new Vector2(childs[i].position.x,childs[i].position.y);
					RaycastHit2D cantSee = (Physics2D.Linecast (finder.position+finderBound, childs[i].position));
					Debug.Log(childs[i].tag);
					if(childs[i].CompareTag("Node")&& !cantSee){
						Debug.DrawLine (finder.position, childs[i].transform.position, Color.cyan);
					}
				}
			
			}

			}
		}



}
