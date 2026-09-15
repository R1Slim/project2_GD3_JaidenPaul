using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;
using Color = UnityEngine.Color;

public class RayCast : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    public float colcheckDistance = 0.5f;
    public LayerMask LightLayer;
    public bool istouchingblockright;
    public bool istouchingblockleft;
    public GameObject rightlight;
    public GameObject leftlight;
    public Rigidbody2D RB;
    public RaycastHit2D lefthit;
    public RaycastHit2D righthit;

     
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        //do the raycast
        //RaycastHit2D is a storage made for anything i hit on a certain layer, i named it righthit and lefthit 
        //https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Physics2D.Raycast.html
        
        righthit = Physics2D.Raycast(player.position, Vector2.right, colcheckDistance, LightLayer);
        lefthit =  Physics2D.Raycast(player.position, Vector2.left, colcheckDistance, LightLayer);
        
        if (righthit)
        {
            Color.Lerp(Color.white, Color.yellow, 0.5f);
        }
        //save to variable right light
        // Update is called once per frame
    }
    void Update()
    {
        istouchingblockright = righthit;
        istouchingblockleft = lefthit;
        Debug.DrawRay(player.position, Vector2.right * colcheckDistance, Color.red);
        Debug.DrawRay(player.position, Vector2.left * colcheckDistance, Color.green);

        if (istouchingblockright)
        {
            righthit.collider.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white,Color.yellow, 0.5f);
        }
        if (istouchingblockleft)
        {
            lefthit.collider.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.yellow, 0.5f);
        }

        if (!istouchingblockright)
        {
            rightlight.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (!istouchingblockleft)
        {
            leftlight.GetComponent<SpriteRenderer>().color = Color.white;
        }


        if (istouchingblockleft && lefthit.collider.GetComponent<GameObject>() == leftlight && Input.GetKeyDown(KeyCode.Space))
        {
           leftlight.transform.position = lefthit.point;
        }
        if (istouchingblockright && righthit.collider.GetComponent<GameObject>() == rightlight && Input.GetKey(KeyCode.Space))
        {
           rightlight.transform.position = righthit.point;
        }
    }
   
}
