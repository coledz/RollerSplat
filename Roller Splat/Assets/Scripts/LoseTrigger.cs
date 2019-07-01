using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTrigger : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1"))
            {
                SceneManager.LoadScene("LoseGame");
            }

            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }

}
