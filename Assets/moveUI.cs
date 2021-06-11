using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	private Vector3 screenPoint;
	private Vector3 offset;
		
	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
		
	void OnMouseDrag(){
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
