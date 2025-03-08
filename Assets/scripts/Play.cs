using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    public string nameScene;
    
    public void ChangeScene()
    {
        SceneManager.LoadScene(nameScene);
    }
}
