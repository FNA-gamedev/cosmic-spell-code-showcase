<div id="top"></div>

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<br />

<div align="center">
  <a href="https://github.com/FNA-gamedev/cosmic-spell-code-showcase"><img src="images/fna-gamedev-logo.png" alt="Logo" width="256" height="256"></a>
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
	<li><a href="#contact">Contact</a></li>
  </ol>
</details>

## About The Project

This is the logical framework for a module designed to implement a progression system that rewards users based on their progress in the game.

* Use of Dependency Injection with Zenject and Reactive Properties with UniRx as to provide support to SOLID principles and events in real time respectively.
* It includes the DTOs required to define the system’s base configuration, the various milestones, as well as the configuration of rewards and visual features to be used in a future implementation of views / UI.
* Progress logic, including configuration parsing, model creation and management of the user’s progress in accordance with these.
* Management of the module’s data persistence in an isolated save file that can be integrated into a larger save file.
* Submission of metrics and analytics based on user interaction with the module or the achievement of milestones.
* Definition of consumables for permanent use (which can be extended to include one-off use). This allows them to be activated and managed independently of the other features.
* Cheats to force the feature to appear (for quality assurance and testing purposes).


<p align="right">(<a href="#top">back to top</a>)</p>

### Built With

* [Unity 2022.3.33f1 LTS](https://unity.com/es/releases/editor/archive) Core engine for game development on mobile platforms.
* [Mathjis Bakker - Extenject Dependency Injection IOC](https://assetstore.unity.com/packages/tools/utilities/extenject-dependency-injection-ioc-157735) For dependency injection.
* [Neuecc - UniRx - Reactive Extensions for Unity](https://assetstore.unity.com/packages/tools/integration/unirx-reactive-extensions-for-unity-17276) Events management and changes in real time.
* [Demigiant - DOTween (HOTween v2)](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676) Animations managements on views / UI.

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

## Contact

Project Link: [https://github.com/FNA-gamedev/cosmic-spell-code-showcase](https://github.com/FNA-gamedev/cosmic-spell-code-showcase)

<a href="https://linkedin.com/in/francisco-navas-sanchez/"><img src="images/LinkedIn_icon.png" alt="LinkedIn" width="32" height="32"></a>

<p align="right">(<a href="#top">back to top</a>)</p>

[contributors-shield]: https://img.shields.io/github/contributors/FNA-gamedev/cosmic-spell-code-showcase.svg?style=for-the-badge
[contributors-url]: https://github.com/FNA-gamedev/cosmic-spell-code-showcase/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/FNA-gamedev/cosmic-spell-code-showcase.svg?style=for-the-badge
[forks-url]: https://github.com/FNA-gamedev/cosmic-spell-code-showcase/network/members
[stars-shield]: https://img.shields.io/github/stars/FNA-gamedev/cosmic-spell-code-showcase.svg?style=for-the-badge
[stars-url]: https://github.com/FNA-gamedev/cosmic-spell-code-showcase/stargazers
[issues-shield]: https://img.shields.io/github/issues/FNA-gamedev/cosmic-spell-code-showcase.svg?style=for-the-badge
[issues-url]: https://github.com/FNA-gamedev/cosmic-spell-code-showcase/issues
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/francisco-navas-sanchez/

