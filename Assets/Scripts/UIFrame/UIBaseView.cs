using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer.Core;
using UnityEngine.UI;
public class UIBaseView {
    Observable _observable;
    public Observable observable
    {
        get
        {
            if (_observable == null)
            {
                _observable = new Observable();
            }
            return _observable;
        }
    }
    protected bool IsActive;
   protected   GameObject sourcePrefab;
   protected  CanvasGroup render;
    public void Init(GameObject _root)
    {
        this.sourcePrefab = _root;
        this.render = sourcePrefab.GetComponent<CanvasGroup>();
        InitUI();
        OnActive();
    }
    protected virtual void InitUI() { }
    public virtual void SetData(params object[] data)
    {

    }
    public void OnActive()
    {
        IsActive = true;
        if (this.render!=null)
        {
            this.render.alpha = IsActive?1:0;
        }
    }
    public void Update(float deltaTime)
    {
        if (IsActive)
        {
            OnUpdate(deltaTime);
        }
    }
    protected virtual void OnUpdate(float deltaTime)
    {

    }
    public void DisActive()
    {
        IsActive = false;
        if (this.render!=null)
        {
            this.render.alpha = IsActive?1:0;
        }
    }
}
