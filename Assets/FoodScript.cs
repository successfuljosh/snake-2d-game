using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public BoxCollider2D gridArea; 

// Start is called before the first frame update
   private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        //assign food to this coordinate
        //we round them so the match the snake well
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        Debug.Log("x = "+x.ToString() + "y = " + y.ToString());
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        //check if the tag is the snake  
        if (other.tag=="Player")
            RandomizePosition();
    }
}
