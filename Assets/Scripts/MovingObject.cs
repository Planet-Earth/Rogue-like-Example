using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour {

	public float moveTime = 0.1f;
	public LayerMask blockingLayer;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
	private float inverseMoveTime;

	// Use this for initialization
	protected virtual void Start ()
	{
		boxCollider = GetComponent<BoxCollider2D> ();
		rb2D = GetComponent<Rigidbody2D> ();
		inverseMoveTime = 1f / moveTime;
	}

	protected bool Move (int xDir, int yDir, out RaycastHit2D hit)
	{
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (xDir, yDir);
		print("boxCollider.enabled=false");
		boxCollider.enabled = false;
		print("Physics2D");
		hit = Physics2D.Linecast (start, end, blockingLayer);
		print("boxCollider.enabled=true");
		boxCollider.enabled = true;
		print("bool Move, before SmoothMovement");
		if (hit.transform == null)
		{
			print(hit.transform);
			StartCoroutine(SmoothMovement (end));
			return true;
		}

		return false;
	}

	protected IEnumerator SmoothMovement (Vector3 end)
	{
		print("In SmoothMovement");
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

		while (sqrRemainingDistance > float.Epsilon)
		{
			Vector3 newPosition = Vector3.MoveTowards (rb2D.position, end, inverseMoveTime * Time.deltaTime);
			rb2D.MovePosition(newPosition);
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;
			yield return null;
		}
	}

	protected virtual void AttemptMove <T> (int xDir, int yDir)
		where T : Component
	{
		print("void AttemptMove");
		RaycastHit2D hit;
		bool canMove = Move(xDir, yDir, out hit);

		if (hit.transform == null)
			return;

		T hitComponent = hit.transform.GetComponent<T>();

		if (!canMove && hitComponent != null)
			OnCantMove(hitComponent);
	}

	protected abstract void OnCantMove <T> (T component)
		where T : Component;
 }