using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    private Rigidbody rbPlayer;
    public float playerSpeed = 5f;
    public float offset = 0f;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public Vector2 screenSpace = new Vector2(Screen.width, Screen.height);
    public GameObject pivot;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        PlayerMovement();
    }

    void PlayerMovement()
    {
        transform.Translate(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime, 0f);
    }

    void LookAtMouse()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        pivot.transform.rotation = Quaternion.Euler(0,0,rotZ + offset);
    }
}