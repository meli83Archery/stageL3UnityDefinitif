using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_entre_2Cellules : MonoBehaviour{

    public Camera camera;
    public SelectCellule autreScriptSelect;
    
    void Update(){
        
        Settings settings = GameObject.Find("Settings").GetComponent<Settings>(); //Retrieving the Settings script to use its methods 
        camera = settings.get_camera();
        
        autreScriptSelect = GameObject.FindObjectOfType(typeof(SelectCellule)) as SelectCellule; //Allows you to find the SelectCellule script placed on an object

        if(autreScriptSelect.Cellfav != null){ //if we select a favorite cell
            Transform Cell1 = autreScriptSelect.Cellfav; //We get the Cellfav variable from the SelectCell script in a Cell1 variable
        
            if (Input.GetMouseButtonDown(1)){ //if right button pressed of the mouse
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out hit)) {
                    print("The coordinates of the first cell" +Cell1.transform.position);
                    Transform Cell2 = hit.collider.transform;
                    print("The coordinates of the second cell" +Cell2.transform.position);
                    /*
                        Display of a line
                    */
                    float dist = distance2Cellules(Cell1,Cell2);
                    print("Distance between the first cell "+Cell1.name+" and the second cell "+Cell2.name+" is : "+dist+" microm");
                }
            }
        }
        else{
            print("You don't select a favorite cell!");
        }  

    }

/*
Specification : 
    Entrance : Two Transform Cells type, Cellule1 et Cellule2
    Exit : a float distance which is the distance between the two cells in settings
    this function creates a 
    Cette fonction cree a position vector for each cell and calculate the distance from of these two vectors
*/		
public float distance2Cellules(Transform Cellule1,Transform Cellule2){
    Vector3 coordonnees1 = new Vector3(Cellule1.transform.position.x,Cellule1.transform.position.y,Cellule1.transform.position.z);
    Vector3 coordonnees2 = new Vector3(Cellule2.transform.position.x,Cellule2.transform.position.y,Cellule2.transform.position.z);
    float distance = Vector3.Distance(coordonnees1, coordonnees2);
    return distance;
        
}

}
