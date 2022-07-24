# HolidaySearch 🐾✈️🧳

 **Table of contents:**

| Section     | Brief description   | Documentatin |
| ---------- | ---------------------------- | -------------------- |
| **Container**    | Files and folders in the app| [Click Here](#container) |
| **Description**    | Json files properties| [Click Here](#description) |
| **Instructions**    | How the app works (examples)| [Click Here](#instructions)|
| **Features**    | Features and future thoughts| [Click Here](#features-and-future-thoughts)|
| **UI**| A simple UI| [Click Here](#simple-console-ui)|
| **UML Diagram**| UML-Diagram|[Click Here](#uml-diagram)|

# Container
[Back to top](#holidaysearch)

1.This App contains five main folders:

- Datasets (Flights.json and Hotels.json)
- LoadDataModels (LoadDataFromJson)
- Models (Flights and Hotels)
- SearchModels (HolidaySearch and MatchedFlightsAndHotels)
- UI (MainMenu, SearchMenu and ConsoleHelper)

2.**Unit Tests** contains three main folders:

- HolidaySearchTests:
    1. HolidaySearchTests (Result Method)
    2. FindMatchFlights Tests
    3. FindMatchHotels Tests
    4. TotalPrices Tests
    5. SortingMethods Tests
- FlightsTests
- HotelsTests


In this project I created a searching method to find the cheapest available flight and hotel.


## Description

[Back to top](#holidaysearch)

I have two different Json files which stored the details about flights and hotels:

1- A record of **Flights.json** [*"id", "airline", "from", "to", "price", "departure_date"*]

    "id": 1,
    "airline": "First Class Air",
    "from": "MAN",
    "to": "TFS",
    "price": 470,
    "departure_date": "2023-07-01"


2- A record of **Hotels.json** [*"id", "name", "arrival_date", "price_per_night", "local_airports", "nights"*]

    "id": 2,
    "name": "Laguna Park 2",
    "arrival_date": "2022-11-05",
    "price_per_night": 50,
    "local_airports": ["TFS"],
    "nights": 7


## Instructions
[Back to top](#holidaysearch)

1. Customer can enter the *departure city*, *destination city*, *departure date* and *duration*
2. Customer will see the *FlightId*, *HotelId* and *TotalPrice*

### Example 1:
##### Input

 * Departing from: Manchester Airport (MAN)
 * Traveling to: Malaga Airport (AGP)
 * Departure Date: 2023/07/01
 * Duration: 7 nights

##### Expected result  
 * Flight 2 and Hotel 9
 
 
### Example 2:
##### Input

 * Departing from: Any London Airport
 * Traveling to: Mallorca Airport (PMI)
 * Departure Date: 2023/06/15
 * Duration: 10 nights

##### Expected result  
 * Flight 6 and Hotel 5

### Simple console UI:
[Back to top](#holidaysearch)

![](https://github.com/vahidkianfar/HolidaySearch/blob/master/HolidaySearch/Gif/HolidaySearch-VS.gif)

## Features and Future Thoughts
[Back to top](#holidaysearch)

1. I wrote seperate methods for finding list of matched flights and list of matched hotels.
2. I use List<Flights> and List<Hotels> so I can easily retrieve data by query (LINQ method).
3. The client would be able to find only flights or hotels.
4. The **Result** method on **HolidaySearch** class will create a new object of *MatchedFlightsAndHotels* which stores a list of available flights and hotels.
5. The **Result** method on **HolidaySearch** class will return a list of matched flight and hotel together and a list of total prices.
6. User can select "Any Airport" and "Any London Airport"


## UML Diagram
[Back to top](#holidaysearch)


![](https://github.com/vahidkianfar/HolidaySearch/blob/master/HolidaySearch/UML%20Diagram/HolidaySearch.png)
