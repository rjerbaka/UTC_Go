using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GenerateInfo : MonoBehaviour {

    //public static string group;
    public static string place;
    public string langage;

    void Start(){

        langage = LangChange.getLang();

        // set name
        GameObject.Find("PlaceName").GetComponent<Text>().text = place;

        // get place object
        CsvreadAndGenerate.Row lieuRow = CsvreadAndGenerate.Find_Nom_Lieu(place);

        // set text
        string allText;
        if (langage == "FR")
        {
            allText = "\n\n"+lieuRow.Description;
        }
        else
        {
            allText = "\n\n"+lieuRow.DescriptionEN;
        }
        allText += "\n\n Pour s'y rendre :\n";
        if (langage == "FR")
        {
            allText += lieuRow.Indications;
        }
        else
        {
            allText += lieuRow.IndicationsEN;
        }
        GameObject.Find("TextInfo").GetComponent<Text>().text = allText;
        
        // set image
        Sprite sprite = Resources.Load<Sprite>(lieuRow.Image_Lieu);
        GameObject.Find("ImageLieu").GetComponent<Image>().sprite = sprite;

        SceneTransition.updateLastScene();
    }

}