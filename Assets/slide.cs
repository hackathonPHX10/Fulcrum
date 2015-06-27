using UnityEngine;
using System.Collections;

public class slide : MonoBehaviour {

	public Vector2 startTouchPos; 
	public enum SwipeDirection {None,right,left}; 
	public SwipeDirection swipeType;
	public bool triggerSwipe;

	// Use this for initialization
	void Start () {
		swipeType = SwipeDirection.None;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.touchCount > 0) {
			Touch touch = Input.touches[0];
			switch (Input.GetTouch(0).phase) {
			case TouchPhase.Began:
				Debug.Log("Touch Begin");
				triggerSwipe = true;
				startTouchPos = touch.position;
				break;
			case TouchPhase.Moved:
				break;
			case TouchPhase.Ended:
				Debug.Log("Touch Ended");
				float distance = Vector2.Distance(startTouchPos, touch.position);
				Debug.Log("Distance "+distance);
				float pointX = (touch.position.x - startTouchPos.x);
				
				Debug.Log("point X "+pointX);
				
				if(pointX>0) {
					swipeType = SwipeDirection.right;
					Debug.Log("Moving Right---->");
				}
				else if(pointX<0){
					swipeType = SwipeDirection.left;
					Debug.Log("Moving Left---->");	
				}
			    break;
		    }
	    }
		if (swipeType == SwipeDirection.left) {
			transform.Translate (-20, 20, 0);
		} else if (swipeType == SwipeDirection.right) {
			transform.Translate (20, 20, 0);
		}
	}
}
