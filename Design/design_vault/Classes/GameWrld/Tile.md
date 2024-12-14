**Represent the world space as specific and equally sized and spaced sections of the map that hold Structures, Units(and maybe aerial Units and Weather in the future)**

Hexagonal because square are stinky and I like how they look more
They also hold information about their current owner(Hat) and all the current conditions of the Tile represented though TileTags

| field        | type          | description                                  |
| ------------ | ------------- | -------------------------------------------- |
| name         | string        | the name of the tile                         |
| description  | string        | description for extra emersion and the ui    |
| occupingUnit | [[Unit]]      | The unit currently on it if it exists        |
| structure    | [[Structure]] | The ruin or building on it                   |
| tags         | [[TileTags]]  | All the tags that are affecting it right now |
| owner        | [[Hat]]       | The Hat that may be holding it               |
| position     | Vector2       | from System.Numericals                       |
| image        | byte[]        | the image in bytes for easy conversions      |
 