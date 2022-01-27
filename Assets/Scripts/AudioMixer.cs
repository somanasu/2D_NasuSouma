using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMixer : MonoBehaviour
{
	// ミキサー
	public UnityEngine.Audio.AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
		//指定はデシベル（dB）なので直接 0.0～1.0は使えない
		//0.0なら-80.0f、それ以上なら10.0f * Mathf.Logを使用する。

		//mixer.SetFloat( "MusicVolume", 10.0f * Mathf.Log( 1.0));
        //mixer.SetFloat( "MusicVolume", -80.0f);

		//mixer.SetFloat( "SoundVolume", 10.0f * Mathf.Log( 1.0));
        //mixer.SetFloat( "SoundVolume", -80.0f);
		
		//mixer.SetFloat( "VoiceVolume", 10.0f * Mathf.Log( 1.0));
        //mixer.SetFloat( "VoiceVolume", -80.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
