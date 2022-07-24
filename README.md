# HolidaySearch

 **Table of contents:**

| Section     | Brief description   | Documentatin |
| ---------- | ---------------------------- | -------------------- |
| **Container**    | Files and folders in the app| [Click Here](#container) |
| **Description**    | Json files properties| [Click Here](#description) |
| **Instructions**    | How the app works (examples)| [Click Here](#instructions)|
| **Features**    | 4| [Click Here](#features)|




# Container

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

1. Client enter the *departure city*, *destination city*, *departure date* and *duration*
2. Client will see the *FlightId*, *HotelId* and *TotalPrice*

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

### A simple console UI :

![](https://github.com/vahidkianfar/HolidaySearch/blob/master/HolidaySearch/Gif/HolidaySearch-VS.gif)

## Features



