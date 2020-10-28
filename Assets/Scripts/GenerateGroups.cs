using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GenerateGroups : MonoBehaviour
{
    public GameObject groupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        List<string> groups = CsvreadAndGenerate.All_Groups();
        foreach (var gr in groups)
        {
            Debug.Log(gr);
        }
        GameObject inst;
        float anchor = 0.9F;
        float diffEsp = 0.03F;
        float diffSize = 0.07F;

        // get the content object
        GameObject parentobj = GameObject.Find("Content");

        foreach (string group in groups){
            if (group == ""){
                continue;
            }

            // instantiate the group prefab
            inst = Instantiate(groupPrefab, parentobj.GetComponent<Transform>());

            // change the text on it
            inst.transform.Find("GroupName").GetComponent<Text>().text = group;

            // change its position
            RectTransform pos = (RectTransform)inst.GetComponent("RectTransform");
            pos.anchorMax = new Vector2(1F, anchor-=diffEsp);
            pos.anchorMin = new Vector2(0F, anchor-=diffSize);

            // hide the star if not completed
            if (!CsvreadAndGenerate.Groupe_Fini(group)){
                inst.transform.Find("Starred").gameObject.SetActive(false);
            }
        }
        // can take a little time so ~
        SceneTransition.updateLastScene();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
