using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Transitions entre les scènes
 */
public class SceneTransition : MonoBehaviour
{
    public static string lastScene;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void backToLastScreen(){
        updateLastScene();
        if (lastScene != ""){
            // get the active scene
            Scene last = SceneManager.GetSceneByName(lastScene);
            // switch scene
            if (last.isLoaded){
                SceneManager.SetActiveScene(last);
            } else {
                SceneManager.LoadScene(lastScene);
            }
            Debug.Log("Going to "+lastScene);
        } else {
            Debug.Log("No last screen.");
        }
        updateLastScene();
    }

    public static void updateLastScene(){
        switch (SceneManager.GetActiveScene().name){
            case "GroupScene":
                lastScene = "MapScene";
                break;
            case "ListScene":
                lastScene = "GroupScene";
                break;
            case "MysteryImageScene":
                lastScene = "MapScene";
                break;
            case "LanguageScene":
                lastScene = "MapScene";
                break;
            case "SuggestionScene":
                // TODO ?
                break;
            case "InfoScene":
                lastScene = "ListScene";
                break;
            default:
                Debug.Log("SceneTransition: wrong scene ??");
                break;
        }
    }

    public static void load(string name){
        Debug.Log("lastScene: "+lastScene);
        Scene sceneToLoad = SceneManager.GetSceneByName(name);
        if (sceneToLoad.isLoaded){
            SceneManager.SetActiveScene(sceneToLoad);
        } else {
            SceneManager.LoadScene(name);
        }
        updateLastScene();
        
    }
}
