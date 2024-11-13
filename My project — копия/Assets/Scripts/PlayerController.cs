using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    public float rotationSpeed = 10f;
    public float speed = 4f;
    public Transform cameraTransform;

    
    public ParticleSystem dustParticles;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        
        if (dustParticles == null)
        {
            dustParticles = GetComponentInChildren<ParticleSystem>(); 
        }
    }

    private void Update()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        
        Vector3 inputDirection = new Vector3(h, 0, v).normalized;

        
        Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 cameraRight = Vector3.Scale(cameraTransform.right, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = inputDirection.z * cameraForward + inputDirection.x * cameraRight;

        
        if (moveDirection.magnitude > 0.05f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            
            if (dustParticles != null && !dustParticles.isPlaying)
            {
                dustParticles.Play(); 
            }
        }
        else
        {
            
            if (dustParticles != null && dustParticles.isPlaying)
            {
                dustParticles.Stop(); 
            }
        }

        
        animator.SetFloat("speed", moveDirection.magnitude);

        
        rigidbody.linearVelocity = moveDirection * speed; 
    }
}
