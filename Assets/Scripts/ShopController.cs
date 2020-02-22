using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button item1;
    public Button item2;
    void Start()
    {
	    if (PlayerPrefs.GetInt("Coins") >= 15)
	    { 
		   // item1.onClick.AddListener(shop("background", 15, "Green Sky"));
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void shop(string item_type, int price, string Name)
    {

    }
}
