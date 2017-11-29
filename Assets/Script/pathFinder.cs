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
			Debug.Log (hit.transform.name);

			}
		}



}
