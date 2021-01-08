using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticObjects : MonoBehaviour
{
    public bool collided;
    Rigidbody rb;

    private void Start()
    {
        collided = true;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GravityModifier.switchingGravity)
        {
            Debug.Log($"Turning collided off from {rb.gameObject.name}");
            collided = false;
            Invoke("TurnSwitchingGravityToFalse", 0.1f);
        }

        if(rb.velocity.magnitude < 0.01f && GravityModifier.timer > 0.1f)
        {
            collided = true;
        }
    }

    void TurnSwitchingGravityToFalse()
    {
        GravityModifier.switchingGravity = false;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.name);
    //        if ((collision.gameObject.tag == "Horizontal" && collision.gameObject.transform.position.y == lastCollision.gameObject.transform.position.y) ||
    //        (collision.gameObject.tag == "Vertical" && collision.gameObject.transform.position.x == lastCollision.gameObject.transform.position.x))
    //        {

    //        }
    //        else
    //        {
    //            collided = true;
    //            lastCollision = collision.gameObject;
    //        }
    //}
}
