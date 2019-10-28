using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chairInteraction : MonoBehaviour
{
	bool onFire = false;
	float fireTime = 75.0f;
    public GameObject flamePrefab;
    GameObject flame;
    public GameObject crossPrefab;
    GameObject cross;
    public GameObject gameState;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	public void setFire()
    {
        if (!onFire)
        {
            fireTime = 75.0f;
            onFire = true;
            Debug.Log(this.gameObject.name + "is on fire for " + fireTime / 60 + " minutes," + fireTime % 60 + " seconds");
            flame = Instantiate(flamePrefab,new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
	}
	
	public void save()
    {
        if (onFire)
        {
            onFire = false;
            Debug.Log("Extinguished " + this.gameObject.name);
            Destroy(flame);
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (onFire){
			fireTime -= Time.fixedDeltaTime;
			Debug.Log("Chair destroyed in " + Mathf.Round(fireTime/60) + " minutes," + Mathf.Round(fireTime % 60) + " seconds");
		}
		if (fireTime <= 0){
            gameState.GetComponent<gameStateManager>().chairBurned();
            Destroy(flame);
            flame = Instantiate(crossPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
		}
    }
}
