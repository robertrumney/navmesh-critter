# ImproveRagdoll Script

The ImproveRagdoll script is a supplementary component written in C# for the Unity game engine. It enhances the behavior of a ragdoll by applying forces to the limb joints and adjusting their properties to achieve more natural movement.

## Features

- Applies forces to each limb joint to keep them in place.
- Sets swing and twist limits for each limb joint to allow for more natural movement.
- Configurable maximum force for controlling limb movement.

## Usage

1. Attach the ImproveRagdoll script to the GameObject representing the ragdoll in your Unity scene.
2. Set the desired values for the public variables in the script inspector:
   - **Max Force**: The maximum force that can be applied to each limb joint to prevent excessive movement.
3. Ensure that the ragdoll's limbs have CharacterJoint components attached for physics-based interactions.
4. Adjust the `head` and `spine` constants in the script according to the names of the head and spine joints in your ragdoll (if necessary).
5. The script will automatically modify the joint properties and apply forces to each limb joint in the ragdoll during initialization.

## Additional Notes

- This script assumes the presence of a ragdoll with appropriate limb joints in the GameObject hierarchy.
- Customize the swing and twist limits by modifying the `SetSwingAndTwistLimits` function in the script to suit your specific needs.
- Adjust the force calculation in the `CalculateForce` function if you want to fine-tune the force applied to each limb joint.
- You may need to tweak the `maxForce` value to achieve the desired level of movement and stability for your ragdoll.

## License

This script is released under the [MIT License](LICENSE).

## Contribution

Contributions are welcome! If you find a bug or want to suggest an improvement, please open an issue or submit a pull request.

## Contact

For questions, feedback, or further information, please contact [Robert Rumney](mailto:robertrumney@gmail.com).
