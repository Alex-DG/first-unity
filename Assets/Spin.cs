using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spin : MonoBehaviour {

	private float rotationRate = 3.0f;

	void Start() {
			
	}

	void Update () {

		// rotate at 90 degrees per second
		transform.Rotate(Vector3.up * Time.deltaTime*90);

		// get the user touch inpun
		foreach (Touch touch in Input.touches) {
			Debug.Log("Touching at: " + touch.position);

			if (touch.phase == TouchPhase.Began) {
				Debug.Log("Touch phase began at: " + touch.position);
			} else if (touch.phase == TouchPhase.Moved) {
				Debug.Log("Touch phase Moved");
				// Rotate on touch object
				transform.Rotate (touch.deltaPosition.y * rotationRate, -touch.deltaPosition.x * rotationRate, 0, Space.World);
			} else if (touch.phase == TouchPhase.Ended) {
				Debug.Log("Touch phase Ended");
				// Pick random color on touch end
				Color randomColor = new Color( Random.value, Random.value, Random.value, 1.0f ); // Pick random color
				gameObject.GetComponent<Renderer>().material.color = randomColor; // Update cube's color
			}
		}
	}
}