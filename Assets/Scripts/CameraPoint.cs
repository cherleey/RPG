using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour {

    public bool mouseLock = true;
    public float cameraRotationSpeed = 100.0f;
    public float screenMovingSpeed = 20f;

    float inputCameraRotateRight = 0.0f;
    float inputCameraRotateLeft = 0.0f;
    float inputHorizontal = 0f;
    float inputVertical = 0f;
    bool isTopView = false;
    bool inputViewMode;
    Vector3 normalVec;

    Transform characterTransform = null;
    GameObject mainCamera = null;

    // Use this for initialization
    void Start () {
        characterTransform = GameObject.Find("RPG-Character").GetComponent<Transform>();
        mainCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = new Vector3(characterTransform.position.x, characterTransform.position.y + 1f, characterTransform.position.z - 1f);
        isTopView = mainCamera.GetComponent<MainCamera>().isTopView;

        if (!isTopView)
            transform.position = pos;

        Inputs();
        MouseLock();
        MovingScreenWithMouse();
        MovingScreenWithKeyboard();
    }

    void Inputs()
    {
        inputCameraRotateRight = Input.GetAxisRaw("CameraRotateRight");
        inputCameraRotateLeft = Input.GetAxisRaw("CameraRotateLeft");
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        inputViewMode = Input.GetButtonDown("ViewMode");
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
        if (Cursor.lockState != CursorLockMode.Confined || !isTopView)
            return;
        
        if (Input.mousePosition.x <= 1f)
        {
            normalVec = Vector3.Normalize(transform.forward) * screenMovingSpeed * Time.deltaTime;
            transform.position -= normalVec;
        }

        if (Input.mousePosition.x >= Screen.width - 1f)
        {
            normalVec = Vector3.Normalize(transform.forward) * screenMovingSpeed * Time.deltaTime;
            transform.position += normalVec;
        }

        if (Input.mousePosition.y <= 1f)
        {
            normalVec = Vector3.Normalize(transform.right) * screenMovingSpeed * Time.deltaTime;
            transform.position += normalVec;            
        }

        if (Input.mousePosition.y >= Screen.height - 1f)
        {
            normalVec = Vector3.Normalize(transform.right) * screenMovingSpeed * Time.deltaTime;
            transform.position -= normalVec;
        }
    }

    void MovingScreenWithKeyboard()
    {
        if (inputCameraRotateRight != 0.0f)
            transform.RotateAround(characterTransform.position, Vector3.up, -cameraRotationSpeed * Time.deltaTime);

        if (inputCameraRotateLeft != 0.0f)
            transform.RotateAround(characterTransform.position, Vector3.up, cameraRotationSpeed * Time.deltaTime);

        if (Cursor.lockState != CursorLockMode.Confined)
            return;

        if (inputHorizontal != 0f)
        {
            normalVec = Vector3.Normalize(transform.forward) * screenMovingSpeed * Time.deltaTime;
            transform.position += normalVec * inputHorizontal;
        }

        if (inputVertical != 0f)
        {
            normalVec = Vector3.Normalize(transform.right) * screenMovingSpeed * Time.deltaTime;
            transform.position -= normalVec * inputVertical;
        }
    }

    void ChangeViewMode()
    {
    }
}
