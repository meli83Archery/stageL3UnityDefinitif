using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SelectCellule : MonoBehaviour {
    public Camera camera;
    public Transform Cellfav;
    
    
void Update(){

        Settings settings = GameObject.Find("Settings").GetComponent<Settings>();
        camera = settings.get_camera();


        if (Input.GetMouseButtonDown(0)){ // if left button pressed
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out hit)) {
                    
                    Cellfav = hit.collider.transform;
                    //Surbrillance de l'objet

                    //Affichage de la description de la cellule
                    print("Coucou on m'a cliqué dessus");
                    foreach (var kvp in Cellfav.GetComponent<Metadata>().cell_data)
                        Debug.Log(kvp.Key + " : " + kvp.Value);
                    
                }
            }
}

}