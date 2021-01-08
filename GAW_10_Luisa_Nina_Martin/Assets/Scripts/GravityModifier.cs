using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    public Rigidbody player;

    public Vector3 gravity;
    public float gravityForce = 9.81f;

    public float gravityChangeTime = 30f;

    public static float timer = 1.5f;
    public bool allHaveCollided;
    public static bool switchingGravity;

    public List<MagneticObjects> magneticObjects;

    public enum GravityState { down, up, left, right }

    public static GravityState currentGravity;

    void Start()
    {
        Physics.gravity = new Vector3(0, -gravityForce, 0);
        gravity = Physics.gravity;
    }


    void FixedUpdate()
    {
        Physics.gravity = gravity;
        timer += Time.deltaTime;

        ModifyGravity(KeyCode.A, -gravityForce, 0, GravityState.left);
        ModifyGravity(KeyCode.D, gravityForce, 0, GravityState.right);
        ModifyGravity(KeyCode.W, 0, gravityForce, GravityState.up);
        ModifyGravity(KeyCode.S, 0, -gravityForce, GravityState.down);


        for (int i = 0; i < magneticObjects.Count; i++)
        {
            if (magneticObjects[i].collided)
                allHaveCollided = true;
            else
            {
                i += magneticObjects.Count;
                allHaveCollided = false;
            }
        }
    }

    void ModifyGravity(KeyCode Key, float x, float y, GravityState gravityState)
    {
        if (Input.GetKeyDown(Key) && ((currentGravity != gravityState && allHaveCollided) || timer > gravityChangeTime))
        {
            switchingGravity = true;
            currentGravity = gravityState;
            gravity = new Vector3(x, y, 0);
            timer = 0;
        }
    }
}
