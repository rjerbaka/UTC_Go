using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Implémenter la recherche de lieux sur la map
> attaché au panel contenant la map
OnValueChanged et OnEndEdit de l'input field à modifier une fois
les fonctions faites ;)
 */

/*
   pour récuperer les points bleus : List<GameObject> spawnedPlaces = SpawnOnMap._spawnedObjects;
   pour activer ou désactiver un Gameobject : gameobjectvar.SetActive(flag);
   les instances présentes dans la liste sont différentiées par leur TextMesh component
   pour récupérer le tring du TextMesh : gameobjectvar.transform.Find("TextMesh").GetComponent<TextMesh>().text
   ce texte correspond aux Nom_Lieu du csv
 */
public class Search : MonoBehaviour
{
    public InputField Input;
    public GameObject SearchScroll;
    //List<string> lieuArr = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

        SearchScroll.SetActive(false);


    }

    public void results()
    {
        SearchScroll.SetActive(true);
        List<string> lieuArr = CsvreadAndGenerate.LieuxAll();
        string name;


            int i = 0;
            int j = 0;

            while (i < 10 && j <= 30)
            {
                name = "Text" + (i + 1).ToString();

                if (string.IsNullOrEmpty(Input.text) || (lieuArr[j].ToLower()).Contains((Input.text).ToLower()))
                {
                    GameObject.Find(name).GetComponent<Text>().text = lieuArr[j];
                    i++;
                }
            j++;
            }

            for(int k = i; k<10; k++) {
            name = "Text" + (k + 1).ToString();
            GameObject.Find(name).GetComponent<Text>().text = null; }
        
    }


    public void onEnd()
    {
        //SearchScroll.SetActive(false);

    }

    public void chosen(Text nom)
    {
        //Text ip = GameObject.Find("InputField").GetComponentInChildren<Text>();
        //ip.text = ""; 
        Input.text = nom.text;

        List<GameObject> spawnedPlaces = Mapbox.Examples.SpawnOnMap._spawnedObjects;
        

        foreach (GameObject gameobjectvar in spawnedPlaces)
        {
            TextMesh choice = gameobjectvar.transform.Find("TextMesh").GetComponent<TextMesh>();
            if (string.Compare(choice.text, nom.text) != 0)
            {
                gameobjectvar.SetActive(false);
            } else { gameobjectvar.SetActive(true); }
        }

    }
 

    // Update is called once per frame
    void Update()
    {
        if(string.IsNullOrEmpty(Input.text)){
            List<GameObject> spawnedPlaces = Mapbox.Examples.SpawnOnMap._spawnedObjects;


            foreach (GameObject gameobjectvar in spawnedPlaces) gameobjectvar.SetActive(true);


                    }


    }
}
