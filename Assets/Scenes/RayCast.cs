using Unity.VisualScripting;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    public float colcheckDistance = 0.5f;
    public LayerMask LightLayer;
    public bool istouchingblockright;
    public bool istouchingblockleft;
    public GameObject rightlight;
    public Rigidbody2D RB;
    
    void Start()
    {
       RB = GetComponent<Rigidbody2D>();
    }

    fixed Update;
        //do the raycast
        //save to variable right light
    // Update is called once per frame
    void Update()
    {
        istouchingblockright = Physics2D.Raycast(player.position, Vector2.right, colcheckDistance, LightLayer);
        istouchingblockleft = Physics2D.Raycast(player.position, Vector2.left, colcheckDistance, LightLayer);
        Debug.DrawRay(player.position, Vector2.right * colcheckDistance, Color.red);
        Debug.DrawRay(player.position, Vector2.left * colcheckDistance, Color.green);

        if (istouchingblockleft || istouchingblockright)
        {
            Collision2D.gameObject.color= Color.Lerp(Color.white, Color.yellow, 0.5f);
        }
        

    }
}
