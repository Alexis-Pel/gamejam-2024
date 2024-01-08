using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int m_lives = 1;

    private Rigidbody2D m_rigidbody;
    private float m_speed;


    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        Invoke(nameof(GetKilled), Settings.TargetLifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        m_rigidbody.velocity = new Vector2(Speed, m_rigidbody.velocity.y);
    }

    // Being shot at
    private void OnMouseDown()
    {
        m_lives -= 1;
        if(m_lives == 0)
        {
            GetKilled();
        }
    }

    // Getter and Setter for the speed proprety
    public float Speed
    {
        get { return m_speed; }
        set { m_speed = value; }
    }

    private void GetKilled()
    {
        Destroy(gameObject);
    }
}
