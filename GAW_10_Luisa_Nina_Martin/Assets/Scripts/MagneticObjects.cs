using UnityEngine;

public class MagneticObjects : MonoBehaviour
{
    public bool collided = true;
    public Rigidbody rb;

    private void Update()
    {
        if (GravityModifier.switchingGravity)
            collided = false;

        if(rb.velocity.magnitude < 0.01f && GravityModifier.timer > 0.1f)
            collided = true;
    }
}
