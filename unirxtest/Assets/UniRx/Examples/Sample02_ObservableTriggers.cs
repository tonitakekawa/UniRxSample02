using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;
using System.Collections;
using System.Collections.Generic;

public class Sample02_ObservableTriggers : MonoBehaviour
{
    public List<Sprite> Sprites;

    private int count = 0;  // ださっ。Subscribeの中でSpritesをなめ続ける方法はないか？

    void Start()
    {
        var image = GetComponent<Image>();

        gameObject.AddComponent<ObservableUpdateTrigger>()
                    .UpdateAsObservable()
                    .SampleFrame(5)
                    .Subscribe(x => {
                        image.sprite = Sprites[count];
                        count++;
                        count = count == Sprites.Count ? 0 : count;
                     }, () => Debug.Log("destroy"));
    }
}
