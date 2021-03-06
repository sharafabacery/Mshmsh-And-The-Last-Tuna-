using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManger : MonoBehaviour
{
    private static UIManger instance;
    [SerializeField]
    private Animator tranAnimator;
    public Text playerTunaCount,liveCount;
    private  void Awake()
   {
       instance=this;
   }
    public static UIManger Instance{
       get{
           if (instance==null)
           Debug.Log("Error");
           return instance;
       }
   }
    public void UpdateTunaCount(int count){
       playerTunaCount.text=count+"";
   }
   public void UpdateLive(int livesremaing){
       liveCount.text=livesremaing+"";
   }
     public void loadScene(int sceneindex){
        StartCoroutine(Transition(sceneindex));
        //SceneManager.LoadScene(sceneindex);
     }

     public void gohell(){
          Application.Quit();
     }

   IEnumerator Transition(int sceneindex){
        tranAnimator.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneindex);
    }



}
