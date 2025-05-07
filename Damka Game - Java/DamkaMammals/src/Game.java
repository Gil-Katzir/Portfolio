import java.util.Scanner;
public class Game {

	private static Mammals[][]Board = new Mammals[8][8]; //Game Board
	private static boolean gameIsOn = false; 
	public static String toFrom;//The user insert where he wants to move 
	private static int FromRow,FromCol,ToRow,ToCol;//the indexes that the user insert were matched to indexes in the array
	private static int [] CompPinsPlaces = new int [12];//An array that contains the positions of all the white pins on board 

	static Scanner sc = new Scanner(System.in);

	public static void main(String[] args) {
		DamkaPlay(); 
	} 

	// set board and starting the game
	private static void DamkaPlay() { 
		setBoard(); 
		if(Start()) 
			GameProcess();
	} 

	// The progress of the game
	private static void GameProcess() { 
		System.out.println("\n"+"The board:");
		displayBoard(); 
		while(gameIsOn) { 
			if(isComputerWin()||isUserTie()) {
				GameOver(); 
				break;
			}
			UserTurn();
			if(!gameIsOn)
				break;
			if(isUserWin()) {
				GameOver(); 
				break;
			}
			ComputerTurn();
		}//end while
	}

	//check if the user insert STOP
	private static boolean UserGiveUp() {
		if(toFrom.equals("STOP")){
			System.out.println("\n"+"Sorry, computer has won:(");
			GameOver();
			return true; 
		}
		return false;
	} 

	//The game is Over and set a new play
	private static void GameOver(){ 
		gameIsOn= false; 
		DamkaPlay();
	}

	//set the game board
	private static void setBoard () {//placing the pins on the board
		ResetBoard();
		setComputerPins();
		setUserPins	();
	}

	//set the pins of the computer
	private static void setComputerPins () {//placing the computer pins
		setCompDogs();
		setCompCats();
		setCompElephants();
		setCompMouses();
	}
	
	//set the pins of the user
	private static void setUserPins () {//placing the computer pins
		setUserDogs();
		setUserCats();
		setUserElephants();
		setUserMouses();
	}
	 
	//Reset the board for new game
	private static void ResetBoard () {//reset the computer pins
		for(int i=0; i<Board.length; i++) {
			for(int j=0; j<Board.length; j++) {
				Board[i][j]=null;
			}
		}
	}

	//set the dogs pins of computer
	private static void setCompDogs () {//placing the dogs computer pins
		Board[0][3]=  new Dog (2,Board);
		Board[1][0]=  new Dog (2,Board);
		Board[2][7]=  new Dog (2,Board);
	}

	//set the cats pins of computer
	private static void setCompCats () {//placing the cats computer pins
		Board[0][1]=  new Cat (2,Board);
		Board[1][6]=  new Cat (2,Board);
		Board[2][5]=  new Cat (2,Board);
	}

	//set the elephants pins of computer
	private static void setCompElephants () {//placing the elephants computer pins
		Board[0][5]=  new Elephant (2,Board);
		Board[1][2]=  new Elephant (2,Board);
		Board[2][1]=  new Elephant (2,Board);
	}

	//set the mouses pins of computer
	private static void setCompMouses () {//placing the mouses computer pins
		Board[0][7]=  new Mouse (2,Board);
		Board[1][4]=  new Mouse (2,Board);
		Board[2][3]=  new Mouse (2,Board);
	}
	
	//set the dogs pins of user
	private static void setUserDogs () {//placing the dogs User pins
		Board[5][6]=  new Dog (1,Board);
		Board[6][1]=  new Dog (1,Board);
		Board[7][2]=  new Dog (1,Board);
	}

	//set the cats pins of user
	private static void setUserCats () {//placing the cats User pins
		Board[5][4]=  new Cat (1,Board);
		Board[6][7]=  new Cat (1,Board);
		Board[7][0]=  new Cat (1,Board);
	}

	//set the elephants pins of user
	private static void setUserElephants () {//placing the elephants User pins
		Board[5][0]=  new Elephant (1,Board);
		Board[6][3]=  new Elephant (1,Board);
		Board[7][4]=  new Elephant (1,Board);
	}

	//set the mouses pins of user
	private static void setUserMouses () {//placing the mouses User pins
		Board[5][2]=  new Mouse (1,Board);
		Board[6][5]=  new Mouse (1,Board);
		Board[7][6]=  new Mouse (1,Board);
	}

	 
	//display the board 
	private static void displayBoard () {//print the board
		for(int i=0; i<Board.length ; i++) {
			for(int j=0; j<Board.length;  j++) {
				if(!displayFreePlace (i,j))
					if(!displayUnFreePlace (i,j))
						displayMammalPlace(i,j);
			}
			System.out.println();
		}
	}

	// display the free places *
	private static boolean displayFreePlace (int i,int j) {
		if(Board[i][j]==null && (i+j)%2!=0)	{
			System.out.print("*"+"\t");
			return true;
		}
		return false;
	}

	// display the un free places -
	private static boolean displayUnFreePlace (int i,int j) {
		if(Board[i][j]==null && (i+j)%2==0)	{
			System.out.print("-"+"\t");
			return true;
		}
		return false;
	}

	//display the mammals places
	private static void displayMammalPlace (int i,int j) {
		System.out.print(Board[i][j]+"\t");
	}

	//check if the user want to start a game
	private static boolean Start() { 
		System.out.println("Welcome to Fatma checkers. To start the game press 1, to exit press 0:");
		if(Press_1()) 
			return true; 
		return false;
	} 

	//Checking what is the user answered - Want to play or not (and check if is valid)
	public static boolean Press_1()  { 
		String choise = sc.next();
		while(!choise.equals("1") &&  !choise.equals("0")) {
			System.out.println("Press only 1 or 0");		
			choise = sc.next();
		}

		if(choise.equals("1")){
			gameIsOn=true; 
			return true;
		}
		else {
			if(choise.equals("0")) 
				System.out.println("Bye bye");
		}
		return false; 
	} 

	//Check if computer has won
	private static boolean isComputerWin() {  
		if(isUserPinsOnBoard())
			return false;

		System.out.println("Sorry, computer has won :(");
		return true; 
	}


	//Check if there is user pins on board
	private static boolean isUserPinsOnBoard() {
		for(int i=0; i<=7; i++) {
			for(int j=0; j<=7; j++) {
				if(Board[i][j]!=null && Board[i][j].getowner()==1) {
					return true; 
				}
			}
		}
		return false;
	}

	//Check if there is Computer pins on board
	private static boolean isUserWin() {
		if(isCompPinsOnBoard())
			return false; 

		System.out.println("Congratulations, user has won :)");
		return true; 
	}

	//Check if there is Computer pins on board
	private static boolean isCompPinsOnBoard() {
		for(int i=0; i<=7; i++) {
			for(int j=0; j<=7; j++) {
				if(Board[i][j]!=null && Board[i][j].getowner()==2 ) 
					return true; 
			}
		}
		return false;
	}

	//Check if the user can do any move
	private static boolean isUserTie() {
		for(int i=0; i<=7; i++) {
			for(int j=0; j<=7; j++) {
				if(Board[i][j]!=null && Board[i][j].getowner()==1) { //There is Red on board?
					FromRow= i; FromCol= j; ToRow= i; ToCol= j; 
					if(isUserNotStuck(i,j)){
						return false;
					}
				}
			}
		}
		System.out.println("well, unfortuntly it's a Tie...");
		return true;
	}

	//Check if the user has legal moves 
	private static boolean isUserNotStuck(int i, int j) { 
		if(Board[i][j].CanUserEatNow(FromRow, FromCol,new int[2][12])|| Board[i][j].CanUserMove(FromRow, FromCol))
			return true;
		return false;
	}

	//Print Computer tie message and end the game
	private static void isComputerTie() {  
		System.out.println("well, unfortuntly it's a Tie...");
		GameOver();
	}


	//The user is playing
	public static void UserTurn() {
		System.out.println("It's your turn, please enter your move.");
		UserInsertMove();
	} 


	//User insert where he wants to move his pin
	public static void UserInsertMove() {
		toFrom=sc.next();
		ConversionIndexs();
		UserMove();
	}

	//verify its five chars
	private static boolean is5chars () {
		if(toFrom.length()!=5)
			return false;
		return true;
	} 

	//converting the place of the pins to an index in the array
	private static void ConversionIndexs () {
		if(is5chars ()) {
			FromRow=ConversionFromRow();
			FromCol=ConversionFromColumn();
			ToRow=ConversionToRow();
			ToCol=ConversionToColumn();
		}
	}

	//the index row where the pin is now
	private static int ConversionToRow () {
		int toRow=8-(toFrom.charAt(0)-48);
		return toRow;
	}

	//the index Column where the pin is now
	private static int ConversionToColumn () {
		int toColumn = toFrom.charAt(1)-49;
		return toColumn;
	}

	//the index row where the pin wants to move
	private static int ConversionFromRow () {
		int fromRow=8-(toFrom.charAt(3)-48);
		return fromRow;
	}

	//the index Column where the pin wants to move
	private static int ConversionFromColumn () {
		int fromColumn = toFrom.charAt(4)-49;
		return fromColumn;
	}

	//Including checks and moves of the user
	private static void UserMove() { 
		if(!UserGiveUp()) { 
			if(UserMoveIsLegal()) { 
				if(Board[FromRow][FromCol].isOneStep(FromRow,FromCol,ToRow,ToCol)) {
					DoOneStep();
				} 

				else if(Board[FromRow][FromCol].isEat(FromRow,FromCol,ToRow,ToCol)) {   
					Board[FromRow][FromCol].MoveUserPins(FromRow,FromCol,ToRow,ToCol);
					DoMultiEat();
				} 
				else {
					System.out.println("This move is invalid, please enter a new move.");
					UserInsertMove();
				} 
			} 
			else 
				UserInsertMove();
		}
	} 

	//Do the user move 
	private static void DoOneStep () {
		Board[FromRow][FromCol].MoveUserPins(FromRow,FromCol,ToRow,ToCol);
		checkQ();
		System.out.println("\n"+"The board:");
		displayBoard();
	}

	//get the indexes of the multi eat 
	public static void InsertMultiEat () {
		System.out.println("\n"+"The board:");
		displayBoard();
		System.out.println("You have another eat. Please insert the next move. "); 
		toFrom=sc.next();
		ConversionIndexs();
	}

	//Do the multi eat  
	private static void DoMultiEat () {
		int [][] eatenPins = new int [2][12];
		eatenPins=ResetEatenCompPins(eatenPins);
		int j=0;
		eatenPins[0][j]= (FromRow+ToRow)/2; //the first eaten pin 
		eatenPins[1][j]= (FromCol+ToCol)/2;
		int newFromRow = ToRow; int newFromCol = ToCol;

		while(Board[ToRow][ToCol].CanUserEatAgain(ToRow, ToCol, eatenPins)) {
			InsertMultiEat();
			if(newFromRow==FromRow && newFromCol==FromCol) {
				if(Board[FromRow][FromCol].isEatAgain(FromRow,FromCol,ToRow,ToCol)) {
					Board[FromRow][FromCol].MoveUserPinsAgain(FromRow,FromCol,ToRow,ToCol);
					j++; 
					eatenPins[0][j]= (FromRow+ToRow)/2; //the last eaten pin
					eatenPins[1][j]= (FromCol+ToCol)/2;
					newFromRow=ToRow; newFromCol=ToCol;
				}
				else {
					System.out.println("This is not eating. Try to eat again");
					ToRow=newFromRow; ToCol=newFromCol;
				}
			}
			else {
				System.out.println("This is not eating. Try to eat again");
				ToRow=newFromRow; ToCol=newFromCol;
			}
		}
		checkQ(); 
		System.out.println("\n"+"The board:");
		displayBoard();
	}

	//check the queen if its suppose to be a queen and switch
	private static void checkQ () {
		if(Board[ToRow][ToCol] instanceof Elephant ) {
			if(((Elephant)Board[ToRow][ToCol]).isSupposeSwitchToQ_User(ToRow,ToCol))
				((Elephant)Board[ToRow][ToCol]).switchToQ(ToRow,ToCol);
		}
	}


	//check if the move is possible
	private static boolean UserMoveIsLegal () {
		if(isUserPin()){
			if(Board[FromRow][FromCol].PlaceIsFree(FromRow,FromCol,ToRow,ToCol)) {
				return true;		
			}
		}
		System.out.println("This move is invalid, please enter a new move.");
		return false; 
	}

	//check if this pin is user pin
	private static boolean isUserPin () {
		if(Board[FromRow][FromCol]!=null && Board[FromRow][FromCol].getowner()==1 ) 
			return true;
		return false;
	}

	// COMPUTER FUNCTIONS

	//The computer game process
	private static void ComputerTurn() {
		FindTheComputerPins(); 
		if(!checkComputerOptions()) {
			isComputerTie();
		}
		System.out.println("Computer has played."+"\n"+"The Board:");
		displayBoard();
	}


	//Find the computer pins on board
	private static void FindTheComputerPins() {
		ResetTheComputerPins();
		int counter=0;
		for (int i=0; i<=7; i++) {
			for(int j=0; j<=7; j++) {
				if(Board[i][j]!=null && Board[i][j].getowner()==2 ) {
					CompPinsPlaces[counter] = i*10+j;
					counter++;
				}
			}
		}
	} 


	//Reset all the places of the white pins
	private static void ResetTheComputerPins() { 
		for (int i=0; i<=11; i++) {
			CompPinsPlaces[i]=0;
		}
	}


	// reset the eaten pins for this turn
	private static int [][] ResetEatenCompPins(int [][]eatenPins) {
		for( int k=0; k<=11; k++) {  
			eatenPins[0][k]=0; eatenPins[1][k]=0;
		}
		return eatenPins;
	}
	//check the computer options to move or eat
	private static boolean checkComputerOptions() {
		int [][] eatenUserPins = new int [2][12];
		eatenUserPins=ResetEatenUserPins(eatenUserPins);

		if(!checkComputerEatOptions(eatenUserPins)) {
			if(!checkComputerOneStepOptions())
				return false;
		}
		else {
			int j=1;
			while(isCompCanEatAgain(eatenUserPins,j)) 
				j++;
		}

		if(Board[ToRow][ToCol] instanceof Elephant ) {
			if(((Elephant)Board[ToRow][ToCol]).isSupposeSwitchToQ_Comp(ToRow,ToCol))
				((Elephant)Board[ToRow][ToCol]).switchToQ(ToRow,ToCol);
		}
		return true;
	}


	//Check if the computer can eat and move the pins 
	private static boolean checkComputerEatOptions(int [][] eatenUserPins){

		int RandomC = RandomCompPin(); //Choose one of the computer pins randomly
		while(!AllCompPinsChecked()) {
			if(isCompCanEatFirst(RandomC, eatenUserPins)) 
				return true;
			else 
				RandomC = RandomCompPin();
		}
		return false;
	}


	//Find random computer pin
	private static int RandomCompPin(){
		int RandomC = (int) ((Math.random()*(12))); 
		if(RandomC!=12) 
			UpdateIndexsAfterRandom(RandomC);
		else 
			return 0; 	

		return RandomC;
	}


	//Update the new "from" indexes 
	private static void UpdateIndexsAfterRandom(int RandomC){
		if(CompPinsPlaces[RandomC]!=0) {
			FromRow=CompPinsPlaces[RandomC]/10; 
			FromCol=CompPinsPlaces[RandomC]%10;
		}
		else {
			FromRow=0; FromCol=0; ToRow=0;ToCol=0;
		}
	}



	//Check if all the computer pins have been checked
	private static boolean AllCompPinsChecked() {
		for(int i=0; i<=11; i++)
			if(CompPinsPlaces[i]!=0)
				return false;
		return true;
	}

	//Check if the computer can eat on the first move on his turn
	private static boolean isCompCanEatFirst(int RandomC, int [][] eatenUserPins){ 
		if(Board[FromRow][FromCol]!=null) {
			if(Board[FromRow][FromCol].canCompEat(FromRow,FromCol,FromRow+2,FromCol+2,eatenUserPins)) { //left forward
				Board[FromRow][FromCol].EatAndRemoveEnemy(FromRow,FromCol,FromRow+2,FromCol+2);
				ToRow=FromRow; ToCol=FromCol;
				FromRow=FromRow+2; FromCol=FromCol+2; 
				AddFirstEatenPin(eatenUserPins);
				ToRow=FromRow; ToCol=FromCol;
				return true; 
			}

			if(Board[FromRow][FromCol].canCompEat(FromRow,FromCol,FromRow+2,FromCol-2,eatenUserPins)) { //right forward
				Board[FromRow][FromCol].EatAndRemoveEnemy(FromRow,FromCol,FromRow+2,FromCol-2);
				ToRow=FromRow; ToCol=FromCol;
				FromRow=FromRow+2; FromCol=FromCol-2; 
				AddFirstEatenPin(eatenUserPins);
				ToRow=FromRow; ToCol=FromCol;
				return true; 
			}


			if(Board[FromRow][FromCol] instanceof Elephant ) {
				if(((Elephant)Board[FromRow][FromCol]).isQ(FromRow,FromCol)) {

					if((Board[FromRow][FromCol]).canCompEat(FromRow,FromCol,FromRow-2,FromCol+2,eatenUserPins)) { //left back
						Board[FromRow][FromCol].EatAndRemoveEnemy(FromRow,FromCol,FromRow-2,FromCol+2); 
						ToRow=FromRow; ToCol=FromCol;
						FromRow=FromRow-2; FromCol=FromCol+2; 
						AddFirstEatenPin(eatenUserPins);
						ToRow=FromRow; ToCol=FromCol;
						return true; 
					}

					if(((Elephant)Board[FromRow][FromCol]).canCompEat(FromRow,FromCol,FromRow-2,FromCol-2,eatenUserPins)) { //right back
						Board[FromRow][FromCol].EatAndRemoveEnemy(FromRow,FromCol,FromRow-2,FromCol-2); 
						ToRow=FromRow; ToCol=FromCol;
						FromRow=FromRow-2; FromCol=FromCol-2; 
						AddFirstEatenPin(eatenUserPins);
						ToRow=FromRow; ToCol=FromCol;
						return true; 
					}
				}
			}
		} //null
		CompPinsPlaces[RandomC]=0; //the pin has been checked
		return false;	
	}


	//Check if the computer can eat on the first move on his turn
	private static boolean isCompCanEatAgain(int [][]eatenUserPins,int j){ 

		if(Board[FromRow][FromCol]!=null) {
			if(Board[FromRow][FromCol].canCompEatAgain(FromRow,FromCol,FromRow+2,FromCol+2,eatenUserPins )) {
				Board[FromRow][FromCol].EatAndRemoveEnemy(FromRow,FromCol,FromRow+2,FromCol+2);
				ToRow=FromRow; ToCol=FromCol;
				FromRow=FromRow+2; FromCol=FromCol+2; 
				AddEatenPin(eatenUserPins,j);
				ToRow=FromRow; ToCol=FromCol;
				return true; 
			}

			if(Board[FromRow][FromCol].canCompEatAgain(FromRow,FromCol,FromRow+2,FromCol-2,eatenUserPins)) {
				Board[FromRow][FromCol].EatAndRemoveEnemy(FromRow,FromCol,FromRow+2,FromCol-2);
				ToRow=FromRow; ToCol=FromCol;
				FromRow=FromRow+2; FromCol=FromCol-2; 
				AddEatenPin(eatenUserPins,j);
				ToRow=FromRow; ToCol=FromCol;
				return true; 
			}


			if((Board[FromRow][FromCol]).canCompEatAgain(FromRow,FromCol,FromRow-2,FromCol+2,eatenUserPins)) { //queen can move back
				Board[FromRow][FromCol].EatAndRemoveEnemy(FromRow,FromCol,FromRow-2,FromCol+2); 
				ToRow=FromRow; ToCol=FromCol;
				FromRow=FromRow-2; FromCol=FromCol+2; 
				AddEatenPin(eatenUserPins,j);
				ToRow=FromRow; ToCol=FromCol;
				return true; 
			}

			if((Board[FromRow][FromCol]).canCompEatAgain(FromRow,FromCol,FromRow-2,FromCol-2,eatenUserPins)) { //queen can move back
				Board[FromRow][FromCol].EatAndRemoveEnemy(FromRow,FromCol,FromRow-2,FromCol-2); 
				ToRow=FromRow; ToCol=FromCol;
				FromRow=FromRow-2; FromCol=FromCol-2; 
				AddEatenPin(eatenUserPins,j);
				ToRow=FromRow; ToCol=FromCol;
				return true; 
			}
		}
		return false;	
	}

	// reset the eaten pins for this turn
	private static int [][] ResetEatenUserPins(int [][]eatenUserPins) {
		for( int k=0; k<=11; k++) {  
			eatenUserPins[0][k]=0; eatenUserPins[1][k]=0;
		}
		return eatenUserPins;
	}

	//Add to the eaten user pins array the first pin
	private static void AddFirstEatenPin(int [][] eatenUserPins){ 
		eatenUserPins[0][0]= (FromRow+ToRow)/2;
		eatenUserPins[1][0]= (FromCol+ToCol)/2;
	}

	//Add to the eaten user pins array the  pin
	private static void AddEatenPin(int [][] eatenUserPins, int j){ 
		if(j<=11) {
			eatenUserPins[0][j]= (FromRow+ToRow)/2;
			eatenUserPins[1][j]= (FromCol+ToCol)/2;
		}
	}

	//Check if the computer can move one step and move the pins
	private static boolean checkComputerOneStepOptions() {
		if(!ComputerOneStep()) 
			return false;			
		return true;
	}

	//Check if the computer has option to move one step
	private static boolean ComputerOneStep(){
		FindTheComputerPins();
		int RandomC = RandomCompPin(); //Choose one of the white pins randomly
		while(!AllCompPinsChecked()) {
			if(ComputerPossibleMoveOneStep(RandomC)) 
				return true;
			else 
				RandomC = RandomCompPin();
		}
		return false;
	}

	//Check if the computer pin can move one step
	private static boolean ComputerPossibleMoveOneStep(int RandomC){
		if(Board[FromRow][FromCol]!=null) {
			if(Board[FromRow][FromCol].MoreThanOneWay(FromRow,FromCol,ToRow,ToCol)) {
				Board[FromRow][FromCol].ChooseRandomSideAndMove(FromRow,FromCol,ToRow,ToCol);
				return true;
			}
			if(Board[FromRow][FromCol].CanCompMoveOneWay(FromRow,FromCol,ToRow,ToCol))
				return true; 
		}
		CompPinsPlaces[RandomC]=0; //The pin has been checked
		return false;	//Can not move
	}

}//class

