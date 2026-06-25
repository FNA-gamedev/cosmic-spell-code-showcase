<div id="top"></div>

<div align="center">
  <a href="https://github.com/FNA-gamedev/cosmic-spell-code-showcase"><img src="../images/sudoku_icon.png" alt="Logo" width="256" height="256"></a>
  <h3 align="center">Sudoku prototype</h3>
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
	<li><a href="#mechanics">Mechanics</a></li>
	<li><a href="#code-arquitecture-and-implementation">Code arquitecture and implementation</a></li>
  </ol>
</details>

## About The Project

This is a basic prototype of a Sudoku game for mobile devices.

* All visual and audio assets are open-licensed (CC0).
* Includes a custom Editor attribute for selectively displaying interdependent attributes (ConditionalHideAttribute).
* Basic audio systems for managing background music and sound effects separately.
* Multi-layered UI and use of prefab pools for recurring elements.
* Basic scoring system and configuration management (audio settings).
* Basic extension methods for user-friendly data usage in the UI.

<p align="right">(<a href="#top">back to top</a>)</p>

### Built With

* [Unity 2022.3.33f1 LTS](https://unity.com/es/releases/editor/archive) Core engine for game development on mobile platforms.
* [Mathjis Bakker - Extenject Dependency Injection IOC](https://assetstore.unity.com/packages/tools/utilities/extenject-dependency-injection-ioc-157735) For dependency injection.
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
2. Open the project using Unity from Unity Hub.

<p align="right">(<a href="#top">back to top</a>)</p>

## Mechanics
+ 4 Difficulty modes  
	+ With a simple array definition, we can achieve multiples levels for different difficulty mode from easy to challenge as within the game.	
+ Game feel
	+ Several features have being include to control the gameplay workflow easily:
		+ Edition mode (default)
			+ Allows us to complete the sudoku, the highlighting features make easier to hace an overview of resolution.
		+ Notes mode
			+ Allow us to include possible solution(s) for each square (also delete them as the game goes on). Cells set by default (already with the correct value) are not editable or able to take notes.
		+ Eraser mode 
			+ Delete either all notes and the single value of a cell.	
+ Future proposals
	+ Implementation of unit tests
		+ Due to time constraints, this has not been possible.
	+ Include CI/CD based on Jenkins
		+ It has not been implemented during the prototyping phase, but it would be beneficial for an MVP or production phase following the relevant iterations.
	+ Monetization by ads
		+ We can use ads to allow user to continue a current game further from the default opportunites or lives implemented.
	+ Persistent data
		+ Storing current game (just the last one or differenciate among difficulty modes) would improve the engagement.
	+ Multiplayer interaction
		+ Thought number of levels solved, time spent or sharing a sudoku with others may provide the game with social features more attractive for players.
	+ Offline game definition
		+ To provide games with the bundle data to extend the game (levels, features...). In our case that can make easier for designer to include new boards to every difficulty mode through excel sheets or a server panel.
	
## Code arquitecture and implementation

The aim of this project is to show how logic and UI can be separated as well as differente funcionalities added as modules or utils.

+ SOLID principles
	+ All code within this project has been implemented following the SOLID principles.
 	+ Each script as unique responsability within the game with a central hub (GameplaySystem) to control interaction workflow.
  	+ Several interfaces and class inheritance has been implemented to allow scalability and reusability (open-close principle) throught the Liskov's substitution principle.
  	+ Finally, using Zenject has allow dependy injection without using singletons or other dependent structures to prevent any future technical debt.
+ Zenject
	+ Each scene has its own SceneContext to control and limit dependency among them. The project context provide us with the transient information we need from one to another.
+ DoTween
	+ To avoid the use of animators for core UI interaction, we have used DoTween: menu show in/out, button click animation or transitions... we can have "animations" being used with differente elements to avoid animation controllers or clips to multiply exponentially.
+ Utils
	+ As useful tools, there are several scripts extending common classes' functionality which can be also move among project or games with no impact in core and kernel systems.
		
<p align="right">(<a href="#top">back to top</a>)</p>

