using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour {

    Transform characterTransform = null;

	// Use this for initialization
	void Start () {
        characterTransform = GameObject.Find("RPG-Character").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = new Vector3(characterTransform.position.x, characterTransform.position.y + 1f, characterTransform.position.z - 1f);
        transform.position = pos;
	}
}
