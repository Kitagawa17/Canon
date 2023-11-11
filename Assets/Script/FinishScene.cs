using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void PushFinishButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
