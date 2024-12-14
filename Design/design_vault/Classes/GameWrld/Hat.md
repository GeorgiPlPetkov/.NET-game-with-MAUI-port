**Hats are the tribe equivelant**

They store already researched Techs and hold some preresearched ones as the destinguishing factor of their Hat in the early game

They play a crucial role in the visual representation of Units and Structures by holding part of the unique pathing for the relevant Sprites for them

| field               | type        | description                                                                                                             |
| ------------------- | ----------- | ----------------------------------------------------------------------------------------------------------------------- |
| name                | string      | yea                                                                                                                     |
| description         | string      | yea                                                                                                                     |
| units               | [[Unit]][]  | reference to all units they hold                                                                                        |
| territory           | [[Tile]][]  | reference to all the tiles they hold                                                                                    |
| attributes          | [[HatTags]] | the tech they start with + any they research during gameplay                                                            |
| resourcePath        | string      | part of the path variable everything that's drawn on the screen holds                                                   |
| controllerReference | ?           | a way to remember who exactly controlled it last time, probably some sort of controllerID that is unique for the player |
