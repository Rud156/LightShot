using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public void LoadScene_1() => LoadScene(3);
    public void LoadScene_2() => LoadScene(4);
    public void LoadScene_3() => LoadScene(5);
    public void LoadScene_4() => LoadScene(6);
    public void LoadScene_5() => LoadScene(7);
    public void LoadScene_6() => LoadScene(8);
    public void LoadScene_7() => LoadScene(9);

    private void LoadScene(int sceneIndex)
    {
        NextSceneData.nextSceneIndex = sceneIndex;
        SceneManager.LoadScene(2);
    }
}
