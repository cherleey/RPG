using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayableCharater : MonoBehaviour {

    Animator animator = null;
    float inputMouseLeftClick = 0.0f;
    float inputMouseRightClick = 0.0f;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        InputBtn();
        Move();
    }

    void InputBtn()
    {
        inputMouseLeftClick = Input.GetAxisRaw("MouseLeftClick");
        inputMouseRightClick = Input.GetAxisRaw("MouseRightClick");
    }

    void Move()
    {
        if(inputMouseRightClick != 0.0f)
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                float runSpeed = 100.0f;
                Rigidbody rb = GetComponent<Rigidbody>();
                float velocityXel = transform.InverseTransformDirection(rb.velocity).x;
                float velocityZel = transform.InverseTransformDirection(rb.velocity).z;

                agent.destination = hit.point;
            }
        }
    }
}
