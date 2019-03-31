using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// MAZE PROC GEN LAB
// all students: complete steps 1-6, as listed in this file
// optional: if you have extra time, complete the "extra tasks" to do at the very bottom

// STEP 1: ======================================================================================
// put this script on a Sphere... it will move around, and drop a path of floor tiles behind it

public class Pathmaker : MonoBehaviour {

// STEP 2: ============================================================================================

	private int _floorCount = 0;
	public Transform floorPrefab;
	public Transform pathmakerSpherePrefab;
	public static int globalTileCount;
	private int _randFloorCount;
	public int randomSpawner;
	public bool spawnOK;
	public GameObject tile1;
	public GameObject tile2;
	public GameObject tile3;

	private void Start()
	{
		_randFloorCount = Random.Range(30, 60);
		spawnOK = true;
	}

	void Update () {

if (Input.GetKeyDown(KeyCode.H)) //WHY IS THE DEBUG NOT PRINTING??
		{
			SceneManager.LoadScene("mainLabScene");
			Debug.Log("Loading");
		}
			//		If counter is less than 50, then:
if (_floorCount < _randFloorCount)
		{
			float num = Random.value;

if (num < 0.25f)
			{
				transform.Rotate(0f,90f,0f);
			}
else if (num > 0.25f && num < 0.5f)
			{
				transform.Rotate(0f,-90f,0f);
			}

else if(num>=0.90 && num <= 1.0f)
			{
				Instantiate(pathmakerSpherePrefab, transform.position, Quaternion.identity);
			}

if (spawnOK == true)
{
	randomSpawner = Random.Range(1, 7);
	switch (randomSpawner)
	{
		case 1:
			Instantiate(tile1, transform.position, Quaternion.Euler(-90,0,0));
			break;
		
		case 2:
			Instantiate(tile1, transform.position, Quaternion.Euler(-90,0,0));
			break;
		case 3:
			Instantiate(tile1, transform.position, Quaternion.Euler(-90,0,0));
			break;

		case 4:
			Instantiate(tile2, transform.position, Quaternion.Euler(-90,0,0));
			break;

		case 5:
			Instantiate(tile3, transform.position, Quaternion.Euler(-90,0,0));
			break;
		case 6:
			Instantiate(tile3, transform.position, Quaternion.Euler(-90,0,0));
			break;
		case 7:
			Instantiate(tile3, transform.position, Quaternion.Euler(-90,0,0));
			break;
	}

	transform.position += transform.forward * 5;
	_floorCount++;
	globalTileCount++;
	spawnOK = true;
}
		}

else
{	
Destroy(this.gameObject);
}

if (globalTileCount > 500)
{
	Debug.Log("ENOUGH.");
	Destroy(this.gameObject);
}
		
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Tile")
		{
			spawnOK = false;
			Debug.Log("Trigger");
		}
		/*else
		{
			spawnOK = true;
		}*/
	}
} // end of class scope

// MORE STEPS BELOW!!!........




// STEP 3: =====================================================================================
// implement, test, and stabilize the system

//	IMPLEMENT AND TEST:
//	- save your scene!!! the code could potentially be infinite / exponential, and crash Unity
//	- put Pathmaker.cs on a sphere, configure all the prefabs in the Inspector, and test it to make sure it works
//	STABILIZE: 
//	- code it so that all the Pathmakers can only spawn a grand total of 500 tiles in the entire world; how would you do that?
//	- (hint: declare a "public static int" and have each Pathmaker check this "globalTileCount", somewhere in your code? if there are already enough tiles, then maybe the Pathmaker could Destroy my game object



// STEP 4: ======================================================================================
// tune your values...

// a. how long should a pathmaker live? etc.
// b. how would you tune the probabilities to generate lots of long hallways? does it work?
// c. tweak all the probabilities that you want... what % chance is there for a pathmaker to make a pathmaker? is that too high or too low?



// STEP 5: ===================================================================================
// maybe randomize it even more?

// - randomize 2 more variables in Pathmaker.cs for each different Pathmaker... you would do this in Start()
// - maybe randomize each pathmaker's lifetime? maybe randomize the probability it will turn right? etc. if there's any number in your code, you can randomize it if you move it into a variable



// STEP 6:  =====================================================================================
// art pass, usability pass

// - move the game camera to a position high in the world, and then point it down, so we can see your world get generated
// - CHANGE THE DEFAULT UNITY COLORS, PLEASE, I'M BEGGING YOU
// - add more detail to your original floorTile placeholder -- and let it randomly pick one of 3 different floorTile models, etc. so for example, it could randomly pick a "normal" floor tile, or a cactus, or a rock, or a skull
//		- MODEL 3 DIFFERENT TILES IN MAYA! DON'T STOP USING MAYA OR YOU'LL FORGET IT ALL
//		- add a simple in-game restart button; let us press [R] to reload the scene and see a new level generation
// - with Text UI, name your proc generation system ("AwesomeGen", "RobertGen", etc.) and display Text UI that tells us we can press [R]



// OPTIONAL EXTRA TASKS TO DO, IF YOU WANT: ===================================================

// DYNAMIC CAMERA:
// position the camera to center itself based on your generated world...
// 1. keep a list of all your spawned tiles
// 2. then calculate the average position of all of them (use a for() loop to go through the whole list) 
// 3. then move your camera to that averaged center and make sure fieldOfView is wide enough?

// BETTER UI:
// learn how to use UI Sliders (https://unity3d.com/learn/tutorials/topics/user-interface-ui/ui-slider) 
// let us tweak various parameters and settings of our tech demo
// let us click a UI Button to reload the scene, so we don't even need the keyboard anymore!

// WALL GENERATION
// add a "wall pass" to your proc gen after it generates all the floors
// 1. raycast downwards around each floor tile (that'd be 8 raycasts per floor tile, in a square "ring" around each tile?)
// 2. if the raycast "fails" that means there's empty void there, so then instantiate a Wall tile prefab
// 3. ... repeat until walls surround your entire floorplan
// (technically, you will end up raycasting the same spot over and over... but the "proper" way to do this would involve keeping more lists and arrays to track all this data)
