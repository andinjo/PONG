using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMusic : MonoBehaviour {
	public void DestroyTheMusic () {
        Destroy(GameObject.Find("Music"));
	}
}
