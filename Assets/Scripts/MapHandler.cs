using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Script pour la map
En gros tout ce qu'il faut faire pour avoir une map fonctionnelle
Probablement Géoloc ici aussi (générer les objets de pointeurs qui sont des préfabs) */


public class MapHandler : MonoBehaviour
{
    public InputField location;
    public RawImage RImage;
    string url;
    string urlp1;
    string urlp2;

    public void display()
    {

        StartCoroutine(GetImage());
    }

    IEnumerator GetImage()
    {

        WWW www = new WWW(BuildURL());
        yield return www;
        Texture texture = www.texture;
        RImage.texture = texture;
    }

    string BuildURL()
    {
        urlp1 = "https://image.maps.cit.api.here.com/mia/1.6/mapview?app_id=gWMsZjAkd6cp8dhEVz1y&app_code=vspv_GKa4lxZ93kaYhszeQ&ci=";
        urlp2 = "&h=1332.9&w=994.2&z=15&f=0&ml=fre&style=alps";
        return urlp1 + location.text + urlp2;

    }

    // Start is called before the first frame update
    /* void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    */
}
