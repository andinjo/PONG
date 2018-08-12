using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddleArrow : MonoBehaviour {

    public float speed = 30;

    private void FixedUpdate() {
        float vertPress = Input.GetAxisRaw("Vertical Arrow");
        GetComponent<Rigidbody2D>().velocity = 
            new Vector2(0, vertPress) * speed; 
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
