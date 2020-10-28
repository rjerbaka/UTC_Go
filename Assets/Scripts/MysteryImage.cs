using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Ici gérer quels morceaux de l'image apparaîtront
Il faudra probablement couper l'image au préalabre et tout mettre dans un dossier 
> attaché au panel qui doit contenir les morceaux d'image */

public class MysteryImage : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        string adr1 = "Parts_img/img_myst_";
        string name = "pc11";
        string adr;
        int k;


        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                k = i * 4 + j + 1;

                if (CsvreadAndGenerate.getVisitedList()[(i * 4) + j] == 1)
                {
                    adr = adr1 + k.ToString();
                    Sprite sprite = Resources.Load<Sprite>(adr);
                    name = "pc" + (i + 1).ToString() + (j + 1).ToString();
                    GameObject.Find(name).GetComponent<Image>().sprite = sprite;
                }

            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}

