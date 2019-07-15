using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridGen : MonoBehaviour {

	public GameObject Cube;
	Material cubeIdle;
	// Use this for initialization
	void Start ()
	{
		gridCreator(10,7);

	}

	// Create a sizeX by sizeY by sizeZ prism with random cube in it
	void gridCreator(int sizeX, int sizeZ)
	{
		for(int i = -10; i < sizeX; i++)
		{
			for(int j = -7; j < sizeZ; j++)
			{
					CreateCube (i,j); // Call the CreateCube function to instantiate a cube
			}
		}
	}

	// Create a Cube at the inputted position with a texture matching the blockType
	void CreateCube(int _posX, int _posZ)
	{
		// Instantiate a new cube at the inputted position, facing identity
		GameObject.Instantiate(Cube, new Vector3(_posX, 0, _posZ), Quaternion.identity);
	}
}
