using UnityEngine;
using TMPro;

public class mapUnlockSystem : MonoBehaviour
{
    public economySystem _ekonomi;
    public SpriteRenderer road;
    public Sprite[] Maps;
    public int[] mapCost;
    public TMP_Text[] MapsButtonLabel;
    
    public bool[] isUnlocked;
    

	public enum mapList{Highway, Beach}
	
	public void Map(mapList map)
	{
	    switch(map)
	    {
	        // FLOW UNLOCK -> BUY DULU BARU isUnlocked JADI TRUE
	        case mapList.Highway:
	            if(isUnlocked[0])
	            {
	                road.sprite = Maps[0];
	            }
	            else{ }
	            break;
	            
	        case mapList.Beach:
	            if(isUnlocked[1])
	            {
	                road.sprite = Maps[1];
	            }
	            break;
	            
	    }
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isUnlocked[0] = true;
    }

    public void setMap(int indexMap)
    {
        // HARGA MAP DAN INDEX MAP ITU PENEMPATAN INT NYA SAMA
        if(_ekonomi.Point >= mapCost[indexMap])
        {
            isUnlocked[indexMap] = true;
        }
    }
}
