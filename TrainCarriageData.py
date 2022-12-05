import DatabaseConn

connString = DatabaseConn.mydb
getData = connString.cursor(buffered=True)


def has_value(cursor, table, column, value):
    query = ('Select * From {} Where {} = {}'.format(table, column, value))
    cursor.execute(query)
    return cursor

def has_string(cursor, table, column, value):
    query = ('Select * From {} Where {} = "{}"'.format(table, column, value))
    cursor.execute(query)
    return cursor


def cell_value(cursor, column, table, specificColumn, value):
    query = 'Select {} From {} Where {} = {}'.format(column, table, specificColumn, value)
    cursor.execute(query)
    return cursor


def getDescID(numOfInterStations):
    for i in cell_value(getData, "DescriptionID", "routes", "NumOfInterStations", numOfInterStations):
        descriptionId = [*i]
        for j in descriptionId:
            descId = j
        return descId


def getRouteID(RouteID):
    for i in cell_value(getData, "DescriptionID", "routes","RouteID", RouteID):
        descriptionId = [*i]
        for j in descriptionId:
            descId = j
    return RouteID


def routeInfoFiveStations():
    valueOfCell = cell_value(getData, "route_description_5_stations", "DescriptionID", getDescID(5))
    dataOfCell = [*valueOfCell]
    routeData = []
    for x in dataOfCell:
        routeData.append(x)
        # desID, depStatID, first, sec, third, four, five, destin = routeData
    return routeData


def routeInfoEightStations():
    valueOfCell = has_value(getData, "route_description_9_stations", "DescriptionID", getDescID(8))
    dataOfCell = [*valueOfCell]
    routeData = []
    for x in dataOfCell:
        routeData.append(x)
        # desID, depStatID, first, sec, third, four, five, six, seven, eight, destin = routeData
    return routeData


def fiveStationInfo():  # if the route has 5 intermediate stations between the departure station and the destination
    t = 0
    carriages = []

    station_data = []
    for val in routeInfoFiveStations():
        if has_value(getData, "train_stations", "StationId", val[1]):
            x = [*val]
            x.pop(0)
            station_data.append(x)
    for val in station_data:
        for val_two in val:
            for i in has_value(getData, "train_stations", "StationId", val_two):
                stations = [*i]
                stationID, stationName, maxCarriages = stations
                carriages.append(maxCarriages)
    return carriages


def eightStationInfo():  # if the route has 8 intermediate stations between departure station and destination station
    t = 0
    carriages = []

    station_data = []
    for val in routeInfoEightStations():
        if has_value(getData, "train_stations", "StationId", val[1]):
            x = [*val]
            x.pop(0)
            station_data.append(x)
    for val in station_data:
        for val_two in val:
            for i in has_value(getData, "train_stations", "StationId", val_two):
                stations = [*i]
                stationID, stationName, maxCarriages = stations
                carriages.append(maxCarriages)
    return carriages


def getTrainModel8Stations():
    carriageData = []
    if getDescID(8):
        carriages = eightStationInfo()
        for j in carriages:
            carriagesTrain = j
            trainModel = has_value(getData, "train_models", "MaximumCarriages", carriagesTrain)
            carriageInfo = tuple([*trainModel])
            carriageData.append(carriageInfo)
            unq = set(carriageData)
    print(unq)


def getTrainModel5Stations():
    carriageData = []
    if getDescID(5):
        carriages = fiveStationInfo()
        for j in carriages:
            carriagesTrain = j
            trainModel = has_value(getData, "train_models", "MaximumCarriages", carriagesTrain)
            carriageInfo = tuple([*trainModel])
            carriageData.append(carriageInfo)
            unq = set(carriageData)
    print(unq)


def getallTrainModels():
    getTrainModel8Stations()
    getTrainModel5Stations()


def getDepartStation():

    #get departing station
    departStation = input("Enter Departing station: ")
    #depart = str(departStation)
    getStationData = has_string(getData, "train_stations", "StationName", departStation)
    StationData = [*getStationData]
    for i in StationData:
        StationId, StationName, MaxCarriages = i
    return StationId


def getDestStation():
    #get destination station
    destStation = input("Enter destination station: ")
    getDestStation = has_string(getData, "train_stations", "StationName", destStation)
    getDestination = [*getDestStation]
    for i in getDestination:
        DestStationId, DestStationName, DestMaxCarriages = i
    return(DestStationId)


def getRoute():
    departure = getDepartStation()
    destination = getDestStation()

    routeId = has_value(getData, "routes", "departStationID", departure)
    allRoute = [*routeId]
    for i in allRoute:
        routeID, departStation, destStation, numOfInter, descriptionId = i
        if numOfInter == 5:
            getRouteID(routeID)
            getTrainModel5Stations()
            print("5 stations")
        elif numOfInter == 8:
            getTrainModel8Stations()
            print("8 stations")
        else:
            print("No matching station number")

getRoute()