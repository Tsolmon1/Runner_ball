using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    private Touch touch;
    private float touchSpeed = 0.01f;
    public float speed = 5;

    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMultiplier = 2;

    private void FixedUpdate() {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right *horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    // Update is called once per frame
    private void Update()
    {
        if(Input.touchCount > 0) {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved){
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * touchSpeed,
                    transform.position.y, transform.position.z);
            }
        }
        horizontalInput = Input.GetAxis("Horizontal");
        if(transform.position.y < -5) {
            Die();
        }
    }

    public void Die() {
        alive = false;
        //restart game
        Invoke("Restart", 2);   
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
