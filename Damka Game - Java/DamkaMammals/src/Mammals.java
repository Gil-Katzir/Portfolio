public class Mammals {

	protected int owner; // 1 user, 2 computer 
	protected Mammals[][] Board; //Game board

	public Mammals(int owner, Mammals[][] Board) {
		this.owner = owner;
		this.Board = Board;
	}

	//return the if its computer pin or user pin 
	public int getowner() {
		return owner;
	}

	//check if there is computer pin in the middle
	public boolean isCompInMiddle(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (Board[(ToRow + FromRow) / 2][(ToCol + FromCol) / 2] != null) {
			if (Board[(ToRow + FromRow) / 2][(ToCol + FromCol) / 2].getowner() == 2)
				return true;
		}
		return false;
	}

	// check if the numbers is between 1-8
	public boolean ToOutOfBoundries(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (ToRow < Board.length && ToRow >= 0 && ToCol < Board.length && ToCol >= 0)
			return false;
		return true;
	}

	//The eating move
	public void EatAndRemoveEnemy(int FromRow, int FromCol, int ToRow, int ToCol) {
		MoveTheComputerPins(FromRow, FromCol, ToRow, ToCol);
		removeEatenEnemy(FromRow, FromCol, ToRow, ToCol);
	}

	//Change the places on board
	public void MoveTheComputerPins(int FromRow, int FromCol, int ToRow, int ToCol) {
		Board[ToRow][ToCol] = Board[FromRow][FromCol];
		Board[FromRow][FromCol] = null;
	}

	//change the place of user pins
	public void MoveUserPins(int FromRow, int FromCol, int ToRow, int ToCol) {
		UpdateUserPlaces(FromRow, FromCol, ToRow, ToCol);
		if (isEat(FromRow, FromCol, ToRow, ToCol))
			removeEatenEnemy(FromRow, FromCol, ToRow, ToCol);
	}

	//change the place of user pins
	public void MoveUserPinsAgain(int FromRow, int FromCol, int ToRow, int ToCol) {
		UpdateUserPlaces(FromRow, FromCol, ToRow, ToCol);
		if (isEatAgain(FromRow, FromCol, ToRow, ToCol))
			removeEatenEnemy(FromRow, FromCol, ToRow, ToCol);
	}
	//Change the user places when he move
	public void UpdateUserPlaces(int FromRow, int FromCol, int ToRow, int ToCol) {
		Board[ToRow][ToCol] = Board[FromRow][FromCol];
		Board[FromRow][FromCol] = null;
	}

	//remove the enemy from the board
	public void removeEatenEnemy(int FromRow, int FromCol, int ToRow, int ToCol) {
		Board[(ToRow + FromRow) / 2][(ToCol + FromCol) / 2] = null;
	}

	//check if place on board is null 
	public boolean PlaceIsFree(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (Board[ToRow][ToCol] == null) {
			if ((ToRow + ToCol) % 2 != 0)
				return true;
		}
		return false;
	}

	//check if its user one step 
	public boolean isOneStep(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (isStepForward(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}

	//check if its user one step forward
	public boolean isStepForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (isStepLeftForward(FromRow, FromCol, ToRow, ToCol) || isStepRightForward(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;

	}

	// Check if the user can move one step left forward
	public boolean isStepLeftForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (ToRow - FromRow == -1 && ToCol - FromCol == -1)
			return true;
		return false;
	}

	// Check if the user can move one step right forward
	public boolean isStepRightForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (ToRow - FromRow == -1 && ToCol - FromCol == 1)
			return true;
		return false;
	}

	// checks if the user of can eat again
	public boolean isEatAgain(int FromRow, int FromCol, int ToRow, int ToCol) {
		if ((isDiagonalForwardEat(FromRow, FromCol, ToRow, ToCol) || isDiagonalBackEat(FromRow, FromCol, ToRow, ToCol)) && isCompInMiddle(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}



	//checks if the intention of the user is to eat and if it's possible
	public boolean isEat(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (isDiagonalEat(FromRow, FromCol, ToRow, ToCol) && isCompInMiddle(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}

	//checks if it's a diagonal that performs eating
	public boolean isDiagonalEat(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (isDiagonalForwardEat(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}

	//Check if its forward eat
	public boolean isDiagonalForwardEat(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (isDiagonalForwardLeftEat(FromRow, FromCol, ToRow, ToCol)
				|| isDiagonalForwardRightEat(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}

	//Check if its left forward eat 
	public boolean isDiagonalForwardLeftEat(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (ToRow - FromRow == -2 && ToCol - FromCol == -2)
			return true;
		return false;
	}

	//Check if its Right forward eat
	public boolean isDiagonalForwardRightEat(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (ToRow - FromRow == -2 && ToCol - FromCol == 2)
			return true;
		return false;
	}



	// Check if its back eat
	public boolean isDiagonalBackEat(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (isDiagonalBackLeftEat(FromRow, FromCol, ToRow, ToCol)
				|| isDiagonalBackRightEat(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}

	// Check if its left back
	public boolean isDiagonalBackLeftEat(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (ToRow - FromRow == 2 && ToCol - FromCol == -2)
			return true;
		return false;
	}

	// Check if its Right back
	public boolean isDiagonalBackRightEat(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (ToRow - FromRow == 2 && ToCol - FromCol == 2)
			return true;
		return false;
	}


	//Check if the user can eat with this pin 
	public  boolean CanUserEatAgain(int FromRow, int FromCol, int [][] eatenPins) {

		if (canUserEat(FromRow, FromCol, FromRow-2, FromCol+2, eatenPins)) {           //right forward
			return true;
		}
		else if (canUserEat(FromRow, FromCol, FromRow-2, FromCol-2, eatenPins)) {      //left forward
			return true;
		}
		else if (canUserEat(FromRow, FromCol, FromRow+2, FromCol+2, eatenPins)) {      //right back
			return true;
		}
		else if (canUserEat(FromRow, FromCol, FromRow+2, FromCol-2, eatenPins)) {      //left back
			return true;
		}
		else {
			return false;
		}
	}
	
	//Check if the user can eat with this pin 
	public  boolean CanUserEatNow(int FromRow, int FromCol, int [][] eatenPins) {
		if (canUserEat(FromRow, FromCol, FromRow-2, FromCol+2, eatenPins) || canUserEat(FromRow, FromCol, FromRow-2, FromCol-2, eatenPins) )           //right forward
			return true;
		return false;
	}

	//check if the is eaten in the last multi-eat
	public  boolean PinAlreadyEaten(int FromRow, int FromCol, int ToRow, int ToCol, int [][]eatenPins) {
		for(int j=0; j<=11; j++) {
			if( ((FromRow+ToRow)/2)==eatenPins[0][j] && ((FromCol+ToCol)/2)==eatenPins[1][j])
				return true;
		}
		return false;
	}

	//Check if the user can eat with this pin 
	public  boolean canUserEat(int FromRow, int FromCol, int ToRow, int ToCol, int [][] eatenPins) {
		if (!ToOutOfBoundries(FromRow, FromCol, ToRow, ToCol)&&PlaceIsFree(FromRow, FromCol, ToRow, ToCol) && isCompInMiddle(FromRow, FromCol, ToRow, ToCol) && !PinAlreadyEaten(FromRow, FromCol, ToRow, ToCol, eatenPins)) 
			return true;
		return false; 

	}

	//check if there are options to move the user pins
	public boolean CanUserMove(int FromRow, int FromCol) {

		if (CanUserMoveForward(FromRow, FromCol, FromRow - 1, FromCol - 1)) { //left forward
			return true;
		}
		else if (CanUserMoveForward(FromRow, FromCol, FromRow - 1, FromCol + 1)) { //right forward
			return true;
		}
		else
			return false;
	}

	//check if there are options to move forward the user pins
	public boolean CanUserMoveForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (!ToOutOfBoundries(FromRow, FromCol, ToRow, ToCol) && PlaceIsFree(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}


	//////computer

	// Check if there is possible eating move to the computer
	public boolean canCompEat(int FromRow, int FromCol, int ToRow, int ToCol, int [][] eatenUserPins) {
		if (!ToOutOfBoundries(FromRow, FromCol, ToRow, ToCol) && PlaceIsFree(FromRow, FromCol, ToRow, ToCol)
				&& isUserInTheMiddle(FromRow, FromCol, ToRow, ToCol) )
			return true;
		return false;
	}

	// Check if there is possible multi-eating to the computer
	public boolean canCompEatAgain(int FromRow, int FromCol, int ToRow, int ToCol, int [][] eatenUserPins) {
		if (!ToOutOfBoundries(FromRow, FromCol, ToRow, ToCol) && PlaceIsFree(FromRow, FromCol, ToRow, ToCol)
				&& isUserInTheMiddle(FromRow, FromCol, ToRow, ToCol) && !PinAlreadyEaten(FromRow, FromCol, ToRow, ToCol, eatenUserPins))
			return true;
		return false;
	}

	// Check if there is user pin that computer can eat
	public boolean isUserInTheMiddle(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (Board[(ToRow + FromRow) / 2][(ToCol + FromCol) / 2] != null
				&& Board[(ToRow + FromRow) / 2][(ToCol + FromCol) / 2].getowner() == 1)
			return true;
		return false;
	}

	// Check if the computer pin has two direction to move
	public boolean MoreThanOneWay(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (CanCompMoveRightForward(FromRow, FromCol, FromRow + 1, FromCol - 1)
				&& CanCompMoveLeftForward(FromRow, FromCol, FromRow + 1, FromCol + 1))
			return true;
		return false;
	}

	// Check if the computer pin can move right forward
	public boolean CanCompMoveRightForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (!ToOutOfBoundries(FromRow, FromCol, ToRow, ToCol) && PlaceIsFree(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}

	// Check if the computer pin can move left forward
	public boolean CanCompMoveLeftForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (!ToOutOfBoundries(FromRow, FromCol, ToRow, ToCol) && PlaceIsFree(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}

	// Check if the computer pin can move right back
	public boolean CanCompMoveRightBack(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (!ToOutOfBoundries(FromRow, FromCol, ToRow, ToCol) && PlaceIsFree(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}

	// Check if the computer pin can move left back
	public boolean CanCompMoveLeftBack(int FromRow, int FromCol, int ToRow, int ToCol) {
		if (!ToOutOfBoundries(FromRow, FromCol, ToRow, ToCol) && PlaceIsFree(FromRow, FromCol, ToRow, ToCol))
			return true;
		return false;
	}

	//choose side for the computer move 
	public void ChooseRandomSideAndMove(int FromRow, int FromCol, int ToRow, int ToCol) {

		if (Math.random() <= 0.3)
			MoveTheComputerPins(FromRow, FromCol, FromRow + 1, FromCol - 1); // right
		else
			MoveTheComputerPins(FromRow, FromCol, FromRow + 1, FromCol + 1); // right
	}

	//Check if the computer pin have one direction to move
	public boolean CanCompMoveOneWay(int FromRow, int FromCol, int ToRow, int ToCol) {

		if (CanCompMoveRightForward(FromRow, FromCol, FromRow + 1, FromCol - 1)) {
			MoveTheComputerPins(FromRow, FromCol, FromRow + 1, FromCol - 1);
			return true;
		}
		if (CanCompMoveLeftForward(FromRow, FromCol, FromRow + 1, FromCol + 1)) {
			MoveTheComputerPins(FromRow, FromCol, FromRow + 1, FromCol + 1);
			return true;
		}
		return false;
	}

	//return the pin on board
	public String toString() {
		return ("");
	}

}