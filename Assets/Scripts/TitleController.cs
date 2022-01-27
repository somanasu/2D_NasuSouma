using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    void Start()
    {
		// シーン リセット
		SystemDaemon.SceneReset();
    }

    void Update()
    {
        // エンター？ or クリック（タッチ互換）
		if( Input.GetKeyDown( KeyCode.Return) || Input.GetMouseButton( 0))
		{
			// シーン ローディング
			LoadingController.Scene = "Game";
			SystemDaemon.LoadScene( "Loading");
		}
    }
}
