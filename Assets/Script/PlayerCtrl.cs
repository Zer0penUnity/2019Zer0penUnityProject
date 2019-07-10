using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {

    public float MoveSpeed = 14f;
    public float JumpPower = 28f;
    public float RotSpeed = 8f;
    public int JumpCount = 2;

    private Transform tr;
    private Rigidbody rb;

    private float horizontal, vertical;
    private float mouseX;

    private Vector3 moveDir;

    private int jumpcount;

    private bool isGround = false;

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.CompareTag("Ground"))
        {
            isGround = true;
            jumpcount = JumpCount;
        }
    }

	void Start () {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

	}
	
	void Update () {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxisRaw("Mouse X");

        moveDir = new Vector3(horizontal, 0, vertical);

        if(Input.GetKeyDown(KeyCode.Space) && jumpcount > 0)
        {
            rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            isGround = false;
            jumpcount--;
        }

        tr.Rotate(Vector3.up * mouseX * RotSpeed * Time.deltaTime);
        tr.Translate(moveDir.normalized * MoveSpeed * Time.deltaTime);
	}
}
