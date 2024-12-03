
using UnityEngine;
using UnityEngine.SceneManagement;

public class return_menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Gotoscene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
