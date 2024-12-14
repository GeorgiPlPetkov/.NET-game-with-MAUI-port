**Ruins or Buildings on tile**
Buildings apply additional tags to the tile they are on
Ruins come prebuild during generation and usually don't apply tags, but give a some sort of advantage for their removal/exploration

| field       | type         | description                                                                               |
| ----------- | ------------ | ----------------------------------------------------------------------------------------- |
| name        | string       | ye                                                                                        |
| description | string       | ye                                                                                        |
| position    | Vector2      | from System.Numericals                                                                    |
| image       | byte[]       | the image in bytes for easy conversions                                                   |
| tags        | [[TileTags]] | the tags it applies to the tiles when it's built on it, it takes them away when destroyed |
| OnBuild     | void         | applies the tags                                                                          |
| OnDestroy   | void         | removes the tags                                                                          |
