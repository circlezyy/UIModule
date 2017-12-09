using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestUIView : UIBaseView {
    Text label;
    float count;
    public override void SetData(params object[] data)
    {
        count = (float)data[0];
    }
    protected override void InitUI()
    {
        this.label = sourcePrefab.GetComponentInChildren<Text>();
    }
    protected override void OnUpdate(float deltaTime)
    {
        count +=deltaTime;
        if (this.label!=null)
        {
            //this.label.text = count.ToString();
           // Debug.Log("Update:" + count);
        }
       
    }
    
}
