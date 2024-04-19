using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform viewPoint;
    public float mouseSensitivity = 2f;
    private Vector2 mouseInput;
    private float eulerX;
    private float eulerY;
    private float eulerZ;
    private float viewPointVerticalRotation;
    private float vertRotationStore;


    // Start is called before the first frame update
    void Start() {
        //eulerX = transform.rotation.eulerAngles.x;
        eulerX = 0f;
        eulerZ = 0f;
        vertRotationStore = 0f;
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log("Mouse Input X: " + Input.GetAxisRaw("Mouse X"));

        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        eulerY = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(eulerX, eulerY + mouseInput.x, eulerZ);

        //viewPointVerticalRotation = viewPoint.rotation.eulerAngles.x - mouseInput.y;
        //viewPoint.rotation = Quaternion.Euler(viewPointVerticalRotation, viewPoint.rotation.eulerAngles.y, viewPoint.rotation.eulerAngles.z);
        vertRotationStore = vertRotationStore - mouseInput.y;
        vertRotationStore = Mathf.Clamp(vertRotationStore, -30f, 30f);
        viewPoint.rotation = Quaternion.Euler(vertRotationStore, viewPoint.rotation.eulerAngles.y, viewPoint.rotation.eulerAngles.z);
    }
}
