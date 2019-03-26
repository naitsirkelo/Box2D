using UnityEngine;
using UnityEngine.Events;

public class FrogController2D : MonoBehaviour {

	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement

	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = false;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;


	public void Move(float move, bool crouch, bool jump) {

		Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity,
                                                    ref m_Velocity, m_MovementSmoothing);


	}


	private void Flip() {
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
