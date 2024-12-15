using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons:MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }    
}
