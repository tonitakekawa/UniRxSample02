#if !(UNITY_METRO || UNITY_WP8)

using UnityEngine;

namespace UniRx.Examples
{
    public class Sample01_ObservableWWW : MonoBehaviour
    {
        void Start()
        {
            /*
            Observable.SelectMany(
                ObservableWWW.Get("http://google.com/"),
                ObservableWWW.Get("http://bing.com/")
            ).Subscribe(res => Debug.Log(res.Substring(0,100)));
             */

            {
                var query = from google in ObservableWWW.Get("http://google.com/")
                            from bing in ObservableWWW.Get("http://bing.com/")
                            select new { google, bing };

                var cancel = query.Subscribe(x => Debug.Log(x.google.Substring(0, 100) + ":" + x.bing.Substring(0, 100)));

                // Call Dispose is cancel downloading.
                //cancel.Dispose();
            }
        }
    }
}

#endif