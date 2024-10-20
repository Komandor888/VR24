using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class vrtest : MonoBehaviour
{
    public int x=0;
    public Text Mytxt;
    public int z;
    public int y;
    public int c;
public int r;
    

void Start()
{
    Debug.Log("Hello world");
}

void FixedUpdate()
{
    x++;
    Mytxt.text=x.ToString();
}

public void ClickBut()
{
z=Random.Range(0,255);
y=Random.Range(0,255);
c=Random.Range(0,255);

this.GetComponent<Renderer>().material.color = new Color32((byte)z,(byte)y,(byte)c,1);
Debug.Log("colored");
}

public void Activator()
{
r++;
if (r%2==1)
{
this.gameObject.SetActive(false);
Debug.Log("deactivated");
}
else
{
this.gameObject.SetActive(true);
Debug.Log("activated");
}
}

}