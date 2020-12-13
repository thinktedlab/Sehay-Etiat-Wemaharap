using UnityEngine;
using System.Collections;

public class Thumb : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Tile") {
			var tile = other.gameObject.GetComponent<Tile>();
			tile.touched = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Tile") {
			var tile = other.gameObject.GetComponent<Tile>();
			tile.touched = false;
		}
	}
}
