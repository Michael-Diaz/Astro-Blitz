using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody2D astroBody;

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

        Debug.Log("Player Pos: " + playerPos + ", Mouse Pos: " + mousePos);

        Vector2 distance = new Vector2(mousePos.x - playerPos.x, mousePos.y - playerPos.y);
        float angle = (Mathf.Atan(distance.y / distance.x) * Mathf.Rad2Deg);

        Debug.Log("Angle: " + angle);

        Quaternion rotation;
        if(mousePos.x < playerPos.x)
            rotation = Quaternion.Euler(0, 0, angle + 90);
        else
            rotation = Quaternion.Euler(0, 0, angle - 90);
        astroBody.MoveRotation(rotation);

        if(Input.GetButtonDown("Fire1"))
        {
            //gotta move the guy n shit
        }
    }
}
