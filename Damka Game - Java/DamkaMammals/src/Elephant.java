public class Elephant extends Mammals{

	protected boolean Queen; //The pin is queen or not

	public Elephant(int owner, Mammals[][]Board) {
		super(owner, Board);
		this.Queen=false;
	}
	//get queen value
	public boolean getQueen() {
		return Queen; 
	}
	//change queen value
	public void setQueen(boolean queen) {
		this.Queen=queen; 
	}

	//return the pin on board
	public String toString() {
		if(Queen==false)
			return ("E"+this.owner);
		return ("E"+this.owner+"Q");

	}

	//check if its user one step 
	public  boolean isOneStep(int FromRow, int FromCol, int ToRow, int ToCol) {
		if(isStepForward(FromRow,FromCol,ToRow,ToCol))
			return true;
		if(isQ(FromRow,FromCol)) {
			if(isStepBack(FromRow,FromCol,ToRow,ToCol)) //Queen can move back
				return true;
		}
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
		if(ToRow-FromRow==-1 && ToCol-FromCol==-1)
			return true;

		if(ToRow-FromRow==-2 && ToCol-FromCol==-2) 
			if((Board[(ToRow+FromRow)/2][(ToCol+FromCol)/2]==null) )
				return true;
		return false;
	}

	//check if its user one step right forward
	public  boolean isStepRightForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if(ToRow-FromRow==-1 && ToCol-FromCol==1) 
			return true;

		if (ToRow-FromRow==-2 && ToCol-FromCol==2)
			if((Board[(ToRow+FromRow)/2][(ToCol+FromCol)/2]==null))
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

		if(ToRow-FromRow==1 && ToCol-FromCol==-1)
			return true;

		if(ToRow-FromRow==2 && ToCol-FromCol==-2) 
			if((Board[(ToRow+FromRow)/2][(ToCol+FromCol)/2]==null) )
				return true;
		return false;
	}

	//check if its user one step right back
	public  boolean isStepRightBack(int FromRow, int FromCol, int ToRow, int ToCol) {
		if(ToRow-FromRow==1 && ToCol-FromCol==1) 
			return true;

		if (ToRow-FromRow==2 && ToCol-FromCol==2)
			if((Board[(ToRow+FromRow)/2][(ToCol+FromCol)/2]==null))
				return true;
		return false;
	}

	// checks if the intention of the user is to eat and if it's possible
	public boolean isEat(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (isDiagonalEat(FromRow, FromCol, ToRow, ToCol) && super.isCompInMiddle(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}

	// checks if it's a diagonal that performs eating
	public boolean isDiagonalEat(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (isDiagonalForwardEat(FromRow, FromCol, ToRow, ToCol))
			return true;

		if (isQ(FromRow, FromCol) || isWasQ(ToRow, ToCol)) {
			if(isDiagonalBackEat(FromRow, FromCol, ToRow, ToCol))
				return true;
		}
		return false;
	}

	// Check if its user forward eat
	public boolean isDiagonalForwardEat(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (isDiagonalForwardLeftEat(FromRow, FromCol, ToRow, ToCol)
				|| isDiagonalForwardRightEat(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}

	// Check if its user left forward
	public boolean isDiagonalForwardLeftEat(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (ToRow - FromRow == -2 && ToCol - FromCol == -2)
			return true;
		return false;
	}

	// Check if its user Right forward
	public boolean isDiagonalForwardRightEat(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (ToRow - FromRow == -2 && ToCol - FromCol == 2)
			return true;
		return false;
	}

	// Move the user pins
	public void MoveUserPins(int FromRow, int FromCol, int ToRow, int ToCol) {
		UpdateUserPlaces(FromRow, FromCol, ToRow, ToCol);
		if (isEat(FromRow, FromCol, ToRow, ToCol))
			removeEatenEnemy(FromRow, FromCol, ToRow, ToCol);
	}

	// Change the user places when he move
	public void UpdateUserPlaces(int FromRow, int FromCol, int ToRow, int ToCol) {
		Board[ToRow][ToCol] = Board[FromRow][FromCol];
		Board[FromRow][FromCol] = null;
	}

	//remove the enemy from the board
	public void removeEatenEnemy(int FromRow, int FromCol, int ToRow, int ToCol) {
		Board[(ToRow + FromRow) / 2][(ToCol + FromCol) / 2] = null;
	}

	//Check if the pin suppose switch to queen of the user
	public  boolean isSupposeSwitchToQ_User(int ToRow, int ToCol) {
		if(ToRow==0) {
			if(ToCol==1 || ToCol==3 || ToCol==5 || ToCol==7)
				return true;
		}
		return false;
	}

	//Check if the pin suppose switch to queen of the computer
	public  boolean isSupposeSwitchToQ_Comp(int ToRow, int ToCol) {
		if(ToRow==7) {
			if(ToCol==0 || ToCol==2 || ToCol==4 || ToCol==6)
				return true;
		}
		return false;
	}

	//Change the pin from regular to Queen 
	public  void switchToQ(int ToRow, int ToCol) {
		if(Board[ToRow][ToCol]!=null) 
			((Elephant)Board[ToRow][ToCol]).Queen=true;  
	}

	//check if the pin is queen
	public  boolean isQ (int FromRow, int FromCol) {
		if(Board[FromRow][FromCol]!=null) {
			if(((Elephant)Board[FromRow][FromCol]).Queen==true) 
				return true;
		}
		return false;
	}

	//check if the pin was queen before the move 
	public  boolean isWasQ (int ToRow, int ToCol) {
		if(Board[ToRow][ToCol]!=null) {
			if(((Elephant)Board[ToRow][ToCol]).Queen==true) 
				return true;
		}
		return false;
	}

	//check if user can move 
	public boolean CanUserMove(int FromRow, int FromCol) {

		if (CanUserMoveForward(FromRow, FromCol, FromRow - 1, FromCol - 1))  //left forward
			return true;

		if (CanUserMoveForward(FromRow, FromCol, FromRow - 1, FromCol + 1))  //right forward
			return true;


		if(((Elephant)Board[FromRow][FromCol]).Queen==true) {

			if (CanUserMoveBack(FromRow, FromCol, FromRow + 1, FromCol + 1))  //right back
				return true;

			if (CanUserMoveBack(FromRow, FromCol, FromRow + 1, FromCol - 1))  //right left
				return true;

		}
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

	//Check if the user can eat with this pin 
	public  boolean CanUserEatNow(int FromRow, int FromCol, int [][] eatenPins) {

		if (canUserEat(FromRow, FromCol, FromRow-2, FromCol+2, eatenPins))          //right forward
			return true;

		if (canUserEat(FromRow, FromCol, FromRow-2, FromCol-2, eatenPins))       //left forward
			return true;


		if(isQ(FromRow,  FromCol)) {
			if (canUserEat(FromRow, FromCol, FromRow+2, FromCol+2, eatenPins))      //right back
				return true;

			if (canUserEat(FromRow, FromCol, FromRow+2, FromCol-2, eatenPins))      //left back
				return true;
		}
		return false;
	}
	//////////computer


	//Check if the computer pin can move right forward 
	public  boolean CanCompMoveRightForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (!super.ToOutOfBoundries(FromRow,FromCol,ToRow,ToCol)&& PlaceIsFree(FromRow,FromCol,ToRow,ToCol)) {
			if(ToCol - FromCol == -2) {
				if(Board[(ToRow+FromRow)/2][(ToCol+FromCol)/2]==null) 
					return true;
				return false;
			}
			return true;
		}
		return false;
	}


	//Check if the computer pin can move left forward 
	public  boolean CanCompMoveLeftForward(int FromRow, int FromCol, int ToRow, int ToCol) { 
		if (!super.ToOutOfBoundries(FromRow,FromCol,ToRow,ToCol)&& PlaceIsFree(FromRow,FromCol,ToRow,ToCol)) {
			if(ToCol - FromCol == 2) {
				if(Board[(ToRow+FromRow)/2][(ToCol+FromCol)/2]==null) 
					return true;
				return false;
			}
			return true;
		}
		return false;
	}


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
		if( CanCompMoveRightForward(FromRow,FromCol,FromRow+1,FromCol-1))
			Rightoptions++;
		if( CanCompMoveRightForward(FromRow,FromCol,FromRow+2,FromCol-2))
			Rightoptions++;
		return Rightoptions;
	}

	//Check if the computer pin can move left forward 
	public int CanCompMoveLeft(int FromRow, int FromCol, int ToRow, int ToCol, int Leftoptions){
		if(CanCompMoveLeftForward(FromRow,FromCol,FromRow+1,FromCol+1))
			Leftoptions++;
		if(CanCompMoveLeftForward(FromRow,FromCol,FromRow+2,FromCol+2))
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
		if( CanCompMoveRightForward(FromRow,FromCol,FromRow+1,FromCol-1)) {
			MoveTheComputerPins(FromRow,FromCol,FromRow+1,FromCol-1);
			if(((Elephant)Board[FromRow+1][FromCol-1]).isSupposeSwitchToQ_Comp(FromRow+1,FromCol-1))
				((Elephant)Board[FromRow+1][FromCol-1]).switchToQ(FromRow+1,FromCol-1);
		}
		if( CanCompMoveRightForward(FromRow,FromCol,FromRow+2,FromCol-2)) {
			MoveTheComputerPins(FromRow,FromCol,FromRow+2,FromCol-2);	//right
			if(((Elephant)Board[FromRow+2][FromCol-2]).isSupposeSwitchToQ_Comp(FromRow+2,FromCol-2))
				((Elephant)Board[FromRow+2][FromCol-2]).switchToQ(FromRow+2,FromCol-2);
		}
	}

	//check if computer can move left and do move  
	public  void CheckLeftAndMove (int FromRow, int FromCol, int ToRow, int ToCol) {
		if( CanCompMoveLeftForward(FromRow,FromCol,FromRow+1,FromCol+1)) {
			MoveTheComputerPins(FromRow,FromCol,FromRow+1,FromCol+1);
			if(((Elephant)Board[FromRow+1][FromCol+1]).isSupposeSwitchToQ_Comp(FromRow+1,FromCol+1))
				((Elephant)Board[FromRow+1][FromCol+1]).switchToQ(FromRow+1,FromCol+1);
		}
		if( CanCompMoveLeftForward(FromRow,FromCol,FromRow+2,FromCol+2)) {
			MoveTheComputerPins(FromRow,FromCol,FromRow+2,FromCol+2);	//right	
			if(((Elephant)Board[FromRow+2][FromCol+2]).isSupposeSwitchToQ_Comp(FromRow+2,FromCol+2))
				((Elephant)Board[FromRow+2][FromCol+2]).switchToQ(FromRow+2,FromCol+2);
		}

	}

	//Check if the computer pin have one direction to move
	public  boolean CanCompMoveOneWay(int FromRow, int FromCol, int ToRow, int ToCol) { 

		if( CanCompMoveRightForward(FromRow,FromCol,FromRow+1,FromCol-1) ) {
			MoveTheComputerPins(FromRow,FromCol,FromRow+1,FromCol-1);
			if(((Elephant)Board[FromRow+1][FromCol-1]).isSupposeSwitchToQ_Comp(FromRow+1,FromCol-1))
				((Elephant)Board[FromRow+1][FromCol-1]).switchToQ(FromRow+1,FromCol-1);
			return true;
		}
		if( CanCompMoveRightForward(FromRow,FromCol,FromRow+2,FromCol-2) ) {
			MoveTheComputerPins(FromRow,FromCol,FromRow+2,FromCol-2);
			if(((Elephant)Board[FromRow+2][FromCol-2]).isSupposeSwitchToQ_Comp(FromRow+2,FromCol-2))
				((Elephant)Board[FromRow+2][FromCol-2]).switchToQ(FromRow+2,FromCol-2);
			return true;
		}
		if(CanCompMoveLeftForward(FromRow,FromCol,FromRow+1,FromCol+1)) {
			MoveTheComputerPins(FromRow,FromCol,FromRow+1,FromCol+1);
			if(((Elephant)Board[FromRow+1][FromCol+1]).isSupposeSwitchToQ_Comp(FromRow+1,FromCol+1))
				((Elephant)Board[FromRow+1][FromCol+1]).switchToQ(FromRow+1,FromCol+1);
			return true;
		}
		if(CanCompMoveLeftForward(FromRow,FromCol,FromRow+2,FromCol+2)) {
			MoveTheComputerPins(FromRow,FromCol,FromRow+2,FromCol+2);
			if(((Elephant)Board[FromRow+2][FromCol+2]).isSupposeSwitchToQ_Comp(FromRow+2,FromCol+2))
				((Elephant)Board[FromRow+2][FromCol+2]).switchToQ(FromRow+2,FromCol+2);
			return true;
		}

		if(isQ (FromRow, FromCol)) {//queen can move back 
			if( CanCompMoveRightBack(FromRow,FromCol,FromRow-1,FromCol-1) ) {
				MoveTheComputerPins(FromRow,FromCol,FromRow-1,FromCol-1);
				return true;
			}
			if( CanCompMoveRightBack(FromRow,FromCol,FromRow-2,FromCol-2) ) {
				MoveTheComputerPins(FromRow,FromCol,FromRow-2,FromCol-2);
				return true;
			}
			if(CanCompMoveLeftBack(FromRow,FromCol,FromRow-1,FromCol+1)) {
				MoveTheComputerPins(FromRow,FromCol,FromRow-1,FromCol+1);
				return true;
			}
			if(CanCompMoveLeftBack(FromRow,FromCol,FromRow-2,FromCol+2)) {
				MoveTheComputerPins(FromRow,FromCol,FromRow-2,FromCol+2);
				return true;
			}
		} //Q

		return false;
	}

} //class
