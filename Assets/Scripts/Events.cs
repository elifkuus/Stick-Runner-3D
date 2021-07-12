using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Events : MonoBehaviour
{
   
   public void ReplayGame(int a)
   {
      SceneManager.LoadScene(a);
   }

   public void QuitGame()
   {
      Application.Quit();
   }
}
