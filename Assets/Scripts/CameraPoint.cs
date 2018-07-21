using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour {

    bool isTopView = true;
    public bool mouseLock = true;

    Transform characterTransform = null;

	// Use this for initialization
	void Start () {
        characterTransform = GameObject.Find("RPG-Character").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = new Vector3(characterTransform.position.x, characterTransform.position.y + 1f, characterTransform.position.z - 1f);

        if(!isTopView)
            transform.position = pos;

        MouseLock();
        MovingScreenWithMouse();
    }

    void MouseLock()
    {
        if (mouseLock)
            Cursor.lockState = CursorLockMode.Confined;
        else
            Cursor.lockState = CursorLockMode.None;
    }

    void MovingScreenWithMouse()
    {
        if (Cursor.lockState != CursorLockMode.Confined)
            return;

        if (Input.mousePosition.x <= 1f)
        {
            Vector3 pos = new Vector3(0f, 0f, 30f * Time.deltaTime);
            transform.position -= pos;
        }

        if (Input.mousePosition.x >= Screen.width - 1f)
        {
            Vector3 pos = new Vector3(0f, 0f, 30f * Time.deltaTime);
            transform.position += pos;
        }

        if (Input.mousePosition.y <= 1f)
        {
            Vector3 pos = new Vector3(30f * Time.deltaTime, 0f, 0f);
            transform.position += pos;
        }

        if (Input.mousePosition.y >= Screen.height - 1f)
        {
            Vector3 pos = new Vector3(30f * Time.deltaTime, 0f, 0f);
            transform.position -= pos;
        }
    }
}
