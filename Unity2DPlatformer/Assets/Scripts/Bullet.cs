using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public Vector2 velocity = new Vector2(5,0);
	public float distance = 5;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = velocity * transform.localScale.x;
		distance += Mathf.Abs (transform.position.x);
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (transform.position.x) > distance)
			Destroy (gameObject);
	}

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Solid"))
        {
            Destroy(gameObject);
        }
    }
}
