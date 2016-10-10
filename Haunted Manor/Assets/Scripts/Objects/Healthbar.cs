using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
	Slider healthSlider;
	GhoulController ghoulScript;
	// Use this for initialization
	void Start () {
		healthSlider = GetComponent<Slider> ();
		ghoulScript = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<GhoulController>();
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = ghoulScript.returnHealth ();
	}
}
