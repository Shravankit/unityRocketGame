using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rigidBody;
    [SerializeField] float thrust = 50f;
    [SerializeField] float rotationThrust = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessRotation();
    }

    void ProcessInput()
    {
        // Input.GetKey(KeyCode.Space);
        if(Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }
    }
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotationMethod(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotationMethod(-rotationThrust);
        }
    }

    private void RotationMethod(float RotationThisFrame)
    {
        rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.left * RotationThisFrame * Time.deltaTime);
        rigidBody.freezeRotation = false;
    }
}
