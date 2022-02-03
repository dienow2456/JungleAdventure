using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool mute = false, clickMuteMusic = false, clickMuteSound=false;
    public static bool clickLv1 = false, clickLv2 = false, clickLv3 = false, clickLv4 = false,clickLv5 = false,clickLv6 = false;
    [SerializeField]
    AudioSource  click;
    public GameObject LoadingScene;
    public Slider slider;
    [SerializeField]
    GameObject muteMusic, muteSound;
    private void Start()
    {
        if(clickMuteMusic)
        {
            muteMusic.SetActive(false);
        }
        if(clickMuteSound)
        {
            muteSound.SetActive(false);
        }
        Application.targetFrameRate = 60;
    }
    public void LoadLevel(int sceneIndex)
    {
        GameManagerLevel1.gamePause = false;
        GameManagerlv2.gamePause = false;
        GameManagerLv3.gamePause = false;
        GameManagerlv4.gamePause = false;
        GameManagerLv5.gamePause = false;
        GameManagerlv6.gamePause = false;
        switch (sceneIndex)
        {
            case 0:
                clickLv1 = true;
                
                break;
            case 3:
                
                clickLv2 = true;
              
                break;
            case 4:
               
                clickLv3 = true;
                
                break;
            case 5:
               
                clickLv4 = true;
                
                break;
            case 6:
               
                clickLv5 = true;
                break; 
            case 7:
               
                clickLv6 = true;
                break;
        }
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        if(!mute)
            click.Play();
        LoadingScene.SetActive(true);
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        
        while (!operation.isDone)
        {
            
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            
            slider.value = progress;
            yield return null;
        }
        
    }
    
    public void MuteMusic()
    {
        mute = true;
        clickMuteMusic = true;
        muteMusic.SetActive(false);
    } 
    public void UnMuteMusic()
    {
        mute = false;
        clickMuteMusic = false;
        muteMusic.SetActive(true);
    }
    public void MuteSound()
    {
        clickMuteSound = true;
        DontDestroy.Instance.backgroundAudio.mute = true;
        muteSound.SetActive(false);
        
    } 
    public void UnMuteSound()
    {
        clickMuteSound = false;
        DontDestroy.Instance.backgroundAudio.mute = false;
        muteSound.SetActive(true) ;
    }
}
