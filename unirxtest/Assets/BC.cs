using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class BC : MonoBehaviour {

    public Button button;
    public Button button2;
    public Text text;

	void Start () {

        // カウントダウンタイマ
        Observable.Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
                  .Select(x => (int)(10 - x))
                  .Take(10 + 1)
                  .Subscribe(x => Debug.Log(x));

	}

}
