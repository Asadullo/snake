# snake
snake game validator

Sample request data for /validate 

{
  "state": {
    "GameID": "dsdasdasdasdas",
    "Width": 12,
    "Height": 12,
    "Score": 1,
    "Fruit": {
      "X": 11,
      "Y": 10
    },
    "Snake": {
      "X": 0,
      "Y": 0,
      "VelX": 1,
      "VelY": 0
    }
  },
  "Ticks": [
    {
      "VelX": 1,
      "VelY": 0
    },
    {
      "VelX": 1,
      "VelY": 0
    },
    {
      "VelX": 0,
      "VelY": 1
    }
  ]
}
