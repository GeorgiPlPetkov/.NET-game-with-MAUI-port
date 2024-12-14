**The GAMEPLAY-LOOP:tm:**  

Conencts the World, the Tech tree and all relevant controllers

| field           | type           | description                         |
| --------------- | -------------- | ----------------------------------- |
| currentTurn     | integer        |                                     |
| turnLimit       | integer        |                                     |
| advanceTurn()   | void           | logic for switching between turns   |
| pawnController  | [[Controller]] | handles the manipulation of units   |
| buildController | [[Controller]] | handles interaction with structures |
| techTree        | [[Tech tree]]  | referebce to the tech tree api      |
| world           | [[World]]      | samesies but for the world          |
	q1`