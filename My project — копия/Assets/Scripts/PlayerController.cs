using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    public float rotationSpeed = 10f;
    public float speed = 4f;
    public Transform cameraTransform;

    // Новая переменная для системы частиц
    public ParticleSystem dustParticles;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        // Проверка на камеру, если не назначена — используем основную
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        // Если частицы не назначены, попробуем найти их на объекте
        if (dustParticles == null)
        {
            dustParticles = GetComponentInChildren<ParticleSystem>(); // Ищем в дочерних объектах
        }
    }

    private void Update()
    {
        // Получение ввода для движения
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Направление движения игрока
        Vector3 inputDirection = new Vector3(h, 0, v).normalized;

        // Расчет направления движения относительно камеры
        Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 cameraRight = Vector3.Scale(cameraTransform.right, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = inputDirection.z * cameraForward + inputDirection.x * cameraRight;

        // Если есть движение, поворачиваем игрока
        if (moveDirection.magnitude > 0.05f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Запуск частиц при движении
            if (dustParticles != null && !dustParticles.isPlaying)
            {
                dustParticles.Play(); // Включаем частицы, если движение есть
            }
        }
        else
        {
            // Останавливаем частицы, если игрок не двигается
            if (dustParticles != null && dustParticles.isPlaying)
            {
                dustParticles.Stop(); // Останавливаем частицы, если нет движения
            }
        }

        // Устанавливаем параметр "speed" для анимации
        animator.SetFloat("speed", moveDirection.magnitude);

        // Применяем движение через Rigidbody
        rigidbody.linearVelocity = moveDirection * speed; // Установим скорость через Rigidbody
    }
}
