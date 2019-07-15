using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlight : MonoBehaviour {
	
	private Color basicColor = Color.green;
	private Color hoverColor = Color.red;
	private Renderer renderer;

	void Start() {
		renderer = GetComponent<Renderer>();
		renderer.material.color = basicColor;
	}

	void OnMouseEnter() {
		renderer.material.color = hoverColor;
	}

	void OnMouseExit() {
		renderer.material.color = basicColor;
	}
}
