using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTwo : MonoBehaviour {
    public Transform target;
    private float noTurn = 0.1f;
    private float factor = 150.0f;
    private Vector3 center;
    private Vector3 ship;
    public int shipSpeed;
    public int shipMaxSpeed;
 

    private float distanceToFollow;
    private float shipRotX;
    private float shipRotY;

    // Use this for initialization
    void Start () {
        center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
	}

    // Update is called once per frame
    void Update() {
        
        float speed = 0.2f;
        Vector3 delta = (Input.mousePosition - center) / Screen.height;
        Debug.Log(delta);
      
        shipRotX += Input.GetAxis("Mouse X") * 0.20f;
        shipRotY += Input.GetAxis("Mouse Y") * 0.20f;
        ship.x = shipRotX;
        ship.y = shipRotY;

        if (delta.y > noTurn)
           transform.Rotate((delta.y + noTurn) * Time.deltaTime * factor, 0, 0);
        
        if (delta.y < -noTurn)
           transform.Rotate((delta.y - noTurn) * Time.deltaTime * factor, 0, 0);
      

        if (delta.x > noTurn)
            transform.Rotate(0, (delta.x - noTurn) * Time.deltaTime * factor, 0);

        
        if (delta.x < -noTurn)
            transform.Rotate(0, (delta.x + noTurn) * Time.deltaTime * factor, 0);

        
        /*if (Input.mousePosition.x == 0.0 && Input.mousePosition.y == 0.0)
        {
            
            //transform.GetChild(1).Rotate(-ship.normalized * .015f * (ship.sqrMagnitude + 500) * (1 + speed / shipMaxSpeed) * Time.fixedDeltaTime);
        }*/

        


        /*ship -= ship.normalized * ship.sqrMagnitude * .08f * Time.fixedDeltaTime;

        transform.GetChild(1).Rotate(ship * Time.fixedDeltaTime);*/

        transform.GetChild(0).Rotate(shipRotY, shipRotX, 0);

        shipRotY *= 0.9f;
        shipRotX *= 0.9f;

        float sqrOffset = transform.GetChild(0).localPosition.sqrMagnitude;
        Vector3 offsetDir = transform.GetChild(0).localPosition.normalized;
        transform.GetChild(0).Translate(-offsetDir * sqrOffset * 20 * Time.fixedDeltaTime);
        transform.Translate(-(offsetDir * sqrOffset * 50 + transform.GetChild(0).forward * shipSpeed) * Time.fixedDeltaTime, Space.World);
        
    }
}
