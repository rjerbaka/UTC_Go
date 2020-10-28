using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLang : MonoBehaviour
{

    public string langage;


    // Start is called before the first frame update
    void Start()
    {
        langage = LangChange.getLang();

        string lieux;
        string langue;
        string retour;

        if (langage == "FR")
        {
            lieux = "Lieux";
        }
        else
        {
            lieux = "Places";
        }

        if (langage == "FR")
        {
            langue = "Langue";
        }
        else
        {
            langue = "Language";
        }

        if (langage == "FR")
        {
            retour = "Retour Carte";
        }
        else
        {
            retour = "Back to Map";
        }

        GameObject.Find("Places").GetComponent<Text>().text = lieux;
        // GameObject.Find("Places").GetComponent<Text>().text = "Places";

        GameObject.Find("Language").GetComponent<Text>().text = langue;
        GameObject.Find("map").GetComponent<Text>().text = retour;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
