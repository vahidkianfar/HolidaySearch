# HolidaySearch

This App contains five main folders:

- Datasets (Flights.json and Hotels.json)
- LoadDataModels (LoadDataFromJson)
- Models (Flights and Hotels)
- SearchModels (HolidaySearch and MatchedFlightsAndHotels)
- UI (MainMenu, SearchMenu and ConsoleHelper)

Unit Tests contains four main folders:

- HolidaySearchTests (HolidaySearchTests and MatchedFlightsAndHotelsTests)
- FlightsTests (FlightsTests)
- HotelsTests
- ParsingToObject (JsonToObjectTests)


In this project I created a searching method to find the cheapest available flight and hotel.


## Description

I have two different Json files which stored the details about flights and hotels:

- 1 record of Flights.json ["id", "airline", "from", "to", "price", "departure_date"]

'''
{

    "id": 1,

    "airline": "First Class Air",

    "from": "MAN",

    "to": "TFS",

    "price": 470,

    "departure_date": "2023-07-01"

  },
'''

- 1 record of Hotels.json ["id", "name", "arrival_date", "price_per_night", "local_airports", "nights"]


'''
{

    "id": 2,

    "name": "Laguna Park 2",

    "arrival_date": "2022-11-05",

    "price_per_night": 50,

    "local_airports": ["TFS"],

    "nights": 7

  },

 '''

