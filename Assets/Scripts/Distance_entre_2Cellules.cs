using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_entre_2Cellules : MonoBehaviour{

    public Camera camera;
    public SelectCellule autreScriptSelect;
    
    void Update(){
        
        Settings settings = GameObject.Find("Settings").GetComponent<Settings>();
        camera = settings.get_camera();
        
        autreScriptSelect = GameObject.FindObjectOfType(typeof(SelectCellule)) as SelectCellule; //Permet de trouver le script qui se trouve sur le main camera
        //SelectCellule selectcell = GameObject.Find("SelectCellule").GetComponent<SelectCellule>();

        if(autreScriptSelect.Cellfav != null){ //si on a selectionne une cellule en favoris
            Transform Cell1 = autreScriptSelect.Cellfav; //on recupere la variable Cellfav du script SelectCellule dans une varaible Cell1
        
            if (Input.GetMouseButtonDown(1)){ // si on fait clic droit de la souris
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out hit)) {
                    print("Les coordonnée de la première cellule" +Cell1.transform.position);
                    Transform Cell2 = hit.collider.transform;
                    print("Les coordonnée de la deuxième cellule" +Cell2.transform.position);
                    /*Affichage d'un trait
                    */
                    float dist = distance2Cellules(Cell1,Cell2);
                    print("Distance entre la première cellule "+Cell1.name+" et la deuxième cellule "+Cell2.name+" est : "+dist+" microm");
                    
                }
            }
        }
        else{
            print("You don't select a favorite cell!");
        }  

    }

/*Specification : 
    Entree : deux Cellule de type Transform, Cellule1 et Cellule2
    Sortie : un float distance qui est la distance entre les deux cellules en parametres
    Cette fonction cree un vecteur position pour chacune des cellules et calcule la distance a partir
    de ces deux vecteurs
*/		
public float distance2Cellules(Transform Cellule1,Transform Cellule2){
    Vector3 coordonnees1 = new Vector3(Cellule1.transform.position.x,Cellule1.transform.position.y,Cellule1.transform.position.z);
    Vector3 coordonnees2 = new Vector3(Cellule2.transform.position.x,Cellule2.transform.position.y,Cellule2.transform.position.z);
    float distance = Vector3.Distance(coordonnees1, coordonnees2);
    return distance;
        
}

}
