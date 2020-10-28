using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Utils;
using Mapbox.Examples;
using UnityEngine.UI;

public class Visit : MonoBehaviour
{
     //permet de récup la location actuelle
    ILocationProvider _locationProvider;

    // la location actuelle
    Location location;

    // TODO: vérifier la pertinence du diff
    double diff = 0.0002;

    List<CsvreadAndGenerate.Row> lieux;

    public GameObject popupObj;

    string congrats;

    // Start is called before the first frame update
    void Start()
    {
        lieux = CsvreadAndGenerate.All_Lieux_Non_Visite();
        string langage = LangChange.getLang();
        switch (langage){
            case "FR":
                congrats = "Félicitations, vous avez atteint";
                break;
            case "EN":
                congrats = "Congratulations, you have reached";
                break;
            default:
                congrats = "Congratulations, you have reached";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // recup la current location
        _locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
        location = _locationProvider.CurrentLocation;

        // Debug.Log("pos: "+location.LatitudeLongitude);

        //opti: closest?

        foreach(CsvreadAndGenerate.Row row in lieux){
           
            Vector2d temp = new Vector2d(
                double.Parse(row.Latitude, System.Globalization.CultureInfo.InvariantCulture),
                double.Parse(row.Longitude, System.Globalization.CultureInfo.InvariantCulture));
            // Debug.Log("tempval: "+temp);
            if (isOnDest(temp)){
                
                doOnDest(row.Nom_Lieu);
                break;
            }
        }
        
    }

     private void doOnDest(string dest)
    {
        // ce qui est fait lorsque l'utilisateur arrive à destination
        CsvreadAndGenerate.Modif_Visite(dest);
        lieux = CsvreadAndGenerate.All_Lieux_Non_Visite();
        
        // popup
        popupObj.transform.Find("PlaceNameText").GetComponent<Text>().text = dest;
        popupObj.transform.Find("CongratsText").GetComponent<Text>().text = congrats;
        Debug.Log(congrats);
        popupObj.SetActive(true);

        SpawnOnMap.changeToGreen(dest);
        Debug.Log("Endroit atteint: "+dest);
    }

    private bool isOnDest(Vector2d destCoor)
    {
        Vector2d min = new Vector2d(destCoor.x - diff, destCoor.y - diff);
        Vector2d max = new Vector2d(destCoor.x + diff, destCoor.y + diff);

        if (compareVect2d(min, location.LatitudeLongitude) == 2 && compareVect2d(location.LatitudeLongitude, max) == 2)
        {
            return true;
        }
        return false;
    }

    private int compareVect2d(Vector2d vect1, Vector2d vect2)
    {
        if (vect1.x < vect2.x && vect1.y < vect2.y)
        {
            // "biggest" is vect2
            return 2;
        }

        if (vect1.x > vect2.x && vect1.y > vect2.y)
        {
            // "biggest" is vect1
            return 1;
        }

        if (vect1.x == vect2.x && vect1.y == vect2.y)
        {
            // equal
            return 0;
        }

        // else undefined
        return -1;
    }

    public void closePopup(){
        popupObj.SetActive(false);
    }
}
