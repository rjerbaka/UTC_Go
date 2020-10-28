using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPopup : MonoBehaviour
{
    public GameObject popupObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(Text dest){
        Debug.Log("infopopup: "+dest.text);
        CsvreadAndGenerate.Row place = CsvreadAndGenerate.Find_Nom_Lieu(dest.text);
        string indic;
        if (LangChange.getLang() == "FR"){
            indic = place.Indications;
        } else {
            indic = place.IndicationsEN;
        }
        popupObj.transform.Find("PlaceNameText").GetComponent<Text>().text = dest.text;
        popupObj.transform.Find("InfoText").GetComponent<Text>().text = indic;

        popupObj.SetActive(true);
    }

    public void Deactivate(){
        popupObj.SetActive(false);
    }
}
