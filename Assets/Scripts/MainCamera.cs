using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public float cameraRotationSpeed = 100.0f;
    public float zoomSpeed = 500.0f;
    public float maxDistanceBtwCameraCharacter = 25.0f;
    public float minDistanceBtwCameraCharacter = 3.0f;

    GameObject characterObj = null;
    float inputCameraRotateRight = 0.0f;
    float inputCameraRotateLeft = 0.0f;
    float inputCameraZoom = 0.0f;
    float distanceBtwCameraCharacter = 0.0f;

    // Use this for initialization
    void Start ()
    {
        characterObj = GameObject.Find("RPG-Character");
    }
	
	// Update is called once per frame
	void Update ()
    {
        distanceBtwCameraCharacter = Vector3.Distance(transform.position, characterObj.transform.position);
        Inputs();
        CameraMove();
    }

    void Inputs()
    {
        inputCameraRotateRight = Input.GetAxisRaw("CameraRotateRight");
        inputCameraRotateLeft = Input.GetAxisRaw("CameraRotateLeft");
        inputCameraZoom = Input.GetAxis("Mouse ScrollWheel");
    }

    void CameraMove()
    {
        if (inputCameraRotateRight != 0.0f)
            transform.RotateAround(characterObj.transform.position, Vector3.up, -cameraRotationSpeed * Time.deltaTime);

        if (inputCameraRotateLeft != 0.0f)
            transform.RotateAround(characterObj.transform.position, Vector3.up, cameraRotationSpeed * Time.deltaTime);

        if (inputCameraZoom < 0.0f)
        {
            if(distanceBtwCameraCharacter <= maxDistanceBtwCameraCharacter)
                transform.position += transform.forward * inputCameraZoom * Time.deltaTime * zoomSpeed;
        }

        if (inputCameraZoom > 0.0f)
        {
            if (distanceBtwCameraCharacter >= minDistanceBtwCameraCharacter)
                transform.position += transform.forward * inputCameraZoom * Time.deltaTime * zoomSpeed;
        }
    }
}
