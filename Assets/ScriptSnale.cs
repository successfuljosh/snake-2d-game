using UnityEngine;
using System.Collections.Generic;

public class ScriptSnale : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments;

    public Transform segmentPrefab;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
    }
    private void FixedUpdate()
    {
        //move the position of the segments to its previous position
        for (int i = _segments.Count-1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }


        //change the position of the head
        this.transform.position = new Vector3(
           Mathf.Round(this.transform.position.x) + _direction.x,
              Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f);
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);

    }
    void ResetState()
    {
        //reset score
        KeepScore.Score = 0;
        //destroy all segments excluding the first one
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear(); //clear list because even if we destroyed them above, there is still a ref to them in the memory
        _segments.Add(this.transform); //re-add the head

        this.transform.position = Vector3.zero; //reset the position of snake
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //check if the tag is the food  
        if (other.tag == "Food")
        {
            KeepScore.Score += 10;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            Grow();
        }
        else if (other.tag == "Obstacle") //reset game if snake collides with segments and wall
        {
            ResetState();
        }
    }
}
