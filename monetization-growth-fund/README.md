<div id="top"></div>

<div align="center">
  <a href="https://github.com/FNA-gamedev/cosmic-spell-code-showcase"><img src="images/increasing-bar-graph.png" alt="Logo" width="256" height="256"></a>
  <h3 align="center">Code Showcase</h3>
    <p align="center">
      <a href="https://github.com/FNA-gamedev/cosmic-spell-code-showcase"><strong>Explore the docs »</strong></a>
      <br />
      <a href="https://github.com/FNA-gamedev/cosmic-spell-code-showcase/issues">Report Bug</a>
      ·
      <a href="https://github.com/FNA-gamedev/cosmic-spell-code-showcase/issues">Request Feature</a>
    </p>
</div>

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#contributing">Contributing</a></li>
  </ol>
</details>

## About The Project

This is the logical framework for a module designed to implement a progression system that rewards users based on their progress in the game.

* It includes the DTOs required to define the system’s base configuration, the various milestones, as well as the configuration of rewards and visual features to be used in a future implementation of views / UI.
* Progress logic, including configuration parsing, model creation and management of the user’s progress in accordance with these.
* Management of the module’s data persistence in an isolated save file that can be integrated into a larger save file.
* Submission of metrics and analytics based on user interaction with the module or the achievement of milestones.
* Definition of consumables for permanent use (which can be extended to include one-off use). This allows them to be activated and managed independently of the other features.
* Cheats to force the feature to appear (for quality assurance and testing purposes).


<p align="right">(<a href="#top">back to top</a>)</p>

### Built With

* [Unity 2022.3.33f1 LTS](https://unity.com/es/releases/editor/archive) Como motor base de desarrollo de juegos en plataformas móviles.
* [Mathjis Bakker - Extenject Dependency Injection IOC](https://assetstore.unity.com/packages/tools/utilities/extenject-dependency-injection-ioc-157735) Para la injección de dependencias.
* [Neuecc - UniRx - Reactive Extensions for Unity](https://assetstore.unity.com/packages/tools/integration/unirx-reactive-extensions-for-unity-17276) Para la gestión de eventos y cambios en tiempo real.
* [Demigiant DOTween (HOTween v2)](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676) Para la gestión de animaciones en vistas / UI.

<p align="right">(<a href="#top">back to top</a>)</p>

## Getting Started

### Prerequisites

1. You need to have installed Unity 2022.3.33f1 LTS on your local machine.  

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/FNA-gamedev/cosmic-spell-code-showcase.git
   ```
2. Open the project using Unity from Unity Hub or directly from the solution file (.SLN)

<p align="right">(<a href="#top">back to top</a>)</p>

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>

