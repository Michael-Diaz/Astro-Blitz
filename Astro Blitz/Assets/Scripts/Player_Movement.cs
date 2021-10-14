using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody2D astroBody;

    float mapBounds = 48.0f;

    // Start is called before the first frame update
    void Start()
    {
        astroBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
        Vector2 playerPos = new Vector2(astroBody.position.x, astroBody.position.y);

        Vector2 distance = new Vector2(mousePos.x - playerPos.x, mousePos.y - playerPos.y);
        float angle = (Mathf.Atan(distance.y / distance.x) * Mathf.Rad2Deg);

        Quaternion rotation;
        if(mousePos.x < playerPos.x)
            rotation = Quaternion.Euler(0, 0, angle + 90);
        else
            rotation = Quaternion.Euler(0, 0, angle - 90);
        astroBody.MoveRotation(rotation);

        Vector2 vel = astroBody.velocity;
        float speed = vel.magnitude;

        if((Mathf.Abs(playerPos.x) >= mapBounds) || (Mathf.Abs(playerPos.y) >= mapBounds))
            astroBody.AddForce((playerPos * -1) / playerPos.magnitude);
        else
        {
            if(Input.GetButton("Fire1"))
            {
                float dMagnitude = Mathf.Sqrt((distance.x * distance.x) + (distance.y * distance.y));
                astroBody.AddForce(new Vector2(distance.x / dMagnitude, distance.y / dMagnitude), ForceMode2D.Force);
            }
        }

        if (speed > 7)
            astroBody.velocity = new Vector2(7 * vel.x / speed, 7 * vel.y / speed);
    }
}