using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Deadly")
        {
            OnDestroy();
        }
        if (target.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(target.gameObject);
        }
    }

    void OnDestroy()
    {
        Destroy(gameObject);
    }
}
