using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
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

        ModifyGravity(KeyCode.LeftArrow, -gravityForce, 0, GravityState.left);
        ModifyGravity(KeyCode.RightArrow, gravityForce, 0, GravityState.right);
        ModifyGravity(KeyCode.UpArrow, 0, gravityForce, GravityState.up);
        ModifyGravity(KeyCode.DownArrow, 0, -gravityForce, GravityState.down);


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
            timer = 0f;
        }
    }
}
