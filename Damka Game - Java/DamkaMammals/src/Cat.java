public class Cat extends Mammals {

	public Cat(int owner, Mammals[][]Board) {
		super(owner, Board);
	}
	
	//return the pin on board
	public String toString() {
		return ("C"+this.owner);
	}

	//check if place is free 
	public  boolean PlaceIsFree (int FromRow, int FromCol, int ToRow, int ToCol) {
		if(Board[ToRow][ToCol]==null) 
			return true; 
		return false; 
	}

	//check if its user one step 
	public  boolean isOneStep(int FromRow, int FromCol, int ToRow, int ToCol) {
		if(isStepForward(FromRow,FromCol,ToRow,ToCol) || isStepBack(FromRow,FromCol,ToRow,ToCol))
			return true;
		return false;
	}

	//check if its user one step forward
	public  boolean isStepForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if(isStepLeftForward(FromRow,FromCol,ToRow,ToCol) || isStepRightForward(FromRow,FromCol,ToRow,ToCol) ) 
			return true;
		return false;
	}


	//check if its user one step left forward
	public  boolean isStepLeftForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if((ToRow-FromRow==-1 && ToCol-FromCol==-1) || (ToRow-FromRow==0 && ToCol-FromCol==-1) || (ToRow-FromRow==-1 && ToCol-FromCol==0))
			//בדקנו גם אלכסון שמאלה גם שמאלה וגם ישר
			return true;
		return false;
	}

	//check if its user one step right forward
	public  boolean isStepRightForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if((ToRow-FromRow==-1 && ToCol-FromCol==1)  || (ToRow-FromRow==0 && ToCol-FromCol==1))
			//בדקנו גם אלסון ימינה גם ימינה 
			return true;
		return false;
	}


	//check if its user one step back
	public  boolean isStepBack(int FromRow, int FromCol, int ToRow, int ToCol) {
		if(isStepLeftBack(FromRow,FromCol,ToRow,ToCol)|| isStepRightBack(FromRow,FromCol,ToRow,ToCol))  
			return true;
		return false;
	}


	//check if its user one step left back
	public  boolean isStepLeftBack(int FromRow, int FromCol, int ToRow, int ToCol) {
		if((ToRow-FromRow==1 && ToCol-FromCol==-1) ||  (ToRow-FromRow==1 && ToCol-FromCol==0))
			return true;
		return false;
	}

	//check if its user one step right back
	public  boolean isStepRightBack(int FromRow, int FromCol, int ToRow, int ToCol) {
		if(ToRow-FromRow==1 && ToCol-FromCol==1)  
			return true;		
		return false;
	}
	
	//check if user can move 
	public boolean CanUserMove(int FromRow, int FromCol) {

		if (CanUserMoveForward(FromRow, FromCol, FromRow - 1, FromCol - 1)) { //left forward
			return true;
		}
		else if (CanUserMoveForward(FromRow, FromCol, FromRow - 1, FromCol + 1)) { //right forward
			return true;
		}
		else if (CanUserMoveForward(FromRow, FromCol, FromRow - 1, FromCol)) { // forward
			return true;
		}
		else if (CanUserMoveForward(FromRow, FromCol, FromRow , FromCol+1)) { // just right
			return true;
		}
		else if (CanUserMoveForward(FromRow, FromCol, FromRow , FromCol-1)) { // just left
			return true;
		}
		else if (CanUserMoveBack(FromRow, FromCol, FromRow + 1, FromCol + 1)) {  //right back
			return true;
		}
		else if (CanUserMoveBack(FromRow, FromCol, FromRow + 1, FromCol - 1)) {  //left back
			return true;
		}
		else if (CanUserMoveBack(FromRow, FromCol, FromRow + 1, FromCol)) {  // back
			return true;
		}
		else
			return false;
	}

	//check if user can move forward
	public boolean CanUserMoveForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (!ToOutOfBoundries(FromRow, FromCol, ToRow, ToCol) && PlaceIsFree(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}

	//check if user can move back
	public boolean CanUserMoveBack(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (!ToOutOfBoundries(FromRow, FromCol, ToRow, ToCol) && PlaceIsFree(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}

	
	//////computer

	//Check if the computer pin has more than one direction to move
	public boolean MoreThanOneWay(int FromRow, int FromCol, int ToRow, int ToCol){
		int Leftoptions=0;
		int Rightoptions=0;

		Rightoptions=CanCompMoveRight(FromRow,FromCol,ToRow,ToCol,Rightoptions);
		Leftoptions=CanCompMoveLeft(FromRow,FromCol,ToRow,ToCol,Leftoptions);

		if(Rightoptions >=1 && Leftoptions >=1)
			return true;
		return false;
	}

	
	//Check if the computer pin can move right forward 
	public int CanCompMoveRight(int FromRow, int FromCol, int ToRow, int ToCol, int Rightoptions){

		if( CanCompMoveRightForward(FromRow,FromCol,FromRow+1,FromCol-1)) //forward digaonal
			Rightoptions++;
		if( CanCompMoveRightForward(FromRow,FromCol,FromRow,FromCol-1)) //<-
			Rightoptions++;
		if( CanCompMoveRightBack(FromRow,FromCol,FromRow-1,FromCol-1)) // back right
			Rightoptions++;
		if( CanCompMoveRightForward(FromRow,FromCol,FromRow+1,FromCol)) //forward 
			Rightoptions++;
		return Rightoptions;
	}

	
	//Check if the computer pin can move left forward 
	public int CanCompMoveLeft(int FromRow, int FromCol, int ToRow, int ToCol, int Leftoptions){
		if(CanCompMoveLeftForward(FromRow,FromCol,FromRow+1,FromCol+1)) //forward digaonal
			Leftoptions++;
		if(CanCompMoveLeftForward(FromRow,FromCol,FromRow,FromCol+1)) //->
			Leftoptions++;
		if(CanCompMoveLeftBack(FromRow,FromCol,FromRow-1,FromCol+1)) // back left
			Leftoptions++;
		if(CanCompMoveLeftBack(FromRow,FromCol,FromRow-1,FromCol)) //back
			Leftoptions++;
		return Leftoptions;
	}
	
	//choose side for the computer move 
	public  void ChooseRandomSideAndMove (int FromRow, int FromCol, int ToRow, int ToCol) {
		if(Math.random()<=0.3) 
			CheckRightAndMove(FromRow,FromCol,ToRow,ToCol);
		else
			CheckLeftAndMove(FromRow,FromCol,ToRow,ToCol);
	}

	//check if computer can move right and do move  
	public  void CheckRightAndMove (int FromRow, int FromCol, int ToRow, int ToCol) {
		if( CanCompMoveRightForward(FromRow,FromCol,FromRow+1,FromCol-1)) //forward digaonal
			MoveTheComputerPins(FromRow,FromCol,FromRow+1,FromCol-1);
		if( CanCompMoveRightForward(FromRow,FromCol,FromRow,FromCol-1)) //<-
			MoveTheComputerPins(FromRow,FromCol,FromRow,FromCol-1);
		if( CanCompMoveRightBack(FromRow,FromCol,FromRow-1,FromCol-1)) // back right
			MoveTheComputerPins(FromRow,FromCol,FromRow-1,FromCol-1);
		if( CanCompMoveRightForward(FromRow,FromCol,FromRow+1,FromCol)) //forward 
			MoveTheComputerPins(FromRow,FromCol,FromRow+1,FromCol);
	}

	//check if computer can move left and do move  
	public  void CheckLeftAndMove (int FromRow, int FromCol, int ToRow, int ToCol) {
		if(CanCompMoveLeftForward(FromRow,FromCol,FromRow+1,FromCol+1)) //forward digaonal
			MoveTheComputerPins(FromRow,FromCol,FromRow+1,FromCol+1);
		if(CanCompMoveLeftForward(FromRow,FromCol,FromRow,FromCol+1)) //->
			MoveTheComputerPins(FromRow,FromCol,FromRow,FromCol+1);
		if(CanCompMoveLeftBack(FromRow,FromCol,FromRow-1,FromCol+1)) // back left
			MoveTheComputerPins(FromRow,FromCol,FromRow-1,FromCol+1);
		if(CanCompMoveLeftBack(FromRow,FromCol,FromRow-1,FromCol)) //back
			MoveTheComputerPins(FromRow,FromCol,FromRow-1,FromCol);
	}

	//Check if the computer pin have direction to move
	public  boolean CanCompMoveOneWay(int FromRow, int FromCol, int ToRow, int ToCol) { 

		if( CanCompMoveRightForward(FromRow,FromCol,FromRow+1,FromCol-1)) {//forward digaonal
			MoveTheComputerPins(FromRow,FromCol,FromRow+1,FromCol-1);
			return true;
		}
		if( CanCompMoveRightForward(FromRow,FromCol,FromRow,FromCol-1)) {//<-
			MoveTheComputerPins(FromRow,FromCol,FromRow,FromCol-1);
			return true;
		}
		if( CanCompMoveRightBack(FromRow,FromCol,FromRow-1,FromCol-1)) {// back right
			MoveTheComputerPins(FromRow,FromCol,FromRow-1,FromCol-1);
			return true;
		}
		if( CanCompMoveRightForward(FromRow,FromCol,FromRow+1,FromCol)) { //forward 
			MoveTheComputerPins(FromRow,FromCol,FromRow+1,FromCol);
			return true;
		}

		if(CanCompMoveLeftForward(FromRow,FromCol,FromRow+1,FromCol+1)) { //forward diagonal
			MoveTheComputerPins(FromRow,FromCol,FromRow+1,FromCol+1);
			return true;
		}
		if(CanCompMoveLeftForward(FromRow,FromCol,FromRow,FromCol+1)) {//->
			MoveTheComputerPins(FromRow,FromCol,FromRow,FromCol+1);
			return true;
		}
		if(CanCompMoveLeftBack(FromRow,FromCol,FromRow-1,FromCol+1)) { // back left
			MoveTheComputerPins(FromRow,FromCol,FromRow-1,FromCol+1);
			return true;
		}
		if(CanCompMoveLeftBack(FromRow,FromCol,FromRow-1,FromCol)) { //back
			MoveTheComputerPins(FromRow,FromCol,FromRow-1,FromCol);	
			return true;
		}

		return false;
	}

	
	
} //class
