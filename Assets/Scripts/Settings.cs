using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;
using UnityEngine.XR.Management;

public class Settings : MonoBehaviour
{
    public bool ActivateVR;
    public GameObject LeftController;
    public GameObject RightController;
    public GameObject UI;
    public GameObject UI_HOLDER_VR;
    public GameObject UI_HOLDER_2D;
    public Camera VRCamera;
    public Camera Camera2D;
    private bool isVRinit=false;
    
    //UI SETTINGS
    private int color_parameter=0;
    private int color_palette=0;
    private int color_mode=0;
    private int camera = 0;

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
            VRCamera.enabled=ActivateVR;
            Camera2D.enabled=!ActivateVR;
            // LeftController.SetActive(ActivateVR);
            // RightController.SetActive(ActivateVR);

            if(ActivateVR==false){
                if(isVRinit==true){
                    StopXR();
                    isVRinit=false;
                }
                UI.transform.SetParent(UI_HOLDER_2D.transform,false);
                UI.transform.localPosition=new Vector3(0.0f,0.0f,0.0f);
                UI.transform.localEulerAngles=new Vector3(0.0f,0.0f,0.0f);
                LeftController.transform.position=new Vector3(0.0f,-100.0f,0.0f);
                RightController.transform.position=new Vector3(0.0f,-100.0f,0.0f);
                GameObject.Find("UI").GetComponent<Canvas>().worldCamera=Camera2D;
            }
            else{
                if(isVRinit==false){
                StartXR();
                isVRinit=true;
                }
                UI.transform.SetParent(UI_HOLDER_VR.transform,false);
                UI.transform.localPosition=new Vector3(0.0f,0.0f,0.0f);
                UI.transform.localEulerAngles=new Vector3(0.0f,0.0f,0.0f);
                GameObject.Find("UI").GetComponent<Canvas>().worldCamera=VRCamera;
            }
    }
      Coroutine StartXR()
    {
        return StartCoroutine(startVRRoutine());
        IEnumerator startVRRoutine()
        {
            // Add error handlers for both Instance and Manager
            var xrManager = XRGeneralSettings.Instance.Manager;
            if (!xrManager.isInitializationComplete)
                yield return xrManager.InitializeLoader();
            if (xrManager.activeLoader != null)
                xrManager.StartSubsystems();
            // Add else with error handling
        }
    }

 
    void StopXR()
    {
      var xrManager = XRGeneralSettings.Instance.Manager;
      if (!xrManager.isInitializationComplete)
        return; // Safety check
      xrManager.StopSubsystems();
      xrManager.DeinitializeLoader();
    }

//SETTER
public void set_color_parameter(int value){
    color_parameter=value;
}
public void set_color_palette(int value){
    color_palette=value;
}
public void set_color_mode_absolute(){
    color_mode=0;
}
public void set_color_mode_relative(){
    color_mode=1;
}
public int get_color_mode(){
    return color_mode;
}

//GETTER
public Camera get_camera(){
    if(ActivateVR == true){
        return VRCamera;
    }
    else{
        return Camera2D;
    }
}
public int get_color_parametre(){
    return color_parameter;
}
public int get_color_palette(){
    return color_palette;
}
}
