using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void PushStartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    //ÉQÅ[ÉÄëﬁèoéû
    public void PushQuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
