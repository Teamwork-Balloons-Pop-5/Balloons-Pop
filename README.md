<h1 align="center">Balloons Pop Documenation</h1>
###0. Created the basic structure of the main project
###1. Refactoring Classes

	1.0 Renaming classes
		- Renamed baloni.cs to Balloons.cs
		- Renamed klasacia.cs to Highscore.cs
	
	1.1. Renaming Constructurs
	
	1.2. Renaming Fields
	
	1.3. Adding Methods
	
	1.4. Adding Validation
	
	1.5. Adding Properties
		- Added properties Name and Value in Highscore.cs
	
###2. Refactoring Methods
	
	2.1. Renaming Methods
		- Renamed Doit to CheckIfWinner in Balloons.cs
	
	2.2. Adding unit tests
	
	2.3. Separating Methods
	
	2.4. Renaming Parameters
		- Renamed matrix to balloonsMatrix in CheckLeft method
		- Renamed matrix to balloonsMatrix in CheckRight method
		- Renamed matrix to balloonsMatrix in CheckUp method
		- Renamed matrix to balloonsMatrix in CheckDown method
		- Renamed rowAtm to row and columnAtm to column in Change method
		- Renamed matrix to field in CheckIfWinner method
	
###3. Refactoring Variables, Expressions, Constants, Control structures, Exceptions, Comments
	
	3.1. Variables
		- Ranamed temp to balloonsMatrix in Balloons.cs
		- Renamed randNumber to randomNumber in Balloons.cs
		- Renamed tempByte to numberToInsert in Balloons.cs
		- Renamed stek to columnValues in CheckIfWinner method
		
	3.2. Constants
		- Added constants for:
			- Global game messages
			- Magic values
			- Exception error messages
			- UI Title header
			- Scoreboard template
	
	3.3. Control structures
	
	3.4. Exceptions
		- Created appropriate exceptions for the project
			- CannotBeNullException
			- IntNotEqualOrGreaterThan
			- NotPositiveIntegerException
			- NotValidLenghtStringException
	3.5. Comments
		- Removed all inappropriate comments
		
	3.6. StyleCop Refactoring
		- Refactored all StyleCop errors in the entire project
###4. Add Interfaces
		- Added: 
			- IEngine
			- IPopStrategy
			- IPrinter
			- IReader
			- ICommand
###5. Implement design patterns
		- Factory Method
		- Strategy
		- Facade
###6. Add new functionalities
		- UI
		- Levels - different size of playfield
		- Different strategies to pop balloons
		- Coloring the balloons
		- New exception for the project
		- Validator
		- Export data to txt file
