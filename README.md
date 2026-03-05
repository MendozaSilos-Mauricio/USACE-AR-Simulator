# USACE AR Water Pollution Simulator 🌊📱

### 🎥 Project Demo
[![USACE AR Wetlands Demo](https://img.youtube.com/vi/Pp4gEzhVS2A/0.jpg)](https://www.youtube.com/watch?v=Pp4gEzhVS2A)

This project is in partnership with the **University of Texas at Arlington (UTA)** and the **U.S. Army Corps of Engineers (USACE)**. 

An interactive, marker-based Augmented Reality application developed for the USACE. This project serves as an educational exhibit designed to teach the public—targeting 10,000+ views—about the environmental impacts of stormwater runoff, pollution, and the critical importance of wetland conservation.

*(Note: See the `/Documentation` folder for full engineering specifications).*

---

### 📱 App Installation Guide (Android)
Want to try the app on your Android device? 
1. Navigate to the **Releases** section on the right-hand side of this repository.
2. Download the latest `AR_Wetlands_.apk` file.
3. Open the APK from your device’s file manager. *(If prompted, allow your device to install apps from unknown sources in settings).*
4. Tap **Install**. 
5. Open the app, tap **Begin Experience**, and point your device at the designated AR marker to start the simulation!

### 💻 Developer Setup Instructions
To run this project locally in Unity:
1. Clone or download this repository.
2. Open **Unity Hub** and click "Add Project from Disk."
3. Select the `/UnityProject` folder.
4. Open the main scene.
*Note: This project contains paid assets. These are for educational/project use only and should not be redistributed publicly.*

---

### 🛠️ Tech Stack & Architecture
* **Engine:** Unity 3D
* **Language:** C#
* **AR Framework:** AR Foundation (ARCore/ARKit)
* **Design Pattern:** Component-Based Architecture
* **Project Management:** Agile / Scrum

### 🚀 Technical Highlights & Responsibilities 
As the **Lead Software Developer** on a 5-member Agile team, my primary focus was on programming robust AR interactions and integrating the underlying technology stack:

* **Marker-Based AR Integration:** Engineered the image-tracking systems using AR Foundation to dynamically anchor 3D environments to physical exhibit markers, ensuring stable tracking across varying lighting conditions.
* **Interactive Event Systems:** Developed modular C# scripts to handle user inputs, triggering synchronized animations and state changes to simulate environmental degradation and restoration.
* **Agile Leadership:** Managed version control, resolved merge conflicts, and organized sprints to successfully integrate assets and scripts from multiple team members into a stable, deployable product prototype.
* **Engineering Documentation:** Co-authored comprehensive technical documentation including Software Requirements Specifications (SRS), Architectural Design Specifications (ADS), and Detailed Design Specifications (DDS) found in the `/Documentation` directory.

### 👥 Team Contributions
* **Mauricio Mendoza-Silos (Lead):** Built core project structure, tabletop terrain design and implementation, water animations, and handled client communication/integration.
* **Adrian Macias:** Developed app screens, UI functionality, construction site scene, and on-scene narration.
* **Nooraldeen Alsmady:** Designed and animated the factory scene; enhanced visuals and overall AR experience.
* **Yahia Khaled Elsaad:** Designed neighborhood scene and assisted with animations.
* **Mohamad Nabih Alkhateeb:** Partnered on neighborhood scene and animation features.

---

### 📂 Repository Structure
* `/UnityProject` - Contains the complete Unity project, C# scripts (`Assets/MyScripts`), AR markers, and 3D assets.
* `/Documentation` - Contains all formal engineering documentation and sponsor posters.
