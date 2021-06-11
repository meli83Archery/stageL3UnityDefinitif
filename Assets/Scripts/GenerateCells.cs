using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using System.Globalization;
public class GenerateCells : MonoBehaviour
{
    public GameObject Tissue;
	public float radius = 50.0f;
	public Material cell_material;

	public GameObject Cell_object;


    // Start is called before the first frame update
    void Start()
    {
		/*
    float x_center = (-1000.0f + 1000.0f) / 2;
	float y_center = (-1000.0f + 1000.0f) / 2;
	float z_center = (-1000.0f + 1000.0f) / 2;

	float c_radius = 8.0f;

	for (float i = 0; i < 2.0 * radius; i += 1)
	{
		for (float j = 0; j < 2.0 * radius; j += 1)
		{
			for (float k = 0; k <= 2.0 * radius * (1.0 - 0.0); k += 1)
			{
				Vector3 cell_position = new Vector3((2.0f * (i - radius) + (((j - radius) + (k - radius))% 2.0f)) * c_radius, (Mathf.Sqrt(3.0f) * ((j - radius) + ((k - radius)% 2.0f) / 3.0f)) * c_radius, c_radius * (k - radius) * Mathf.Sqrt(6.0f) * 2.0f / 3.0f);

				float distance = Mathf.Sqrt(Mathf.Pow(cell_position[0] - x_center, 2) + Mathf.Pow(cell_position[1] - y_center, 2) + Mathf.Pow(cell_position[2] - z_center, 2));
				if (distance <= radius * c_radius)
				{
					CreateCellObject(c_radius, cell_position);
				}
			}
		}
	}
*/

  var dataset = Resources.Load<TextAsset>("output");
  var dataLines = dataset.text.Split('\n'); // Split also works with simple arguments, no need to pass char[]
 
  for(int i = 1; i < dataLines.Length; i++) {
    string[] values = dataLines[i].Split(';');
	float radius=Mathf.Pow(0.62035f*float.Parse(values[5], CultureInfo.InvariantCulture),1f / 3f);
	CreateCellObject(radius, new Vector3(float.Parse(values[2], CultureInfo.InvariantCulture),float.Parse(values[3], CultureInfo.InvariantCulture),float.Parse(values[4], CultureInfo.InvariantCulture)),dataLines[0].Split(';'), values);
    // for(int d = 0; d < data.Length; d++) {
    //   print(data[d]); // what you get is split sequential data that is column-first, then row
    // }
  }
  Tissue.transform.localScale=new Vector3(0.001f,0.001f,0.001f);
  Tissue.transform.position=Tissue.transform.position+new Vector3(0.00f,1.30f,2.0f);
  	foreach (var kvp in GameObject.Find("1").GetComponent<Metadata>().cell_data)
    	Debug.Log(kvp.Key + " : " + kvp.Value);

    }

void CreateCellObject(float c_radius, Vector3 cell_position, string[] properties, string[] values){
                    GameObject cell = GameObject.Instantiate(Cell_object);
					cell.transform.name=values[1];
                    cell.transform.localScale = new Vector3(2*c_radius, 2*c_radius, 2*c_radius);
                    cell.transform.position = new Vector3(cell_position[0], cell_position[1], cell_position[2]);
                    cell.GetComponent<MeshRenderer>().material=cell_material;
					Metadata Cell_Data=cell.AddComponent<Metadata>();
					//Destroy(cell.GetComponent<SphereCollider>());
					for(int d = 0; d < properties.Length; d++) {
						Cell_Data.cell_data.Add(properties[d],values[d]);
					}
					//Debug.Log(Cell_Data.cell_data["ID"]);
                    cell.transform.parent=Tissue.transform;

}
    // Update is called once per frame
    void Update()
    {
        
    }
}
