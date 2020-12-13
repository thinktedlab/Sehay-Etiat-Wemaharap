using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public WordGame game;

	private bool mouseDown = false;
	void Update () {
		
		if (Input.touches.Length > 0) {
			
			Touch touch = Input.touches [0];

			if (touch.phase == TouchPhase.Began) {
				game.HandleTouchDown (touch.position);
			} else if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended) {
				game.HandleTouchUp (touch.position);
			} else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) {
				game.HandleTouchMove (touch.position);
			}
			
			
			game.HandleTouchMove (touch.position);	
			
			return;
		} else if (Input.GetMouseButtonDown (0)) {
			mouseDown = true;
			game.HandleTouchDown (Input.mousePosition);
		} else if (Input.GetMouseButtonUp (0)) {
			mouseDown = false;
			game.HandleTouchUp (Input.mousePosition);
		} else if (mouseDown) {
			game.HandleTouchMove (Input.mousePosition);
		}

	}
}
