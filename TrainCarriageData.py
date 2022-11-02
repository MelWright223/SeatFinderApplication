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


def getDescID():
    value = cell_value(getData, "DescriptionID", "routes", "NumOfInterStations", 5)
    descriptionId = [*value]
    for i in descriptionId:
        routeId = [*i]
        descId = routeId
    return descId


def routeInfo():
    getDescID()
    valueOfCell = has_value(getData, "route_description_5_stations", "DescriptionID", getDescID()[0])
    dataOfCell = [*valueOfCell]
    routeData = []
    for x in dataOfCell:
        routeData.append(x)
        # desID, depStatID, first, sec, third, four, five, destin = routeData
    return routeData


def stationInfo():
    t = 0
    carriages = []

    station_data = []
    for val in routeInfo():
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


# use station id in station table
# get maximum carriages for each dedicated station
# store all maximum carriages in a list

