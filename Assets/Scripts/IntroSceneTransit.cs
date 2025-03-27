using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroSceneTransit : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoPlayer; // 비디오 플레이어
    public string nextSceneName; // 전환할 다음 씬의 이름

    void Start()
    {
        // VideoPlayer의 재생 완료 이벤트에 OnVideoEnd 메서드 추가
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // 비디오가 끝났을 때 다음 씬으로 전환
        SceneManager.LoadScene(nextSceneName);
    }
}