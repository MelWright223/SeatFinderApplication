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


def getMultiVal(cursor, table, column1, value1, column2, value2):
    query = ('Select * From {} Where {} = {} and {} = {}'.format(table, column1, value1, column2, value2))
    cursor.execute(query)
    return cursor


def cell_value(cursor, column, table, specificColumn, value):
    query = 'Select {} From {} Where {} = {}'.format(column, table, specificColumn, value)
    cursor.execute(query)
    return cursor


def getDescId(RouteID):
    carriages = []

    station_data = []
    carriageData = []
    for i in cell_value(getData, "DescriptionID", "routes", "RouteID", RouteID):
        descriptionId = [*i]
        for j in descriptionId:
            value = ''.join(j)
            desList = value.split("_")
            interNum = desList[0]
            desId = desList[1]

            valueOfCell = has_value(getData, "route_description_" + interNum + "_stations", "DescriptionID", desId)
            dataOfCell = [*valueOfCell]
            routeData = []
            for x in dataOfCell:
                routeData.append(x)
                for val in routeData:
                    if has_value(getData, "train_stations", "StationId", val[1]):
                        x = [*val]
                        x.pop(0)
                        station_data.append(x)
                for val in station_data:
                    for val_two in val:
                        for m in has_value(getData, "train_stations", "StationId", val_two):
                            stations = [*m]
                            stationID, stationName, maxCarriages, stationLat, StationLong = stations
                            carriages.append(maxCarriages)
                            print(stationName)
                    for k in carriages:
                        carriagesTrain = k
                        trainModel = has_value(getData, "train_models", "MaximumCarriages", carriagesTrain)
                        carriageInfo = tuple([*trainModel])
                        carriageData.append(carriageInfo)
                        unq = set(carriageData)
                    print(unq)

                # desID, depStatID, first, sec, third, four, five, destin = routeData


# def routeInfoEightStations():
#   valueOfCell = has_value(getData, "route_description_8_stations", "DescriptionID", getInterStations(8))
#  dataOfCell = [*valueOfCell]
# routeData = []
# for x in dataOfCell:
#   routeData.append(x)
# desID, depStatID, first, sec, third, four, five, six, seven, eight, destin = routeData
# return routeData


# def fiveStationInfo():  # if the route has 5 intermediate stations between the departure station and the destination


# def eightStationInfo():  # if the route has 8 intermediate stations between departure station and destination station
# t = 0
# carriages = []

# station_data = []
# for val in routeInfoEightStations():
#   if has_value(getData, "train_stations", "StationId", val[1]):
#      x = [*val]
#     x.pop(0)
#    station_data.append(x)
# for val in station_data:
#    for val_two in val:
#       for I in has_value(getData, "train_stations", "StationId", val_two):
#          stations = [*i]
#         stationID, stationName, maxCarriages = stations
#        carriages.append(maxCarriages)
# return carriages


# def getTrainModel8Stations():
# carriageData = []
# if getInterStations(8):
#   carriages = eightStationInfo()
#  for j in carriages:
#     carriagesTrain = j
#    trainModel = has_value(getData, "train_models", "MaximumCarriages", carriagesTrain)
#   carriageInfo = tuple([*trainModel])
#  carriageData.append(carriageInfo)
# unq = set(carriageData)
# print(unq)


# def getTrainModel5Stations():
# carriageData = []
# if getInterStations(5):
#   carriages = fiveStationInfo()
#  for j in carriages:
#     carriagesTrain = j
#    trainModel = has_value(getData, "train_models", "MaximumCarriages", carriagesTrain)
#   carriageInfo = tuple([*trainModel])
#  carriageData.append(carriageInfo)
# unq = set(carriageData)
# print(unq)


def getDepartStation():
    # get departing station
    departStation = input("Enter Departing station: ")
    # depart = str(departStation)
    getStationData = has_string(getData, "train_stations", "StationName", departStation)
    StationData = [*getStationData]
    for i in StationData:
        StationId, StationName, MaxCarriages, StationLat, StationLong = i
    return StationId


def getDesStation():
    # get destination station
    desStation = input("Enter destination station: ")
    des_Station = has_string(getData, "train_stations", "StationName", desStation)
    getDestination = [*des_Station]
    for i in getDestination:
        DesStationId, DesStationName, DesMaxCarriages, DesStationLat, DesStationLong = i
    return DesStationId


def getRoute():
    departure = getDepartStation()
    destination = getDesStation()

    routeId = getMultiVal(getData, "routes", "DepartStationID", departure, "DestStationID", destination)
    allRoute = [*routeId]
    for i in allRoute:
        routeID, departStation, desStation, numOfInter, descriptionId = i
        if numOfInter == 5:
            getDescId(routeID)
            print("5 stations")
        elif numOfInter == 8:
            getDescId(routeID)
            print("8 stations")
        else:
            print("No matching station number")


getRoute()
