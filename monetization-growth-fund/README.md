# Sudoku
	Sudoku game for technical test
 
# Mechanics
# 1) 4 Difficulty modes
	With a simple array definition, we can achieve multiples levels for different difficulty mode from easy to challenge as within the game.
	
# 2) Game feel
	Several features have being include to control the gameplay workflow easily.
	
	# Edition mode (default)
	Allows us to complete the sudoku, the highlighting features make easier to hace an overview of resolution.
	
	# Notes mode
	Allow us to include possible solution(s) for each square (also delete them as the game goes on). Cells set by default (already with the correct value) are not editable or able to take notes.

	# Eraser mode 
	Delete either all notes and the single value of a cell.
	
# 3) Future proposals
	# Monetization by ads
	We can use ads to allow user to continue a current game further from the default opportunites or lives implemented.
	
	# Persistent data
	Storing current game (just the last one or differenciate among difficulty modes) would improve the engagement.
	
	# Multiplayer interaction
	Thought number of levels solved, time spent or sharing a sudoku with others may provide the game with social features more attractive for players.
	
	# Offline game definition
	To provide games with the bundle data to extend the game (levels, features...). In our case that can make easier for designer to include new boards to every difficulty mode through excel sheets or a server panel.

	
# Code arquitecture and implementation
	The aim of this project is to show how logic and UI can be separated as well as differente funcionalities added as modules or utils.
	
	# 1) SOLID principles
		All code within this project has been implemented following the SOLID principles.
		Each script as unique responsability within the game with a central hub (GameplaySystem) to control interaction workflow. 
		Several interfaces and class inheritance has been implemented to allow scalability and reusability (open-close principle) throught the Liskov's substitution principle.
		Finally, using Zenject has allow dependy injection without using singletons or other dependent structures to prevent any future technical debt.
		
	# 2) Zenject
		Each scene has its own SceneContext to control and limit dependency among them. The project context provide us with the transient information we need from one to another.
		
	# 3) DoTween
		To avoid the use of animators for core UI interaction, we have used DoTween: menu show in/out, button click animation or transitions... we can have "animations" being used with differente elements to avoid animation controllers or clips to multiply exponentially.
		
	# 4) Hexagonal arquitecture and modularity
		Code design has been conducted under the code pattern and arquitecture of the hexagonal modules arquitecture: one module its encharge of a complex feature of the game completely isolated from the game and other modules.
		
		To provide the game with the module funcionality we use the primary interfaces as API to send messages to the module to work with the data.
		
		In order to connect with another modules for data adquisition, we use the secondary interfaces as contracts or services for information exchange.
		
		Secondary interfaces or services allows or modules to be customized in every single game within compromising the original implementation.
		
	# 5) Utils
		As useful tools, there are several scripts extending common classes' functionality which can be also move among project or games with no impact in core and kernel systems.
		
