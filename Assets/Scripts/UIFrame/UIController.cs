using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer.Core;

public class UIController : MonoBehaviour, IObserver
{
    UIBaseView view;
    public GameObject prefab;
    float count=0;
    // Use this for initialization
    void Start()
    {
        view = new TestUIView();
        view.observable.AddObserver(this);
        view.SetData(count);
        view.Init(prefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (view != null)
        {
            view.Update(Time.deltaTime);
        }
    }
    private void OnGUI()
    {
        if (GUILayout.Button("open"))
        {
            if (this.view!=null)
            {
                this.view.OnActive();
            }
        }
        if (GUILayout.Button("close"))
        {
            if (this.view!=null)
            {
                this.view.DisActive();
            }
        }
    }

    public void OnNotification(string notification, object notifier, object data)
    {

    }
}
