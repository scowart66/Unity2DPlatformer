using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {
    public float speed = .3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(this.transform.localScale.x * speed, GetComponent<Rigidbody2D>().velocity.y);
	}
}
