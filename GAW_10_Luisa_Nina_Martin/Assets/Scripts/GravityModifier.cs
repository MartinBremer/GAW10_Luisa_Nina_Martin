using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    public Vector3 gravity;
    public float gravityForce = 9.81f;
    public GameObject up, down, left, right;

    public float gravityChangeTime = 30f;

    public static float timer = 1.5f;
    public bool allHaveCollided;
    public static bool switchingGravity;

    public List<MagneticObjects> magneticObjects;

    public enum GravityState { Down, Up, Left, Right };

    public static GravityState currentGravity;

    void Start()
    {
        currentGravity = GravityState.Down;
        Physics.gravity = new Vector3(0, -gravityForce, 0);
        gravity = Physics.gravity;
    }


    void FixedUpdate()
    {
        Physics.gravity = gravity;
        timer += Time.deltaTime;

        ModifyGravity(KeyCode.LeftArrow, -gravityForce, 0, left, GravityState.Left);
        ModifyGravity(KeyCode.RightArrow, gravityForce, 0, right, GravityState.Right);
        ModifyGravity(KeyCode.UpArrow, 0, gravityForce, up, GravityState.Up);
        ModifyGravity(KeyCode.DownArrow, 0, -gravityForce, down, GravityState.Down);

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

    void ModifyGravity(KeyCode Key, float x, float y, GameObject particles, GravityState gravityState)
    {
        if (Input.GetKeyDown(Key) && ((currentGravity != gravityState && allHaveCollided) || timer > gravityChangeTime))
        {
            up.SetActive(false);
            down.SetActive(false);
            left.SetActive(false);
            right.SetActive(false);

            switchingGravity = true;
            currentGravity = gravityState;
            gravity = new Vector3(x, y, 0);
            particles.SetActive(true);
            timer = 0f;
        }
    }
}
