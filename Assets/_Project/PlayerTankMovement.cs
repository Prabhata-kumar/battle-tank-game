using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerTankMovement : monoSingletonGeneric<PlayerTankMovement>
{
    public int m_Playernumber = 1;
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;
    public AudioSource m_MovementAudio;
    public AudioClip m_EngineIdling;
    public AudioClip m_EngineDriving;
    public float m_PitchRange = 0.2f;
    //public Joystick joystick;

    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private float m_OriginalPitch;

    protected new void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_MovementAxisName = "Horizontal"+ m_Playernumber;
        m_MovementAxisName = "Vertical" + m_Playernumber;



       /* float playerMoveHorizontal = joystick.Horizontal;
        float playerTurnVertical = joystick.Vertical;*/
         m_OriginalPitch = m_MovementAudio.pitch;
    }

    void Update()
    {
        m_MovementInputValue = Input.GetAxisRaw("Horizontal");
        m_TurnInputValue = Input.GetAxisRaw("Vertical");

         EngineAudio();
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void EngineAudio()
    {
        if (Mathf.Abs(m_MovementInputValue) < 0.1f && Mathf.Abs(m_TurnInputValue) < 0.1f)
        {
            if (m_MovementAudio.clip == m_EngineDriving)
            {
               // m_MovementAudio.clip = m_EngineDriving;
               //m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_OriginalPitch);

                m_MovementAudio.Play();
            }
        }
        else
        {
            if (m_MovementAudio.clip == m_EngineDriving)
            {
              //  m_MovementAudio.clip = m_EngineDriving;
              //  m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_OriginalPitch);

                m_MovementAudio.Play();
            }

        }

    }
    void Move()
    {
        //Arject the positionof tank based on player input
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }
    void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

}


    /*
        public float playerspeed;
        public float rotationSpeed;
        public Joystick joystick;
        private void Update()
        {
            float playerMoveHorizontal = Input.GetAxisRaw("Horizontal");
            float playerTurnVertical = Input.GetAxisRaw("Vertical");

            //float playerMoveHorizontal = joystick.Horizontal;
            // float playerTurnVertical = joystick.Vertical;

            Vector3 movementDirection = new Vector3(playerMoveHorizontal, 0f, playerTurnVertical);
            movementDirection.Normalize();

            transform.Translate(movementDirection * playerspeed * Time.deltaTime, Space.World);
            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
}

    */
