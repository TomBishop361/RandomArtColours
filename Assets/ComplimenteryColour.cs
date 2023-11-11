using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.ParticleSystemJobs;

public class ComplimenteryColour : MonoBehaviour
{
    [SerializeField] RawImage ColourComp;
    [SerializeField] RawImage UserComp1;
    [SerializeField] RawImage Colour1;
    [SerializeField] RawImage Colour2;
    [SerializeField] RawImage Colour3;
    [SerializeField] RawImage Colour4;
    float Var1;
    float Var2;
    float Var3;
    float Var4;
    public UnityEvent Comp;
    public UnityEvent SplitComp;
    public UnityEvent fvComp;
    public UnityEvent frComp;
    bool IsFiveColour;
    bool IsFourColour;
    int option;
    // Stat is called before the first frame update

    private void Start() {
        Comp.Invoke();
        CompColour();
        IsFiveColour = false;
        IsFourColour = false;
    }

    public void ReRoll() {
        DropdownInput(option);
    }

    public void DropdownInput(int val) //find out what resoultio the player wants to use
    {
        if (val == 0) {
            //competitive CSGO
            CompColour();
            Comp.Invoke();
            option = val;
}        
        if (val == 1) {
            //Valornt Split
            Var1 = 0.4166666667f;
            Var2 = 0.5833333333f;
            SplitComp.Invoke();
            option = val;
            CalculateCol();            
        }
        if (val == 2) {
            //Amogus
            Var1 = 0.08333333333f;
            Var2 = 0.9166666667f;
            SplitComp.Invoke();
            option = val;
            CalculateCol();            
        }
        if (val == 3) {
            //Minecraft Trident
            Var1 = 0.3333333333f;
            Var2 = 0.6666666667f;
            SplitComp.Invoke();
            option = val;
            CalculateCol();            
        }
        if (val == 4) {
            //Tetradic
            Var1 = 0.25f;
            Var2 = 0.5f;
            Var3 = 0.75f;
            IsFourColour = true;
            frComp.Invoke();
            option = val;
            CalculateCol();            
        }
        if (val == 5) {
            //ValorantSplit (Now With Tridents)
            Var1 = 0.4166666667f;
            Var2 = 0.5833333333f;
            Var3 = 0.3333333333f;
            Var4 = 0.6666666667f;
            IsFourColour = true;
            IsFiveColour = true;
            fvComp.Invoke();
            option = val;
            CalculateCol();            
        }
    }

    void CalculateCol() {
        float h, s, v;
        Color col = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);//////                                                                                                    
        GetComponent<RawImage>().color = col;             
        Color.RGBToHSV(new Color(col.r,col.g,col.b,col.a), out h, out s, out v);       
        Vector3 ColHSV = new Vector3 (h, s, v);
        Vector3 CompHSV1 = new Vector3((h + Var1) - 1f, s, v);
        if (CompHSV1[0] < 0) {
            CompHSV1[0] *= -1f;
            CompHSV1[0] = 1f - CompHSV1[0];
        }
        Vector3 CompHSV2 = new Vector3((h + Var2) - 1f, s, v);        
        if (CompHSV2[0] < 0) {
            CompHSV2[0] *= -1f;
            CompHSV2[0] = 1f - CompHSV2[0];
        }
        if (IsFourColour == true) {
            Vector3 CompHSV3 = new Vector3((h + Var3) - 1f, s, v);            
            if (CompHSV3[0] < 0) {
                CompHSV3[0] *= -1f;
                CompHSV3[0] = 1f - CompHSV3[0];
            }
            Colour3.GetComponent<RawImage>().color = Color.HSVToRGB(CompHSV3[0], CompHSV3[1], CompHSV3[2], false);
        }
        if (IsFiveColour == true) {
            Vector3 CompHSV4 = new Vector3((h + Var4) - 1f, s, v);
            if (CompHSV4[0] < 0) {
                CompHSV4[0] *= -1f;
                CompHSV4[0] = 1f - CompHSV4[0];                    
            }
            Colour4.GetComponent<RawImage>().color = Color.HSVToRGB(CompHSV4[0], CompHSV4[1], CompHSV4[2], false);
        }        
        Colour1.GetComponent<RawImage>().color = Color.HSVToRGB(CompHSV1[0], CompHSV1[1], CompHSV1[2], false);        
        Colour2.GetComponent<RawImage>().color = Color.HSVToRGB(CompHSV2[0], CompHSV2[1], CompHSV2[2], false);
        IsFiveColour = false;
        IsFourColour = false;
    }
    void CompColour() {
        Color col = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));        
        UserComp1.GetComponent<RawImage>().color = col;
        Color CompCol1 = new Color((1f - col.r), (1f - col.g), (1f - col.b));        
        ColourComp.GetComponent<RawImage>().color = CompCol1;
    }
    
}
