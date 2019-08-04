using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mSpeed = 10f;
    public float turnSpeed= 100f ;
    public Animator anim;

    private Rigidbody rb;
    private Vector3 change;
    private Vector3 m_Movement;
    private Quaternion mRot = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;

        change.x = Input.GetAxisRaw("Horizontal");
        change.z = Input.GetAxisRaw("Vertical");

        m_Movement.Set(change.x, 0f, change.z);
        m_Movement.Normalize();

        rb.MovePosition(rb.position + m_Movement * mSpeed);

        Vector3 desiredDir = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        mRot = Quaternion.LookRotation(desiredDir);
        rb.MoveRotation(mRot);


        anim.SetFloat("isWalking", Mathf.Max (Mathf.Abs(Input.GetAxis("Horizontal")), Mathf.Abs(Input.GetAxis("Vertical"))));
       

    }
}
