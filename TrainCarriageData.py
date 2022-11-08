import DatabaseConn

connString = DatabaseConn.mydb
getData = connString.cursor(buffered=True)


def has_value(cursor, table, column, value):
    query = ('Select * From {} Where {} = {}'.format(table, column, value))
    cursor.execute(query)
    return cursor


def cell_value(cursor, column, table, specificColumn, value):
    query = 'Select {} From {} Where {} = {}'.format(column, table, specificColumn, value)
    cursor.execute(query)
    return cursor


def getDescID(numOfInterStations):
    value = cell_value(getData, "DescriptionID", "routes", "NumOfInterStations", numOfInterStations)
    descriptionId = [*value]
    for i in descriptionId:
        routeId = [*i]
        descId = routeId
    return descId


def routeInfoFiveStations():
    valueOfCell = has_value(getData, "route_description_5_stations", "DescriptionID", getDescID(5)[0])
    dataOfCell = [*valueOfCell]
    routeData = []
    for x in dataOfCell:
        routeData.append(x)
        # desID, depStatID, first, sec, third, four, five, destin = routeData
    return routeData


def routeInfoEightStations():
    valueOfCell = has_value(getData, "route_description_9_stations", "DescriptionID", getDescID(8)[0])
    dataOfCell = [*valueOfCell]
    routeData = []
    for x in dataOfCell:
        routeData.append(x)
        # desID, depStatID, first, sec, third, four, five, six, seven, eight, destin = routeData
    return routeData


def fiveStationInfo(): # if the route has 5 intermediate stations between the departure station and the destination
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


def eightStationInfo(): # if the route has 8 intermediate stations between departure station and destination station
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


def getTrainModel():
    carriageData =[]
    if getDescID(8):
        carriages = eightStationInfo()
        for j in carriages:
            carriagesTrain = j
            trainModel = has_value(getData, "train_models", "MaximumCarriages", carriagesTrain)
            carriageData.append([*trainModel])
            if carriageData.count(j) > 1:
                print(carriageData)

    if getDescID(5):
        carriages = fiveStationInfo()
        for j in carriages:
            carriagesTrain = j
            trainModel = has_value(getData, "train_models", "MaximumCarriages", carriagesTrain)
            carriageData = [*trainModel]
    print(carriageData)


getTrainModel()
