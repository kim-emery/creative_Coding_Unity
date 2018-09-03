using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sketch : MonoBehaviour {
    //this is to access and store the spincube prefab that 
    //we are going to access from outside
    // we can drop any gameobject we want in this 
    public GameObject myPrefab; 

	// Use this for initialization
	void Start () {

        int totalCubes = 30; //start from zer0 we end up with 6 cubes even tho i <6
        float totalDistance = 2.9f; //since we are starting at zero the distance to the next wall in any direction will be 5.
        //needs to be smaller since we are starting at 2 now
        //LINEAR DISTRIBUTION
        /*
        for (int i = 0; i < totalCubes; i++)
        {
            float percentage = i / (float)totalCubes; //integer/integer we won't get a fraction, u will get zero since both are integers, integer division will occur as integers will truncate, we need to cast one of these into float to get a float (the float as variable happens after the operation return)

            // basically divies up the totalDistance based ont he amount of ccubes
            // we should have more curved (easing) function so that the big stuff has more gaps

            float x =  (percentage * totalDistance) ; //so no matter how many cubes we can add calculate the space however can cause overlap still
            float y = 3.0f;
            float z = 0.0f; // 1 * 1.2f; 
            // basic variable called newCube, 1:what we want to instantiate, 2: where do we want to instantiate it, 3: rotation - what original orientation fo you want
            // Quanternian.identity -- normal/default orientation in space
            //explicit casting
            var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity); //need to feed instantiate function something to setup
                                                                                                        //fed from public GameObject Variable -- which has yet to store anything possibly for code reuse
            //tempstore so we can refer to it, the instantiate deals with this, I wonder iw tey name styff                                                                                        // this variable is to store, will just be generated into the empty gameobject

            // have to talk to the spincubes code in order to change the size/scale of the generated spincube
            //use getcompnent to select the script component
            // objects by itself dont understand getcomponent
            //since we explicitly cast we can access using gfunction for unity
            newCube.GetComponent<CubeScript>().SetSize(1.0f - percentage); //from subtracting we get the inverse of the percentage (which is from zero to one)
            newCube.GetComponent<CubeScript>().rotateSpeed = 0;// Random.value; - so the smaller they get, the faster they get
            //we fetch the component using getcompent function that takes no inputs basically like  a pointer
            //sitting on y-axis
            // we could prob store reference

            // zeroing out the rotation speed, so we can look at some position algorithms
        }
        */



        for (int i = 0; i < totalCubes; i++)
        {

            float percentage = i / (float)totalCubes;

            // we can use "get sine of 90 degrees times our percentage so at 100% we get one and at 0 we get 0"
            // however computer doesnt understand 90 degrees,
            float sin = Mathf.Sin(percentage * Mathf.PI/2); //90 degrees

            float x = 1.8f + sin * totalDistance; //because I placed something at origin that is at least 1.5f in diameter, have to at least add 2
            float y = 5.0f; //just we can compare easily and see this visually
            float z = 0.0f;
            
            var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity); 
            newCube.GetComponent<CubeScript>().SetSize(0.45f * (1.0f - percentage)); //we damp/clamp it by giving it a max value times what it would have been (because we get given a percentage anyway) -- note get use to scaling
            newCube.GetComponent<CubeScript>().rotateSpeed =  0.2f + percentage * 4.0f; // just a minus sign if we want it to rotate in the other direction
        }//should add a base speed since first cube is going to be 0 percentage and thus have zero rotation
        //if we use percetage x percentage, the smaller they are (the further they are from 0,0) the faster they are, exponentially


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
