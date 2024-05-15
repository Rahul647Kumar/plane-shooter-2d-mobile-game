using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10f;
    float minX, maxX, minY, maxY;
    

    // Start is called before the first frame update
    void Start()
    {
        FindBoundaries();
    }

    void FindBoundaries()
    {
            Camera gameCamera = Camera.main;
            minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
            maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
            minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
            maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        }
    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        float newXpos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        float newYpos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newXpos, newYpos);
    }
}