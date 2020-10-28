using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/* Le script pour changer de langue
(...)
Utiliser modifier les OnClick des boutons français et english
une fois qu'on a les fonctions appropriées */

public class LangChange : MonoBehaviour
{

    static public string lang;

    // Start is called before the first frame update
    void Start()
    {
        lang = "EN";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // juste pour qu'ils apparaissent dans l'éditeur
    public void frPressed()
    {
        lang = "FR";
        Debug.Log("Langage FR");
    }

    public void enPressed()
    {
        lang = "EN";
        Debug.Log("Langage EN");
    }

    static public string getLang()
    {
        string result = lang;
        return result;
    }
}
