**Units are pretty self-explanatory, I hope.**

It's a guy/gal/ship/abomination-onto-gods-clean-world that does a Hats dirty work on the frontlines.

Some require specific Tech to build, others can't move through certain Tiles, and others still might fly one day

| field        | type         | description                                                                                                                                                                             |
| ------------ | ------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| name         | string       | yea                                                                                                                                                                                     |
| description  | string       | yea                                                                                                                                                                                     |
| cost         | int          | how much a unit costs                                                                                                                                                                   |
| maxHP        | int          | the maximum health of a unit                                                                                                                                                            |
| currentHP    | float        | to account for healing float variables can be affected by Tile conditions or Techs, but they get rounded to their nearest whole number since I can't be bothered to deal with edgecases |
| dmg          | float        | part of the damage calculations                                                                                                                                                         |
| def          | float        | part of the damage calculations                                                                                                                                                         |
| spd          | float        | how far can a unit move                                                                                                                                                                 |
| range        | float        | how far can it hit                                                                                                                                                                      |
| attributes   | [[UnitTags]] | mostly preset, but with researched Tech they can be added to                                                                                                                            |
| position     | Vector2      | from System.Numericals                                                                                                                                                                  |
| image        | byte[]       | the image in bytes for easy conversions                                                                                                                                                 |
| attack(tile) | void         | it takes a tile since most melee units will move in the attacked tile when their victim dies                                                                                            |
| moveTo(tile) | void         | self explanitory, I hope                                                                                                                                                                |
| heal()       | void         | regenerates a set amount of health based on the maxHP                                                                                                                                   |
| merge(tile)  | void         | 2 hurt units of the same type become one, if their combined HP is lower than their combined maxHP                                                                                       |
| promote()    | void         | after achieving a certain kill/capture streak a promotion fully heals a unit and increases it's stats                                                                                   |
| onDeath(X)   | void         | to account for any effects that might need to be applied after a units death                                                                                                            |

