using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Générer les instances des préfabs PlacePanel
avec les noms corrects à partir du csv
 */
public class GeneratePlaces : MonoBehaviour
{
    public GameObject prefab;
    public static string group;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GroupName").GetComponent<Text>().text = group;

        List<string> lieux = CsvreadAndGenerate.Lieux_Pour_Groupe_String(group);
        GameObject inst;
        float anchor = 0.90F;
        float diffEsp = 0.02F;
        float diffSize = 0.06F;

        // get the content object
        GameObject parentobj = GameObject.Find("Content");

        foreach (string lieu in lieux){

            // instantiate the place
            inst = Instantiate(prefab, parentobj.GetComponent<Transform>());

            // change its name
            inst.transform.Find("PlaceName").GetComponent<Text>().text = lieu;

            // change its position
            RectTransform pos = (RectTransform)inst.GetComponent("RectTransform");
            pos.anchorMax = new Vector2(1F, anchor-=diffEsp);
            pos.anchorMin = new Vector2(0F, anchor-=diffSize);

            // hide star if not visited
            CsvreadAndGenerate.Row lieuRow = CsvreadAndGenerate.Find_Nom_Lieu(lieu);
            if (lieuRow.Visite != "1"){
                inst.transform.Find("Starred").gameObject.SetActive(false);
            }
        }
        // instantiation can take a little time
        SceneTransition.updateLastScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
