using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public static int health = 100;

    private Rigidbody rb;
    private Animator animator;
    private Vector3 targetPosition;

    public float moveSpeed = 0.1f;
    float rotateVelocity;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        rb = gameObject.GetComponent<Rigidbody>();
        animator = this.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            

            if (Physics.Raycast(ray ,out hit))
            {
                targetPosition = hit.point;

                Vector3 lookPos = targetPosition - transform.position;
                lookPos.y = 0;
                Quaternion rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = rotation;

            }
   
        }

        Vector3 direction = (targetPosition - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
}
