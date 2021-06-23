using UnityEngine;
using System.Collections;

public class SelectCellule : MonoBehaviour {
    public Camera camera;
    public Transform Cellfav;
    
    
void Update(){

        Settings settings = GameObject.Find("Settings").GetComponent<Settings>(); //Retrieving the Settings script to use its methods
        camera = settings.get_camera();


        if (Input.GetMouseButtonDown(0)){ // if left button pressed
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out hit)) {
                    
                    Cellfav = hit.collider.transform;
                    //Highlight of the object Cellfav

                    //Display of the cell description
                    foreach (var kvp in Cellfav.GetComponent<Metadata>().cell_data)
                        Debug.Log(kvp.Key + " : " + kvp.Value);
                }
            }
}

}