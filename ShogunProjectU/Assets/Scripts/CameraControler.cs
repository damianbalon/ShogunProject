using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float baseMovementSpeed;
    public BoxCollider2D cameraBox;
    public Rigidbody2D cameraBody;

    private Vector2 targetPosition;
    private bool isAutoMoving;
    private bool isMoveSynced;

    private const float syncedSpeed = 2.6415f;
    private const float edgeAccelerationDistance = 50f;
    private const float accelerationMultiplier = 2f;

    public static CameraController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Check for manual camera movement
        HandleManualMovementInput();
    }

    void FixedUpdate()
    {
        // Scale camera's collider to match viewport size
        ScaleCameraCollider();

        // Handle camera movement based on different scenarios
        HandleAutoMovement();
    }

    private void ScaleCameraCollider()
    {
        cameraBox.size = new Vector2(GetComponent<Camera>().orthographicSize * 2 * GetComponent<Camera>().aspect, 2 * GetComponent<Camera>().orthographicSize);
    }

    private void HandleManualMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Check if there's manual input for camera movement
        if (Mathf.Abs(horizontalInput) >= 0.1f || Mathf.Abs(verticalInput) >= 0.1f)
        {
            isAutoMoving = false;
            MoveCameraManually(horizontalInput, verticalInput);
        }
        else
        {
            // Move the camera when the mouse is close to the screen edges
            MoveCameraWithMouse();
        }
    }

    private void MoveCameraManually(float horizontalInput, float verticalInput)
    {
        float currentSpeed = CalculateCurrentSpeed();
        Vector2 newPosition = new Vector2(transform.position.x + horizontalInput * currentSpeed * Time.fixedDeltaTime, transform.position.y + verticalInput * currentSpeed * Time.fixedDeltaTime);
        cameraBody.MovePosition(newPosition);
    }

    private float CalculateCurrentSpeed()
{
    float currentSpeed = baseMovementSpeed;

    float distanceToLeftEdge = Input.mousePosition.x;
    float distanceToRightEdge = Screen.width - Input.mousePosition.x;
    float distanceToBottomEdge = Input.mousePosition.y;
    float distanceToTopEdge = Screen.height - Input.mousePosition.y;

    float edgeThreshold = 10f; // Adjust this value based on how close to the edge you want to trigger increased speed
    float doubleSpeedThreshold = 5f; // Adjust this value based on how very close to the edge you want to trigger double speed

    if (distanceToLeftEdge < edgeThreshold)
    {
        currentSpeed *= Mathf.Lerp(1f, 2f, Mathf.InverseLerp(0f, doubleSpeedThreshold, distanceToLeftEdge));
    }
    else if (distanceToRightEdge < edgeThreshold)
    {
        currentSpeed *= Mathf.Lerp(1f, 2f, Mathf.InverseLerp(0f, doubleSpeedThreshold, distanceToRightEdge));
    }

    if (distanceToBottomEdge < edgeThreshold)
    {
        currentSpeed *= Mathf.Lerp(1f, 2f, Mathf.InverseLerp(0f, doubleSpeedThreshold, distanceToBottomEdge));
    }
    else if (distanceToTopEdge < edgeThreshold)
    {
        currentSpeed *= Mathf.Lerp(1f, 2f, Mathf.InverseLerp(0f, doubleSpeedThreshold, distanceToTopEdge));
    }

    return currentSpeed;
}
    private bool OutOfBounds() {
        if(Input.mousePosition.x < 0) return true;
        if(Input.mousePosition.x > Screen.width) return true;
        if(Input.mousePosition.y < 0) return true;
        if(Input.mousePosition.y > Screen.height) return true;
        return false;
    }

    private void MoveCameraWithMouse()
{
    float edgePadding = 25f; // Adjust this value based on how close to the edge you want the mouse to trigger camera movement
if(!OutOfBounds()) {
    if (Input.mousePosition.x < edgePadding)
    {
        if (Input.mousePosition.y < edgePadding)
        {
            MoveCameraManually(-1f, -1f); // Move diagonally left-down
        }
        else if (Input.mousePosition.y > Screen.height - edgePadding)
        {
            MoveCameraManually(-1f, 1f); // Move diagonally left-up
        }
        else
        {
            MoveCameraManually(-1f, 0f); // Move left
        }
    }
    else if (Input.mousePosition.x > Screen.width - edgePadding)
    {
        if (Input.mousePosition.y < edgePadding)
        {
            MoveCameraManually(1f, -1f); // Move diagonally right-down
        }
        else if (Input.mousePosition.y > Screen.height - edgePadding)
        {
            MoveCameraManually(1f, 1f); // Move diagonally right-up
        }
        else
        {
            MoveCameraManually(1f, 0f); // Move right
        }
    }
    else
    {
        if (Input.mousePosition.y < edgePadding)
        {
            MoveCameraManually(0f, -1f); // Move down
        }
        else if (Input.mousePosition.y > Screen.height - edgePadding)
        {
            MoveCameraManually(0f, 1f); // Move up
        }
    }
}
//else MoveCameraManually(0, 0);
}


    private void HandleAutoMovement()
    {
        // Check if there's a target for auto movement
        if (targetPosition != null && isAutoMoving)
        {
            float speed = isMoveSynced ? syncedSpeed : baseMovementSpeed;
            MoveCameraTowardsTarget(speed);

            // Check if the camera has reached the target position
            CheckAutoMovementCompletion();
        }
    }

    private void MoveCameraTowardsTarget(float speed)
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
        cameraBody.MovePosition(newPosition);
    }

    private void CheckAutoMovementCompletion()
    {
        if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
        {
            isAutoMoving = false;
            isMoveSynced = false;
        }
    }

    public static void SetTarget(Vector2 goal)
    {
        Instance.targetPosition = goal;
        Instance.isAutoMoving = true;
        Instance.isMoveSynced = false;
    }

    public static void SetSyncedTarget(Vector2 goal)
    {
        Instance.targetPosition = goal;
        Instance.isAutoMoving = true;
        Instance.isMoveSynced = true;
    }
}
