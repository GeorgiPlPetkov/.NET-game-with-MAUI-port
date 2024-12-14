**A world is mainly just a bag of Tiles that hopefully would provide easy access to the Tiles for the BattleResolver**

It handles generation and loading from files of said worlds
Holds all tiles, the current turn, all Hats that were ever played on it

| field           | type                                               | description                                                                                                                                                     |
| --------------- | -------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| world_id(seed?) | integer(long?)                                     | depending on whether I go for seed based or completely random generation I might just use the seed as the identifier of the world or it might be it's own field |
| tiles           | hastable of [[Tile]] with it's position as the key | all the tiles and their relevant data of the world, set during generation                                                                                       |
| hats            | [[Hat]][]                                          | all the hats participating in the world, set during generation, the position of each [[Hat]] in the array decides when their turn is                            |
| name            | string                                             | given by the Player when creating it                                                                                                                            |
| description     | string                                             | given by the Player or set by the generator                                                                                                                     |
| current turn    | integer                                            | will probably have an unreasonably long cap                                                                                                                     |
