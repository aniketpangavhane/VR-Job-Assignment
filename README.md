# VR Job Assignment

## Overview

This project is a Virtual Reality (VR) application developed in Unity using the XR Interaction Toolkit. The application allows users to interact with objects in a VR environment by grabbing and placing a cube into the correct container.

The project demonstrates fundamental VR interaction concepts including object grabbing, collision detection, trigger-based events, visual feedback, audio feedback, and user interface integration.

---

## Features

### VR Interaction
- Grab and release cube using XR controllers
- XR Device Simulator support for testing without a headset
- Smooth object interaction using XR Interaction Toolkit

### Gameplay
- Place the cube into the correct container
- Success detection using trigger colliders
- Failure detection for incorrect containers
- Cube snaps to the center of the correct container

### Feedback System
- Success message display
- Failure message display
- Success sound effect
- Failure sound effect
- Cube color change on success
- Cube scaling animation on success

### User Interface
- Instructions panel
- Start button
- Restart button
- Exit button
- Timer display
- Attempt counter

---

## Technologies Used

- Unity 2022.3 LTS
- C#
- XR Interaction Toolkit
- TextMeshPro
- Unity UI System

---

## Project Structure

```text
Assets
│
├── Scripts
│   ├── GameManager.cs
│   ├── ContainerTrigger.cs
│   ├── WrongContainerTrigger.cs
│   ├── GrabSound.cs
│   ├── CubeHoverEffect.cs
│   └── MovementSound.cs
│
├── Audio
│   ├── Success.wav
│   ├── Failure.wav
│   ├── Grab.wav
│   └── Footsteps.wav
│
├── Materials
├── Prefabs
├── Scenes
└── XR
