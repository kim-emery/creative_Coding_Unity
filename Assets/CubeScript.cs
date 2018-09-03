using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {
    //we can create a public property
    //start and update can access this as it is public and not local
    //public Vector3 spinSpeed = new Vector3(.1f,.1f,.1f);
    public Vector3 spinSpeed = new Vector3(0, 0, 0); //vector3.zero - we want to spice things up

    // note: if we want to rotate in a counter-clockwise direction we can just have negative axis
    public Vector3 spinAxis = new Vector3(0, 1, 0); //vector3.up
    //public Vector3 spinAxis = new Vector3(1, 0, 0);
    //public Vector3 spinAxis = new Vector3(0, 0, 1); //z-axis

    public float rotateSpeed = 1.0f;

    // Use this for initialization - called one time when unity is fired up
    void Start () {
        //put transform settings that were made through the editor, but explicity script it
        //code it procedurally

        //-- -- SetSize(2.0f); // yay code reuse!!
        // -- dont do this normaly this.transform.position = new Vector3(0, 5, 3); //needs x y and z
        // localScale is used for ... 
        //this.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);


        
        //spinSpeed = new Vector3(1,1,1);
        //randomizing below
        spinSpeed = new Vector3(Random.value, Random.value, Random.value);

        //emphasixe on spin axis
        spinAxis = Vector3.up; // we have this already, but make sure it comes from
        //try and get the x wobble
        //we want a number from 0 to 1, but what if weant 1 to negative one
        // we specifically overwrite (using get and set) we are shifting x slightly
        //we also dampen it by multiplyin it by .1f (reduce the amount)
        spinAxis.x = (Random.value - Random.value) * .1f; // min it can be is -1 and highest value is +1

		
	}


    //now lets create a public function called SetSize, external functions can call this too
    public void SetSize(float size)
    {
        //needs to be called to use
        //we want a cube so only one number as input
        this.transform.localScale = new Vector3(size, size, size);
        //not called internally yet
    }

    // Update is called once per frame
    void Update () {
        //make it spin using the rotate command
        //we put the degrees in here, it is degree per framerate 
        //this.transform.Rotate(.1f, .1f, .1f); //tell unity we are working with floats
        this.transform.Rotate(spinSpeed);
        // we could have given the three values above as a "collection" of 3 values, by using the Vector3

        // rotating around another point
        // what it is rotating atounf - origin, where is my axis pointing, and how fast (1 degree a second)
        this.transform.RotateAround(Vector3.zero, spinAxis, rotateSpeed); //ned vector of what we are rotating arounf
    }
}
