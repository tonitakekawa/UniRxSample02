using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;

public class ImageChanger : MonoBehaviour {

	void Start () {
        var clickStream = this.UpdateAsObservable()
                              .Where(_ => Input.GetMouseButton(0));

        clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(200)))
                   .Where(x => x.Count >= 2)
                   .Subscribe(x => string.Format("Double Click{0}", x.Count));
	}

}
