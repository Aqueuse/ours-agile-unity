using UnityEngine;
using System.Collections.Generic;

public class OursController : MonoBehaviour {
    public Transform cameraPivot;
    public Transform camera;

    private float heading;

    private Vector2 input;

    private Animator _oursAnimator;
    private float _Speed = 6;
    private float _Rotate = 80;

    private static readonly int idle = Animator.StringToHash("idle");
    private static readonly int walk = Animator.StringToHash("walking");
    private static readonly int walkLeft = Animator.StringToHash("walkingLeft");
    private static readonly int walkRight = Animator.StringToHash("walkingRight");
    private static readonly int waving = Animator.StringToHash("waving");

    private Rigidbody _oursRigidbody;

    private void Start() {
        print("hello robours");
        _oursAnimator = GetComponent<Animator>();
        _oursRigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            _oursAnimator.SetTrigger(waving);
        }



        // switch cam 
        List<GameObject> cameraModes = new List<GameObject>();
        //cameraModes.Add();

        

        heading += Input.GetAxis("Mouse X")*Time.deltaTime*180;
        cameraPivot.rotation = Quaternion.Euler(0, heading, 0);

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        Vector3 cameraForward = camera.forward;
        Vector3 cameraRight = camera.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        transform.position += (cameraForward * input.y + cameraRight * input.x) * Time.deltaTime * 5;
    }
}