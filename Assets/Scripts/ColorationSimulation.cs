using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;

public class ColorationSimulation : MonoBehaviour
{

    public double MaxAbsolu;
    public double MinAbsolu;
    public TMPro.TMP_Dropdown DD_Prop; //Dropdown TextMeshPro for properties

    public TMPro.TMP_Dropdown DD_Color; //Dropdown TextMeshPro for the color pallette
    public List<string> gradientName;


    /*
    Specification:
        Entrance : a sring Prop that will be the property that the user will be view
        Exit : an arry of double MinMax including the minimum and the maximum of cell values for the property Prop
        MinMaxRelatif will give the min and th max according to a particular time step
        It must be checked if in datas we use (Cell_data and output in Resources) there is no "" in files
    */
    public double[] MinMaxRelatif(string Prop){
        double[] MinMax = new double[2];

        //Checking the number of children so as not to return errors
        if(GameObject.Find("Tissue").transform.childCount > 0){

            GameObject cell = GameObject.Find("Tissue").transform.GetChild(0).gameObject;

            Metadata cell_meta = cell.GetComponent<Metadata>();
            Dictionary<string, string> dict = cell_meta.cell_data;
                
            //Initializing of the array
            MinMax[0] =  double.Parse(dict[Prop], System.Globalization.CultureInfo.InvariantCulture); //Location of min
            MinMax[1] =  double.Parse(dict[Prop], System.Globalization.CultureInfo.InvariantCulture); //Location of max


            //loop for which will iterate on the number of children
            for(int i = 1; i < GameObject.Find("Tissue").transform.childCount; i = i + 1 ){
                cell = GameObject.Find("Tissue").transform.GetChild(i).gameObject;
                cell_meta = cell.GetComponent<Metadata>();
                dict = cell_meta.cell_data;
                if(double.Parse(dict[Prop], System.Globalization.CultureInfo.InvariantCulture) <= MinMax[0]){ //if value of dict[Prop] <= min
                    MinMax[0] = double.Parse(dict[Prop], System.Globalization.CultureInfo.InvariantCulture);
                }
                if(double.Parse(dict[Prop], System.Globalization.CultureInfo.InvariantCulture) > MinMax[1]){ //if value of dict[Prop] > max
                    MinMax[1] = double.Parse(dict[Prop], System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            return MinMax;
        }
        else{ //return an array of zeros if there is no children
            MinMax[0] = 0;
            MinMax[1] = 0;
            return MinMax;
        }
    }

    /*
    Specification:
        Entrance : Two double min et max, a string valeur and a list of hex values for colors
        Exit : return a hex value  for the coloration
        This function must give a color according to its string valeur ,the list for the gradient that we choose and 
        for that it will use a function interpolation by taking the double min and max as the minimum and maximum value.
    */
    public byte ColorationCellule(double min, double max, string valeur,List<byte> ColorList){
        double valeurInDouble = double.Parse(valeur, System.Globalization.CultureInfo.InvariantCulture);
        double percentBetMinMax = (max - valeurInDouble)/(max - min);
        double percentOfList = ColorList.Count * percentBetMinMax;
        int index = (int)Math.Ceiling(percentOfList);
        return ColorList[index];
    }

    // Start is called before the first frame update
    void Start()
    {
        //Initializing the drop down of properties
        List<string> item = new List<string>();
        GameObject cell = GameObject.Find("Tissue").transform.GetChild(0).gameObject;
        Metadata cell_meta = cell.GetComponent<Metadata>();
        Dictionary<string, string> dict = cell_meta.cell_data;
        List<string> keys = dict.Keys.ToList();
        for(int i = 1; i < keys.Count; i++){
            item.Add(keys[i]);
        }
        DD_Prop.AddOptions(item);

        //Initializing the drop down of color palette
        gradientName.Add("Viridis");
        gradientName.Add("Magma");
        gradientName.Add("Plasma");
        DD_Color.AddOptions(gradientName);

    }

    // Update is called once per frame
    void Update()
    {
        GameObject cell = GameObject.Find("Tissue").transform.GetChild(0).gameObject;
        Metadata cell_meta = cell.GetComponent<Metadata>();
        Dictionary<string, string> dict = cell_meta.cell_data;
        List<string> keys = dict.Keys.ToList();

        Settings settings = GameObject.Find("Settings").GetComponent<Settings>();
        settings.set_color_parameter(DD_Prop.value +1); //+1 because the drop down begin with the index 0 but the list begin with the index 1
        int color_para = settings.get_color_parametre();
        int color_m = settings.get_color_mode();

        if(color_m == 0){
            double Min = MinAbsolu;
            double Max = MaxAbsolu;
            print("Min = "+Min + " Max ="+ Max);
        }
        else{
            double[] MinMaxR = MinMaxRelatif(keys[color_para]);
            double Min = MinMaxR[0];
            double Max = MinMaxR[1];
            print("Min = "+Min + " Max ="+ Max+" de "+keys[color_para]); //display of min and max for checking if the function MinMaxRelatif works
        }
        /*
        Here creation of a loop using the function ColorationCell and Min, Max
        
        settings.set_color_palette(DD_Color.value +1);
        int color_grad = settings.get_color_palette();
        Gradient gradChosen = grad[color_grad];

        */
    }
}
