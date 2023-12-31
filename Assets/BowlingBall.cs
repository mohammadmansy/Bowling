using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float force;
    private List<Vector3> pinPositions;
    private List<Quaternion> pinRotations;
    private Vector3 ballPositon;
    private void Start()
    {
        var pins = GameObject.FindGameObjectsWithTag("Pin");
        pinPositions = new List<Vector3>();
        pinRotations = new List<Quaternion>();
        foreach (var pin in pins)
        {
            pinPositions.Add(pin.transform.position);
            pinRotations.Add(pin.transform.rotation);

        }
        ballPositon = GameObject.FindGameObjectWithTag("Ball").transform.position;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            GetComponent<Rigidbody>().AddForce(new Vector3(force, 0, 0));
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1),ForceMode.Impulse);
        if (Input.GetKeyUp(KeyCode.RightArrow))
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1), ForceMode.Impulse);
        if (Input.GetKeyUp(KeyCode.R))
        {
            var pins = GameObject.FindGameObjectsWithTag("Pin");
            for (int i = 0; i < pins.Length; i++)
            {
                var pinPhysics = pins[i].GetComponent<Rigidbody>();
                pinPhysics.velocity = Vector3.zero;
                pinPhysics.position = pinPositions[i];
                pinPhysics.rotation = pinRotations[i];
                //pinPhysics.velocity = Vector3.one;
                pinPhysics.angularVelocity = Vector3.zero;

                var ball = GameObject.FindGameObjectWithTag("Ball");
                ball.transform.position = ballPositon;
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
        }

            if (Input.GetKeyUp(KeyCode.B))
            {
                var ball = GameObject.FindGameObjectWithTag("Ball");
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                ball.transform.position = ballPositon;
            }
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Application.Quit();
            }
        
    }
        //private void OnCollisionEnter(Collision collision)
        //{
        //if (collision.gameObject.tag == "Pin")
        //{
        //    GetComponent<AudioSource>.play();
        //}
    }



