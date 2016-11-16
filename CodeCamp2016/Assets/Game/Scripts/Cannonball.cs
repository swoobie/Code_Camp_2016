using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Cannonball : MonoBehaviour {

    public float Destory_After = 3.5f;
    private CannonFire cannon;

    public static int currentScene = 0;

    void Start()
    {
        Destroy(gameObject, Destory_After);
        cannon = GameObject.Find("Cannon").GetComponent<CannonFire>();
    }

    void OnDestroy()
    {
        if(cannon != null)
            cannon.canFire = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Target_Trigger")
        {
            print("Reached target!");
            GameObject.Find("Player").GetComponent<ScreenFader>().fadeIn = false;
            
             StartCoroutine("NextLevel");

        }
    }

    IEnumerator NextLevel()
    {
        print("before yield");
        yield return new WaitForSecondsRealtime(2);
        print("should load level");
        Application.LoadLevel(Application.loadedLevel + 1);

        GameObject.Find("Player").GetComponent<ScreenFader>().fadeIn = true;
    }
}
