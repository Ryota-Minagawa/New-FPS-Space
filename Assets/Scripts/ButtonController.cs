using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour {

    public void ClickButton()
    {
        SceneManager.LoadScene("Main");
    }

}
