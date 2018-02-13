using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour {

    public float speed;
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI winText;

    private int count = 0;
    private Rigidbody2D rb2d;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    private void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText() {
        counterText.text = "Score: " + count;

        if (count >= 8) {
            winText.text = "You win!";
            StartCoroutine(WinTextColorChanger(winText));
        }
    }

    // WinText color changer coroutine.
    IEnumerator WinTextColorChanger(TextMeshProUGUI winText) {
        bool changingColor = false;
        Color targetColor = new Color();
        Color oldColor = winText.color;
        float percentComplete = 0f;
        while (true) {
            if (changingColor) {
                winText.color = Color.Lerp(oldColor, targetColor, percentComplete);
                percentComplete += Time.deltaTime / 1f;
                Debug.Log("PercentComplete: " + percentComplete);

                if (Mathf.Approximately(winText.color.r, targetColor.r) && Mathf.Approximately(winText.color.g, targetColor.g) &&
                    Mathf.Approximately(winText.color.b, targetColor.b)) {
                    changingColor = false;
                    Debug.Log("Approximately equal!");
                }
            } else {
                changingColor = true;
                targetColor = Random.ColorHSV(0f, 1f, 0.85f, 1f, 1f, 1f);
                oldColor = winText.color;
                percentComplete = 0f;
            }
            Debug.Log("ChangingColor: " + changingColor);
            Debug.Log("Target Color = " + targetColor + ", WinText Color = " + winText.color);
            yield return null;
        }
    }
}
