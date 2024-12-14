The API for interacting with the world through the BattleResolver
For sweet sweet nested dependency injections.

| field                   | type            | description                                                                                                                                                                                                                                                       |
| ----------------------- | --------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| hat                     | Hat             | the hat the controller is using (gotten from the world)                                                                                                                                                                                                           |
| selectedTile            | Tile            |                                                                                                                                                                                                                                                                   |
| selectedUnit            | Unit            |                                                                                                                                                                                                                                                                   |
| selectedStructure       | Structure       |                                                                                                                                                                                                                                                                   |
| currentMode             | enum probably   | pawn control, building, destroying and general looking around                                                                                                                                                                                                     |
| sitchMode               | void            | switches between modes(for buttons and whatnots)                                                                                                                                                                                                                  |
| select(v2d(x,y))        | void            | display information about the clicked Unit Structure or Tile in said order. If a pawn is selected switches the controller to pawncontrol                                                                                                                          |
| listActions             | List of vector2 | returns all tile on which an action can be executed                                                                                                                                                                                                               |
| executeAction(v2d(x,y)) | bool            | attempts an action on the given position, construction and destruction are pretty self explanatory, in pawncontrol attempts to have the pawn interact with the given position, when looking around it just show the description of the tiles with *extra* detail) |
|                         |                 |                                                                                                                                                                                                                                                                   |



All actions on the Controls technically take v2d
actions with -self take the current position of the unit 
PawnControl

| field          | type | description                                                         |
| -------------- | ---- | ------------------------------------------------------------------- |
| Attack         | void | do damage to the unit on the given positon (for non melee units)    |
| Ivade          | void | attack and then move onto the given position                        |
| Capture        | void | take a city tile                                                    |
| Merge          | void | merges with the unit on the given tile                              |
| Promote - self | void | promotes the unit                                                   |
| Heal - self    | void | heals the unit                                                      |
| Special - self | void | does a thing if applicable (it wont be until I start experimenting) |

Building

| field             | type      | description                                  |
| ----------------- | --------- | -------------------------------------------- |
| structureOptions  | List      | all possible structures for the selected hat |
| selectedStructure | Structure | what is built when a tile is selected        |
| Build             |           |                                              |
Destroying

| field   | type | description                                                  |
| ------- | ---- | ------------------------------------------------------------ |
| Destroy | bool | destroys the given structure and modifies tiles like forests |
