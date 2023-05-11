# Animal Script

The Animal script is a component written in C# for the Unity game engine. It controls the behavior of an animal in the game, providing functionalities such as wandering, being scared, taking damage, and dying.

## Features

- Random wandering within a specified radius.
- Scare functionality triggered by an external event.
- Damage application and death simulation.
- Animation control using an Animator component.
- Navigation using a NavMeshAgent component.
- Rigidbody manipulation for physics-based reactions.

## Usage

1. Attach the Animal script to the GameObject representing the animal in your Unity scene.
2. Set the desired values for the public variables in the script inspector:
   - **Wander Radius**: The radius within which the animal can wander.
   - **Wander Timer**: The time interval between wander movements.
   - **Animator**: Reference to the Animator component used for animation.
   - **Live Collider**: Collider component used when the animal is alive.
   - **Dead Collider**: Collider component used when the animal is dead.
   - **Sound**: AudioClip played when the animal is scared.
   - **Disable**: GameObject to disable when the animal dies.
   - **Chest**: GameObject representing the animal's chest (not used in the provided code).
3. Ensure the GameObject has a NavMeshAgent component attached for navigation purposes.
4. Implement the missing functions, such as `AlertCallback()`, to customize the behavior of the animal in response to specific events.
5. Use the provided helper function, `RandomNavSphere()`, to generate random positions on the NavMesh for the animal to wander to.

## Requirements

- Unity 3D Game Engine (version 2018.4 or higher)

## Additional Notes

- This script assumes the presence of other components and scripts referenced but not provided in the code such as `ImproveRagdoll` [Located in Tools folder]. Make sure to include this script in your project as well.

## License

This script is released under the [MIT License](LICENSE).

## Contribution

Contributions are welcome! If you find a bug or want to suggest an improvement, please open an issue or submit a pull request.

## Contact

For questions, feedback, or further information, please contact [Robert Rumney](mailto:robertrumney@example.com).
