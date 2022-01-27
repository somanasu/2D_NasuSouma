//********************************************************************************
// 全解像度で完全同じ画面を再現 ※Landscape
//********************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI
using UnityEngine.UI;

public class CanvasScreenMatch : MonoBehaviour
{
    [SerializeField]
    int defWidth = 1280;

    [SerializeField]
    int defHeight = 720;
    
	void Awake() {
		UpdateCanvas();
	}

    void Update()
    {
        UpdateCanvas();
    }

	void UpdateCanvas() {
		float default_aspect = (float)defWidth / (float)defHeight;
		float display_aspect = (float)Screen.width / (float)Screen.height;

		// 設定より画面がアスペクトが大きい？
		if( default_aspect < display_aspect) {
			GetComponent<CanvasScaler>().matchWidthOrHeight = 1.0f;
		} else {
			GetComponent<CanvasScaler>().matchWidthOrHeight = 0.0f;
		}
	}
}
