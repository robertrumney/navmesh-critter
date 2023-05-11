using UnityEngine;

public class ImproveRagdoll : MonoBehaviour
{
    // The maximum force that can be applied to each limb to prevent it from moving too much
    public float maxForce = 100f;

    const string head = "GOAT_ Head";
    const string spine = "GOAT_ Spine1";

    // Awake is called when the game object is initialized
    private void Awake()
    {
        // Get the character joint components of each limb of the ragdoll
        CharacterJoint[] joints = GetComponentsInChildren<CharacterJoint>();

        // Modify the joint properties for each limb
        // Iterate over the joints
        foreach (CharacterJoint joint in joints)
        {
            // Use a switch statement to check the name of the joint
            switch (joint.name)
            {
                case head:
                case spine:

                    // Skip joints above the neck
                    continue;

                default:

                    // Set the swing and twist limits for the current joint
                    SetSwingAndTwistLimits(joint);

                    // Calculate the force to apply to the joint
                    Vector3 force = CalculateForce(joint.transform.position, Vector3.zero);

                    // Apply the force to the joint
                    ApplyForceToJoint(joint, force);

                    break;
            }
        }
    }

    // Applies a force to a CharacterJoint to keep it in place
    private void ApplyForceToJoint(CharacterJoint joint, Vector3 force)
    {
        // Apply the force to the joint
        joint.GetComponent<Rigidbody>().AddForce(force, ForceMode.Acceleration);
    }

    // Sets the swing and twist limits for a CharacterJoint
    private void SetSwingAndTwistLimits(CharacterJoint joint)
    {
        // Set the joint's swing and twist limits to allow for more natural movement
        joint.swing1Limit = new SoftJointLimit { limit = 30f };
        joint.swing2Limit = new SoftJointLimit { limit = 30f };
        joint.lowTwistLimit = new SoftJointLimit { limit = -45f };
        joint.highTwistLimit = new SoftJointLimit { limit = 45f };
    }

    // Calculate the force needed to move the given limb to the target position
    private Vector3 CalculateForce(Vector3 currentPosition, Vector3 targetPosition)
    {
        // Calculate the distance between the current position and the target position
        Vector3 distance = targetPosition - currentPosition;

        // Calculate the force needed to move the limb to the target position,
        // but make sure it doesn't exceed the maximum force
        Vector3 force = Vector3.ClampMagnitude(distance * maxForce, maxForce);

        return force;
    }
}
