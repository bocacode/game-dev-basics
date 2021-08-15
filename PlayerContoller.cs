using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour {
    public Text scoreText;
    public float speed = 10.0f;
    private Rigidbody rb;
    private int score;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScore();
    }

    // FixedUpdate is used for Physics actions
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Collectible")) {
            other.gameObject.SetActive(false);
            score = score + 10;
            SetScore();
        }
    }

    void SetScore() {
        scoreText.text = "Score: " + score;
    }
}
